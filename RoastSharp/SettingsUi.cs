using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RoastSharp
{
    public partial class SettingsUi : Form
    {
        public string ComString = string.Empty;
        public int MovingAvgSamples = 16;
        public int RorSampleTime = 15;
        public int RorDelayTime = 30;

        public SettingsUi(RoastSharpUi rsui)
        {
            InitializeComponent();

            List<string> comPorts;

            using (var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_PnPEntity WHERE Caption like '%(COM%'"))
            {
                string[] portnames = SerialPort.GetPortNames();
                IEnumerable<string> ports = searcher.Get().Cast<ManagementBaseObject>().ToList().Select(p => p["Caption"].ToString());

                List<string> test = new List<string>(ports);

                comPorts = portnames.Select(n => ports.FirstOrDefault(s => s.Contains(n))).ToList();
                ComPortDropDown.Items.AddRange(comPorts.ToArray());

                if(rsui.ComString != string.Empty)
                {
                    foreach (string port in comPorts)
                    {
                        if (port.Contains(rsui.ComString))
                        {
                            ComPortDropDown.SelectedItem = port;
                            break;
                        }
                    }
                }

                MovingAvgSamples = rsui.MovingAvgSamples;
                SamplesTextBox.Value = MovingAvgSamples;

                RorSampleTime = rsui.RorSampleTime;
                RorSampleTimeTextBox.Value = RorSampleTime;

                RorDelayTime = rsui.RorDelayTime;
                RorDelayTimeTextBox.Value = RorDelayTime;
            }
        }

        private void SettingsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            RorDelayTime = (int)RorDelayTimeTextBox.Value;
            RorSampleTime = (int)RorSampleTimeTextBox.Value;
            MovingAvgSamples = (int)SamplesTextBox.Value;

            if(ComPortDropDown.SelectedIndex >= 0)
            {
                string comDescription = (string)ComPortDropDown.Items[ComPortDropDown.SelectedIndex];
                ComString = comDescription.Split('(')[1].Replace(")", "");
            }
        }
    }
}
