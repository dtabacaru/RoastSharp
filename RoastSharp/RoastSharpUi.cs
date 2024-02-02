using LiveCharts;
using LiveCharts.Configurations;
using LiveCharts.Wpf;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;

namespace RoastSharp
{
    public partial class RoastSharpUi : Form
    {
        #region Members

        private readonly ChartValues<XYDoubleMapper> m_TemperatureValues = new ChartValues<XYDoubleMapper>();
        private readonly ChartValues<XYDoubleMapper> m_AvgTemperatureValues = new ChartValues<XYDoubleMapper>();
        private readonly ChartValues<XYDoubleMapper> m_RateOfRiseValues = new ChartValues<XYDoubleMapper>();

        #endregion

        #region Constructors

        public RoastSharpUi()
        {
            InitializeComponent();
            InitializeRoastSharp();
            InitializeRoastChart();
        }

        #endregion

        #region Initializers

        private void InitializeRoastSharp()
        {
            RoastSharp.TemperatureEvent += SetTemperature;
            RoastSharp.AverageTemperatureEvent += SetAvgTemperature;
            RoastSharp.ErrorRaisedEvent += RoastSharpErrorRaised;
            RoastSharp.TimeEvent += SetTime;
            RoastSharp.RateEvent += SetRor;
            RoastSharp.PlotTemperatureEvent += PlotTemperature;
            RoastSharp.PlotRateEvent += PlotRor;
            RoastSharp.DisconnectedEvent += Disconnected;
        }

        private void InitializeRoastChart()
        {
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
                    Step = 30000,
                    StrokeThickness = 0.5
                },
                LabelFormatter = value =>
                {
                    (int minutes, int seconds) = Utils.GetMinuteSecondsFromMillis(value);

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

        #endregion

        #region RoastSharp Events

        private void SetTemperature(object sender, TemperatureEventArgs e)
        {
            if (InvokeRequired)
                Invoke(new MethodInvoker(() => { SetTemperature(sender, e); }));

            TempLabel.Text = string.Format("{0:000.00}", e.Temperature) + "°C";
        }

        private void SetAvgTemperature(object sender, TemperatureEventArgs e)
        {
            if (InvokeRequired)
                Invoke(new MethodInvoker(() => { SetAvgTemperature(sender, e); }));

            AvgTempLabel.Text = string.Format("{0:000.00}", e.Temperature) + "°C";

            if (!StartButton.Enabled && !RoastSharp.Started && RoastSharp.Connected)
            {
                SetButtonEnable(StartButton, true);
            }
        }

        private void RoastSharpErrorRaised(object sender, ErrorEventArgs e)
        {
            System.Windows.Forms.MessageBox.Show(e.Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void SetTime(object sender, TimeEventArgs e)
        {
            if (TimeLabel.InvokeRequired)
                TimeLabel.Invoke(new MethodInvoker(() => { SetTime(sender, e); }));

            TimeLabel.Text = string.Format("{0:00}", e.Minutes) + ":"
                           + string.Format("{0:00}", e.Seconds) + ":"
                           + string.Format("{0:000}", e.Milliseconds);
        }

        private void SetRor(object sender, RateEventArgs e)
        {
            if (RorLabel.InvokeRequired)
                RorLabel.Invoke(new MethodInvoker(() => { SetRor(sender, e); }));

            RorLabel.Text = string.Format("{0:00.0}", e.Rate) + "°C/min";
        }

        private void PlotTemperature(object sender, PlotTemperatureEventArgs e)
        {
            m_TemperatureValues.Add(new XYDoubleMapper
            {
                X = e.ElapsedMilliseconds,
                Y = e.Temperature
            });

            m_AvgTemperatureValues.Add(new XYDoubleMapper
            {
                X = e.ElapsedMilliseconds,
                Y = e.AverageTemperature
            });
        }

        private void PlotRor(object sender, PlotRateEventArgs e)
        {
            m_RateOfRiseValues.Add(new XYDoubleMapper
            {
                X = e.ElapsedMilliseconds,
                Y = e.Rate
            });
        }

        private void Disconnected(object sender, EventArgs e)
        {
            ResetForm();
        }

        #endregion

        #region Button Events

        private void ConnectButton_Click(object sender, EventArgs e)
        {
            if (!RoastSharp.Connected)
            {
                RoastSharp.Connect();

                ConnectButton.Text = "Disconnect";
                SettingsButton.Enabled = false;
            }
            else
            {
                RoastSharp.Disconnect();
            }
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            RoastSharp.Start();

            m_TemperatureValues.Clear();
            m_AvgTemperatureValues.Clear();
            m_RateOfRiseValues.Clear();
            RoastChart.VisualElements.Clear();
            RoastChart.AxisX[0].Sections.Clear();

            FcStartButton.Enabled = true;
            EventButton.Enabled = true;
            EndButton.Enabled = true;

            StartButton.Enabled = false;
        }

        private void EndButton_Click(object sender, EventArgs e)
        {
            RoastSharp.Stop();

            StartButton.Enabled = true;
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
                Value = RoastSharp.LastTime,
                Stroke = System.Windows.Media.Brushes.YellowGreen,
                StrokeThickness = 1,
            });

            (int minutes, int seconds) = Utils.GetMinuteSecondsFromMillis(RoastSharp.LastTime);
            RoastChart.VisualElements.Add(new VisualElement
            {
                X = RoastSharp.LastTime,
                Y = RoastSharp.LastTemperature + 5,
                HorizontalAlignment = System.Windows.HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Top,
                UIElement = new TextBlock
                {
                    Text = "FC Start " + minutes + ":" + string.Format("{0:00}", seconds),
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
                Value = RoastSharp.LastTime,
                Stroke = System.Windows.Media.Brushes.YellowGreen,
                StrokeThickness = 1,
            });

            (int minutes, int seconds) = Utils.GetMinuteSecondsFromMillis(RoastSharp.LastTime);
            RoastChart.VisualElements.Add(new VisualElement
            {
                X = RoastSharp.LastTime,
                Y = RoastSharp.LastTemperature + 5,
                HorizontalAlignment = System.Windows.HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Top,
                UIElement = new TextBlock
                {
                    Text = "FC End " + minutes + ":" + string.Format("{0:00}", seconds),
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
                Value = RoastSharp.LastTime,
                Stroke = System.Windows.Media.Brushes.YellowGreen,
                StrokeThickness = 1,
            });

            (int minutes, int seconds) = Utils.GetMinuteSecondsFromMillis(RoastSharp.LastTime);
            RoastChart.VisualElements.Add(new VisualElement
            {
                X = RoastSharp.LastTime,
                Y = RoastSharp.LastTemperature + 5,
                HorizontalAlignment = System.Windows.HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Top,
                UIElement = new TextBlock
                {
                    Text = "SC Start " + minutes + ":" + string.Format("{0:00}", seconds),
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
                Value = RoastSharp.LastTime,
                Stroke = System.Windows.Media.Brushes.YellowGreen,
                StrokeThickness = 1,
            });

            (int minutes, int seconds) = Utils.GetMinuteSecondsFromMillis(RoastSharp.LastTime);
            RoastChart.VisualElements.Add(new VisualElement
            {
                X = RoastSharp.LastTime,
                Y = RoastSharp.LastTemperature + 5,
                HorizontalAlignment = System.Windows.HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Top,
                UIElement = new TextBlock
                {
                    Text = "SC End " + minutes + ":" + string.Format("{0:00}", seconds),
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
                Value = RoastSharp.LastTime,
                Stroke = System.Windows.Media.Brushes.YellowGreen,
                StrokeThickness = 1,
            });

            (int minutes, int seconds) = Utils.GetMinuteSecondsFromMillis(RoastSharp.LastTime);
            RoastChart.VisualElements.Add(new VisualElement
            {
                X = RoastSharp.LastTime,
                Y = RoastSharp.LastTemperature + 5,
                HorizontalAlignment = System.Windows.HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Top,
                UIElement = new TextBlock
                {
                    Text = "Event " + RoastSharp.EventNumber + " " + minutes + ":" + string.Format("{0:00}", seconds),
                    FontWeight = FontWeights.Bold,
                    Foreground = System.Windows.Media.Brushes.MintCream,
                    FontSize = 16,
                }
            });

            RoastSharp.EventNumber += 1;
        }

        private void SettingsButton_Click(object sender, EventArgs e)
        {
            SettingsUi sf = new SettingsUi(RoastChart.AxisX[0].Separator.Step);
            sf.ShowDialog();

            RoastSharp.ComString = sf.ComString;
            RoastSharp.MovingAvgSamples = sf.MovingAvgSamples;
            RoastSharp.RorSampleTime = sf.RorSampleTime;
            RoastSharp.RorDelayTime = sf.RorDelayTime;
            RoastSharp.BaudRate = sf.BaudRate;

            RoastChart.AxisX[0].Separator.Step = sf.XSteps;
        }

        #endregion

        #region UI Helpers
        private void SetButtonEnable(System.Windows.Forms.Button button, bool enable)
        {
            if (button.InvokeRequired)
                button.Invoke(new MethodInvoker(() => { SetButtonEnable(button, enable); }));

            button.Enabled = enable;
        }

        private void ResetForm()
        {
            if (InvokeRequired)
                Invoke(new MethodInvoker(() => { ResetForm(); }));

            ConnectButton.Text = "Connect";

            StartButton.Enabled = false;
            FcStartButton.Enabled = false;
            FcEndButton.Enabled = false;
            ScEndButton.Enabled = false;
            ScStartButton.Enabled = false;
            EndButton.Enabled = false;
            EventButton.Enabled = false;
            SettingsButton.Enabled = true;
        }

        #endregion
    }

    public class XYDoubleMapper
    {
        public double X { get; set; }
        public double Y { get; set; }
    }
}
