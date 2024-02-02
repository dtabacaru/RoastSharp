using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace RoastSharp
{
    public partial class SettingsUi : Form
    {
        public string ComString = string.Empty;
        public int BaudRate = 115200;
        public int MovingAvgSamples = 16;
        public int RorSampleTime = 15;
        public int RorDelayTime = 30;
        public bool EnableLogging = false;
        public double XSteps = 30;

        public SettingsUi(double xsteps)
        {
            InitializeComponent();

            List<string> comPorts = Utils.ListComPorts();

            ComPortDropDown.Items.AddRange(comPorts.ToArray());

            if (RoastSharp.ComString != string.Empty)
            {
                foreach (string port in comPorts)
                {
                    if (port.Contains(RoastSharp.ComString))
                    {
                        ComPortDropDown.SelectedItem = port;
                        break;
                    }
                }
            }

            BaudRate = RoastSharp.BaudRate;
            BaudRateDropDown.SelectedIndex = BaudRateDropDown.Items.IndexOf(BaudRate.ToString());

            MovingAvgSamples = RoastSharp.MovingAvgSamples;
            SamplesTextBox.Value = MovingAvgSamples;

            RorSampleTime = RoastSharp.RorSampleTime;
            RorSampleTimeTextBox.Value = RorSampleTime;

            RorDelayTime = RoastSharp.RorDelayTime;
            RorDelayTimeTextBox.Value = RorDelayTime;

            EnableLogging = RoastSharp.EnableLogging;
            EnableLoggingCheckBox.Checked = EnableLogging;

            XSteps = xsteps;
            XStepsTextBox.Value = (decimal)XSteps/1000;
        }

        private void SettingsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            RorDelayTime = (int)RorDelayTimeTextBox.Value;
            RorSampleTime = (int)RorSampleTimeTextBox.Value;
            MovingAvgSamples = (int)SamplesTextBox.Value;
            XSteps = (double)XStepsTextBox.Value * 1000;

            if(ComPortDropDown.SelectedIndex >= 0)
            {
                string comDescription = ComPortDropDown.Items[ComPortDropDown.SelectedIndex].ToString();
                ComString = Utils.ExtractComPort(comDescription);
            }

            BaudRate = Convert.ToInt32(BaudRateDropDown.Items[BaudRateDropDown.SelectedIndex].ToString());
            EnableLogging = EnableLoggingCheckBox.Checked;
        }
    }
}
