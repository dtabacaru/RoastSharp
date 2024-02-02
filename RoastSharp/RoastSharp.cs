using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Ports;
using System.Threading.Tasks;

namespace RoastSharp
{
    #region Event Args

    public class ErrorEventArgs : EventArgs
    {
        public string Error { get; }
        public ErrorEventArgs(string error) => Error = error;
    }
    public class TemperatureEventArgs : EventArgs
    {
        public double Temperature { get; }
        public TemperatureEventArgs(double temperature) => Temperature = temperature;
    }
    public class TimeEventArgs : EventArgs
    {
        public int Minutes { get; }
        public int Seconds { get; }
        public int Milliseconds { get; }
        public TimeEventArgs(int minutes, int seconds, int milliseconds)
        {
            Minutes = minutes;
            Seconds = seconds;
            Milliseconds = milliseconds;
        }
    }
    public class RateEventArgs : EventArgs
    {
        public double Rate { get; }
        public RateEventArgs(double rate) => Rate = rate;
    }
    public class PlotRateEventArgs : EventArgs
    {
        public double Rate { get; }
        public long ElapsedMilliseconds { get; }
        public PlotRateEventArgs(double rate, long elapsedMilliseconds)
        {
            Rate = rate;
            ElapsedMilliseconds = elapsedMilliseconds;
        }
    }

    public class PlotTemperatureEventArgs : EventArgs
    {
        public long ElapsedMilliseconds { get; }
        public double Temperature { get; }
        public double AverageTemperature { get; }
        public PlotTemperatureEventArgs(long elapsedMilliseconds, double temperature, double averageTemperature)
        {
            ElapsedMilliseconds = elapsedMilliseconds;
            Temperature = temperature;
            AverageTemperature = averageTemperature;
        }
    }

    #endregion

    public static class RoastSharp
    {

        #region Events

        public static event EventHandler<ErrorEventArgs> ErrorRaisedEvent;
        public static event EventHandler<TemperatureEventArgs> TemperatureEvent;
        public static event EventHandler<TemperatureEventArgs> AverageTemperatureEvent;
        public static event EventHandler<TimeEventArgs> TimeEvent;
        public static event EventHandler<RateEventArgs> RateEvent;
        public static event EventHandler<PlotTemperatureEventArgs> PlotTemperatureEvent;
        public static event EventHandler<PlotRateEventArgs> PlotRateEvent;
        public static event EventHandler<EventArgs> DisconnectedEvent;

        #endregion

        #region Members

        private static StreamWriter m_RoastLog = null;
        private static readonly object m_RoastLogLock = new object();
        private static SerialPort m_SerialPort = null;
        private static readonly List<double> m_MovingAvgHistory = new List<double>();

        private static volatile bool m_Started = false;
        private static volatile bool m_Connected = false;
        private static volatile bool m_EnableLogging = true;
        private static readonly Stopwatch m_RoastStopwatch = new Stopwatch();

        private static int m_EventNumber = 1;
        private static double m_LastRorTemperature = 0;
        private static double m_LastRorTime = 0;
        private static double m_LastTemperature = 0;
        private static readonly object LastTemperatureLock = new object();
        private static double m_LastTime = 0;
        private static readonly object LastTimeLock = new object();

        public static string m_ComString = string.Empty;
        public static int m_BaudRate = 115200;
        public static int m_RorSampleTime = 15;
        public static int m_RorDelayTime = 30;
        private static int m_MovingAvgSamples = 16;

        #endregion

        #region Properties

        public static double LastTime
        {
            get { lock (LastTimeLock) { return m_LastTime; } }
            set { lock (LastTimeLock) { m_LastTime = value; } }
        }
        public static double LastTemperature
        {
            get { lock (LastTemperatureLock) { return m_LastTemperature; } }
            set { lock (LastTemperatureLock) { m_LastTemperature = value; } }
        }
        public static string ComString
        {
            get => m_ComString;
            set => m_ComString = value;
        }
        public static int BaudRate
        {
            get => m_BaudRate;
            set => m_BaudRate = value;
        }
        public static int RorSampleTime
        {
            get => m_RorSampleTime;
            set => m_RorSampleTime = value;
        }
        public static int RorDelayTime
        {
            get => m_RorDelayTime;
            set => m_RorDelayTime = value;
        }
        public static int MovingAvgSamples
        {
            get => m_MovingAvgSamples;
            set => m_MovingAvgSamples = value;
        }
        public static int EventNumber
        {
            get => m_EventNumber;
            set => m_EventNumber = value;
        }
        public static bool EnableLogging
        {
            get => m_EnableLogging;
            set => m_EnableLogging = value;
        }

        public static bool Started
        {
            get => m_Started;
        }
        public static bool Connected
        {
            get => m_Connected;
        }

        #endregion

        #region Constructors

        static RoastSharp()
        {
            List<string> comPorts = Utils.ListComPorts();

            foreach (string comDescription in comPorts)
            {
                if (comDescription.Contains("USB Serial Device"))
                {
                    m_ComString = Utils.ExtractComPort(comDescription);
                    break;
                }
            }
        }

        #endregion

        #region Action Methods

        public static void Start()
        {
            m_LastRorTemperature = 0;
            m_LastRorTime = 0;
            LastTemperature = 0;
            LastTime = 0;
            m_EventNumber = 1;
            if (m_EnableLogging)
            {
                lock (m_RoastLogLock) { m_RoastLog = new StreamWriter(DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss") + ".csv", false); }
            }
            m_RoastStopwatch.Restart();
            m_Started = true;
        }

        public static void Stop()
        {
            m_Started = false;

            if (m_EnableLogging)
            {
                lock (m_RoastLogLock) { m_RoastLog.Close(); }
            }
        }

        public static void Connect()
        {
            Task.Run(() =>
            {
                ReadTemperaturesTask();
            });
        }

        public static void Disconnect()
        {
            m_Connected = false;
        }

        #endregion

        #region Temperature Log Methods

        private static void ReadTemperaturesTask()
        {
            m_SerialPort = new SerialPort(ComString, m_BaudRate, Parity.None, 8, StopBits.One)
            {
                ReadTimeout = 5000
            };
            m_SerialPort.Open();
            m_SerialPort.ReadExisting();  // Flush

            m_Connected = true;

            while (m_Connected)
            {
                try
                {
                    ReadData();
                }
                catch (Exception e)
                {
                    ErrorEventArgs eea = new ErrorEventArgs(e.Message);
                    ErrorRaisedEvent?.Invoke(null, eea);
                }
            }

            m_SerialPort.Close();
            m_MovingAvgHistory.Clear();
            m_RoastStopwatch.Stop();
            m_Started = false;

            DisconnectedEvent?.Invoke(null, null);
        }

        public static void ReadData()
        {
            string dataString = m_SerialPort.ReadLine();

            double temperature = Convert.ToDouble(dataString);

            TemperatureEventArgs tra = new TemperatureEventArgs(temperature);
            TemperatureEvent?.Invoke(null, tra);

            if (m_MovingAvgHistory.Count < m_MovingAvgSamples)
            {
                m_MovingAvgHistory.Add(temperature);
                return;
            }

            double avgTemp = CalculateMovingAverage(temperature);

            TemperatureEventArgs avgTra = new TemperatureEventArgs(avgTemp);
            AverageTemperatureEvent?.Invoke(null, avgTra);

            if (m_Started)
            {
                TimeEventArgs tea = new TimeEventArgs(m_RoastStopwatch.Elapsed.Minutes, m_RoastStopwatch.Elapsed.Seconds, m_RoastStopwatch.Elapsed.Milliseconds);
                TimeEvent?.Invoke(null, tea);

                if (m_EnableLogging)
                {
                    lock (m_RoastLogLock) { m_RoastLog.WriteLine(m_RoastStopwatch.ElapsedMilliseconds + "," + temperature + "," + avgTemp); }
                }

                PlotTemperatureEventArgs pea = new PlotTemperatureEventArgs(m_RoastStopwatch.ElapsedMilliseconds, temperature, avgTemp);
                PlotTemperatureEvent?.Invoke(null, pea);

                LastTemperature = temperature;
                LastTime = m_RoastStopwatch.ElapsedMilliseconds;

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

                    RateEventArgs rra = new RateEventArgs(ror);
                    RateEvent?.Invoke(null, rra);

                    PlotRateEventArgs prea = new PlotRateEventArgs(ror, m_RoastStopwatch.ElapsedMilliseconds);
                    PlotRateEvent?.Invoke(null, prea);

                    m_LastRorTime = m_RoastStopwatch.ElapsedMilliseconds;
                    m_LastRorTemperature = avgTemp;
                }
            }
        }

        #endregion

        #region Helpers

        private static double CalculateMovingAverage(double temperature)
        {
            m_MovingAvgHistory.RemoveAt(0);
            m_MovingAvgHistory.Add(temperature);

            double avgTemp = 0;

            foreach (double temp in m_MovingAvgHistory)
            {
                avgTemp += temp;
            }

            avgTemp /= m_MovingAvgHistory.Count;

            return avgTemp;
        }

        #endregion
    }
}
