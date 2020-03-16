using LiveCharts;
using LiveCharts.Configurations;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Management;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;

namespace RoastSharp
{
    public partial class RoastSharpUi : Form
    {
        private int    m_Eventno = 1;
        private long   m_StartTicks = 0;
        private double m_LastRorTemperature = 0;
        private double m_LastRorTime = 0;
        private double m_LastTemperature = 0;
        private double m_LastTime = 0;
        
        private volatile bool m_Started = false;
        private volatile bool m_Connected = false;

        private Stopwatch m_RoastStopwatch = new Stopwatch();
        private StreamWriter m_RoastLog = null;
        private ChartValues<XYDoubleMapper> m_TemperatureValues = new ChartValues<XYDoubleMapper>();
        private ChartValues<XYDoubleMapper> m_AvgTemperatureValues = new ChartValues<XYDoubleMapper>();
        private ChartValues<XYDoubleMapper> m_RateOfRiseValues = new ChartValues<XYDoubleMapper>();
        private SerialPort m_SerialPort = null;

        private List<double> m_MovingAvgHistory = new List<double>();

        public string ComString = string.Empty;
        public int MovingAvgSamples = 16;
        public int RorSampleTime = 15;
        public int RorDelayTime = 30;

        public RoastSharpUi()
        {
            InitializeComponent();

            SetComPort();

            RoastChart.DisableAnimations = true;
            RoastChart.Hoverable = false;
            RoastChart.DataTooltip = null;
            RoastChart.LegendLocation = LegendLocation.Top;
            RoastChart.DefaultLegend.Foreground = System.Windows.Media.Brushes.MintCream;

            CartesianMapper<XYDoubleMapper> mapper = Mappers.Xy<XYDoubleMapper>()
            .X(model => model.X)
            .Y(model => model.Y);

            Charting.For<XYDoubleMapper>(mapper);

            RoastChart.AxisX.Add(new Axis
            {
                Title = "Time",
                MinValue = 0,
                FontWeight = FontWeights.Bold,
                FontSize = 16,
                Foreground = System.Windows.Media.Brushes.MintCream,
                Separator = new LiveCharts.Wpf.Separator
                {
                    StrokeThickness = 0.5
                },
                LabelFormatter = value =>
                {
                    int minutes = (int)value / 60000;
                    int seconds = (int)(value / 1000) - minutes * 60;

                    return string.Format("{0:00}", minutes) + ":" + string.Format("{0:00}", seconds);
                },
            });

            RoastChart.AxisY.Add(new Axis
            {
                Title = "Temperature °C",
                MinValue = 0,
                Position = AxisPosition.LeftBottom,
                FontWeight = FontWeights.Bold,
                FontSize = 16,
                Foreground = System.Windows.Media.Brushes.Lavender,
                Separator = new LiveCharts.Wpf.Separator
                {
                    Step = 50.0,
                    StrokeThickness = 0.5
                }

            });

            RoastChart.AxisY.Add(new Axis
            {
                Title = "Rate °C/min",
                Position = AxisPosition.RightTop,
                FontWeight = FontWeights.Bold,
                FontSize = 16,
                MinValue = -10,
                MaxValue = 60,
                Foreground = System.Windows.Media.Brushes.LavenderBlush,
                Separator = new LiveCharts.Wpf.Separator
                {
                    Step = 10.0,
                    StrokeThickness = 0.5
                }
            });

            RoastChart.Series = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Raw Bean Temperature",
                    Values = m_TemperatureValues,
                    StrokeThickness = 1,
                    PointGeometry = DefaultGeometries.None,
                    ScalesYAt = 0,
                    Fill = System.Windows.Media.Brushes.Transparent,
                    Stroke = System.Windows.Media.Brushes.Yellow,
                },
                new LineSeries
                {
                    Title = "Smoothed Bean Temperature",
                    Values = m_AvgTemperatureValues,
                    StrokeThickness = 2,
                    PointGeometry = DefaultGeometries.None,
                    ScalesYAt = 0,
                    Fill = System.Windows.Media.Brushes.Transparent,
                    Stroke = System.Windows.Media.Brushes.Aqua,
                },
                new LineSeries
                {
                    Title = "Smoothed Bean Temperature Rate",
                    Values = m_RateOfRiseValues,
                    StrokeThickness = 2,
                    PointGeometry = DefaultGeometries.None,
                    ScalesYAt = 1,
                    Fill = System.Windows.Media.Brushes.Transparent,
                    Stroke = System.Windows.Media.Brushes.Red,
                }
            };
        }

        private void SetComPort()
        {
            using (var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_PnPEntity WHERE Caption like '%(COM%'"))
            {
                string[] portnames = SerialPort.GetPortNames();
                IEnumerable<string> ports = searcher.Get().Cast<ManagementBaseObject>().ToList().Select(p => p["Caption"].ToString());

                List<string> comPorts = portnames.Select(n => n + "%" + ports.FirstOrDefault(s => s.Contains(n))).ToList();

                foreach (string port in comPorts)
                {
                    if (port.ToLower().Contains("arduino"))
                    {
                        string[] parts = port.Split('%');
                        ComString = parts[0];
                        break;
                    }
                }
            }
        }

        private void ReadData()
        {
            string dataString = m_SerialPort.ReadLine();

            double temperature = Convert.ToDouble(dataString);

            SetTemperature(temperature);

            // Return here until we have accumulated m_MovingAvgSamples

            if (m_MovingAvgHistory.Count < MovingAvgSamples)
            {
                m_MovingAvgHistory.Add(temperature);
                return;
            }
            else
            {
                m_MovingAvgHistory.RemoveAt(0);
                m_MovingAvgHistory.Add(temperature);
            }

            double avgTemp = 0;

            foreach (double temp in m_MovingAvgHistory)
            {
                avgTemp += temp;
            }

            avgTemp /= m_MovingAvgHistory.Count;

            SetAvgTemperature(avgTemp);

            // Enable start button if we have accumulated m_MovingAvgSamples

            if (!StartButton.Enabled && !m_Started && m_Connected)
            {
                SetButtonEnable(StartButton, true);
            }

            // Start plotting and logging

            if (m_Started)
            {
                string timeString;

                timeString = string.Format("{0:00}", m_RoastStopwatch.Elapsed.Minutes) + ":"
                           + string.Format("{0:00}", m_RoastStopwatch.Elapsed.Seconds) + ":"
                           + string.Format("{0:000}", m_RoastStopwatch.Elapsed.Milliseconds);

                SetTime(timeString);

                double logtime = ((double)(DateTime.Now.Ticks - m_StartTicks) / TimeSpan.TicksPerMillisecond) / 1000.0;

                m_RoastLog.WriteLine(logtime + "," + temperature + "," + avgTemp);
                
                PlotTemperature(temperature, avgTemp, m_RoastStopwatch.ElapsedMilliseconds);

                m_LastTemperature = temperature;
                m_LastTime = m_RoastStopwatch.ElapsedMilliseconds;

                // Don't calculate ROR until after m_RorDelayTime

                if (m_RoastStopwatch.ElapsedMilliseconds < (RorDelayTime * 1000))
                    return;

                if (m_LastRorTemperature == 0)
                {
                    m_LastRorTemperature = avgTemp;
                    m_LastRorTime = m_RoastStopwatch.ElapsedMilliseconds;
                }

                if ((m_RoastStopwatch.ElapsedMilliseconds - m_LastRorTime) > (RorSampleTime * 1000))
                {
                    double ror = ((avgTemp - m_LastRorTemperature) / ((m_RoastStopwatch.ElapsedMilliseconds - m_LastRorTime) / (1000))) * 60;

                    SetRor(ror);
                    PlotRor(ror, m_RoastStopwatch.ElapsedMilliseconds);

                    m_LastRorTime = m_RoastStopwatch.ElapsedMilliseconds;
                    m_LastRorTemperature = avgTemp;
                }

            }
        }

        private void ReadTemperaturesTask()
        {
            while (m_Connected)
            {
                try
                {
                    ReadData();
                }
                catch { }
            }
        }

        private void ConnectButton_Click(object sender, EventArgs e)
        {
            if (!m_Connected)
            {
                try
                {
                    m_SerialPort = new SerialPort(ComString, 38400, Parity.None, 8, StopBits.One);
                    m_SerialPort.Open();
                    m_Connected = true;
                }
                catch (Exception exc)
                {
                    System.Windows.Forms.MessageBox.Show(exc.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return;
                }

                ConnectButton.Text = "Disconnect";
                SettingsButton.Enabled = false;

                // Flush
                m_SerialPort.ReadExisting();

                Task.Run(() =>
                {
                    ReadTemperaturesTask();
                });
            }
            else
            {
                m_Connected = false;
                m_SerialPort.Close();
                ConnectButton.Text = "Connect";

                StartButton.Enabled = false;
                FcStartButton.Enabled = false;
                FcEndButton.Enabled = false;
                ScEndButton.Enabled = false;
                ScStartButton.Enabled = false;
                EndButton.Enabled = false;
                EventButton.Enabled = false;
                SettingsButton.Enabled = true;

                m_TemperatureValues.Clear();
                m_AvgTemperatureValues.Clear();
                m_RateOfRiseValues.Clear();
                m_RoastStopwatch.Stop();
                m_MovingAvgHistory.Clear();

                TempLabel.Text = "000.00°C";
                AvgTempLabel.Text = "000.00°C";
                TimeLabel.Text = "00:00:000";
                RorLabel.Text = "00.0°C/min";

                m_Started = false;
            }

        }

        private void SetButtonEnable(System.Windows.Forms.Button button, bool enable)
        {
            if (button.InvokeRequired)
                button.Invoke(new MethodInvoker(() => { SetButtonEnable(button, enable); }));

            button.Enabled = enable;
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            m_RoastLog = new StreamWriter("RoastSharp" + DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss") + ".csv", false);
            m_StartTicks = DateTime.Now.Ticks;

            m_Started = true;

            m_TemperatureValues.Clear();
            m_AvgTemperatureValues.Clear();
            m_RateOfRiseValues.Clear();
            m_RoastStopwatch.Restart();

            FcStartButton.Enabled = true;
            EventButton.Enabled = true;
            EndButton.Enabled = true;

            StartButton.Enabled = false;
        }

        private void EndButton_Click(object sender, EventArgs e)
        {
            m_RoastLog.Close();

            m_Started = false;
            m_MovingAvgHistory.Clear();

            FcStartButton.Enabled = false;
            FcEndButton.Enabled = false;
            ScEndButton.Enabled = false;
            ScStartButton.Enabled = false;
            EndButton.Enabled = false;
            EventButton.Enabled = false;
        }

        private void FcStartButton_Click(object sender, EventArgs e)
        {
            RoastChart.AxisX[0].Sections.Add(new AxisSection
            {
                Value = m_LastTime,
                Stroke = System.Windows.Media.Brushes.YellowGreen,
                StrokeThickness = 1,
            });

            RoastChart.VisualElements.Add(new VisualElement
            {
                X = m_LastTime,
                Y = m_LastTemperature,
                HorizontalAlignment = System.Windows.HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Top,
                UIElement = new TextBlock //notice this property must be a wpf control
                {
                    Text = "FC Start",
                    FontWeight = FontWeights.Bold,
                    Foreground = System.Windows.Media.Brushes.MintCream,
                    FontSize = 16,
                }
            });

            FcStartButton.Enabled = false;
            FcEndButton.Enabled = true;
        }

        private void FcEndButton_Click(object sender, EventArgs e)
        {
            RoastChart.AxisX[0].Sections.Add(new AxisSection
            {
                Value = m_LastTime,
                Stroke = System.Windows.Media.Brushes.YellowGreen,
                StrokeThickness = 1,
            });

            RoastChart.VisualElements.Add(new VisualElement
            {
                X = m_LastTime,
                Y = m_LastTemperature,
                HorizontalAlignment = System.Windows.HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Top,
                UIElement = new TextBlock //notice this property must be a wpf control
                {
                    Text = "FC End",
                    FontWeight = FontWeights.Bold,
                    Foreground = System.Windows.Media.Brushes.MintCream,
                    FontSize = 16,
                }
            });

            FcEndButton.Enabled = false;
            ScStartButton.Enabled = true;
        }

        private void ScStartButton_Click(object sender, EventArgs e)
        {
            RoastChart.AxisX[0].Sections.Add(new AxisSection
            {
                Value = m_LastTime,
                Stroke = System.Windows.Media.Brushes.YellowGreen,
                StrokeThickness = 1,
            });

            RoastChart.VisualElements.Add(new VisualElement
            {
                X = m_LastTime,
                Y = m_LastTemperature,
                HorizontalAlignment = System.Windows.HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Top,
                UIElement = new TextBlock //notice this property must be a wpf control
                {
                    Text = "SC Start",
                    FontWeight = FontWeights.Bold,
                    Foreground = System.Windows.Media.Brushes.MintCream,
                    FontSize = 16,
                }
            });

            ScStartButton.Enabled = false;
            ScEndButton.Enabled = true;
        }

        private void ScEndButton_Click(object sender, EventArgs e)
        {
            RoastChart.AxisX[0].Sections.Add(new AxisSection
            {
                Value = m_LastTime,
                Stroke = System.Windows.Media.Brushes.YellowGreen,
                StrokeThickness = 1,
            });

            RoastChart.VisualElements.Add(new VisualElement
            {
                X = m_LastTime,
                Y = m_LastTemperature,
                HorizontalAlignment = System.Windows.HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Top,
                UIElement = new TextBlock //notice this property must be a wpf control
                {
                    Text = "SC End",
                    FontWeight = FontWeights.Bold,
                    Foreground = System.Windows.Media.Brushes.MintCream,
                    FontSize = 16,
                }
            });

            ScEndButton.Enabled = false;
        }

        private void EventButton_Click(object sender, EventArgs e)
        {
            RoastChart.AxisX[0].Sections.Add(new AxisSection
            {
                Value = m_LastTime,
                Stroke = System.Windows.Media.Brushes.YellowGreen,
                StrokeThickness = 1,
            });

            RoastChart.VisualElements.Add(new VisualElement
            {
                X = m_LastTime,
                Y = m_LastTemperature,
                HorizontalAlignment = System.Windows.HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Top,
                UIElement = new TextBlock //notice this property must be a wpf control
                {
                    Text = "Event " + m_Eventno,
                    FontWeight = FontWeights.Bold,
                    Foreground = System.Windows.Media.Brushes.MintCream,
                    FontSize = 16,
                }
            });

            m_Eventno++;
        }

        private void PlotTemperature(double temperature, double avgtemperature, double time)
        {
            m_TemperatureValues.Add(new XYDoubleMapper
            {
                X = time,
                Y = temperature
            });

            m_AvgTemperatureValues.Add(new XYDoubleMapper
            {
                X = time,
                Y = avgtemperature
            });
        }

        private void PlotRor(double ror, double time)
        {
            m_RateOfRiseValues.Add(new XYDoubleMapper
            {
                X = time,
                Y = ror
            });
        }

        private void SetTemperature(double temperature)
        {
            if (TempLabel.InvokeRequired)
                TempLabel.Invoke(new MethodInvoker(() => { SetTemperature(temperature); }));

            TempLabel.Text = string.Format("{0:000.00}", temperature) + "°C";
        }

        private void SetAvgTemperature(double temperature)
        {
            if (AvgTempLabel.InvokeRequired)
                AvgTempLabel.Invoke(new MethodInvoker(() => { SetAvgTemperature(temperature); }));

            AvgTempLabel.Text = string.Format("{0:000.00}", temperature) + "°C";
        }

        private void SetTime(string time)
        {
            if (TimeLabel.InvokeRequired)
                TimeLabel.Invoke(new MethodInvoker(() => { SetTime(time); }));

            TimeLabel.Text = time;
        }

        private void SetRor(double ror)
        {
            if (RorLabel.InvokeRequired)
                RorLabel.Invoke(new MethodInvoker(() => { SetRor(ror); }));

            RorLabel.Text = string.Format("{0:00.0}", ror) + "°C/min";
        }

        private void SettingsButton_Click(object sender, EventArgs e)
        {
            SettingsUi sf = new SettingsUi(this);
            sf.ShowDialog();

            ComString = sf.ComString;
            MovingAvgSamples = sf.MovingAvgSamples;
            RorSampleTime = sf.RorSampleTime;
            RorDelayTime = sf.RorDelayTime;
        }
    }

    public class XYDoubleMapper
    {
        public double X { get; set; }
        public double Y { get; set; }
    }
}
