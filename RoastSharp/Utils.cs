using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;

namespace RoastSharp
{
    static class Utils
    {
        public static List<string> ListComPorts()
        {
            List<string> comPorts = new List<string>();

            using (var searcher = new ManagementObjectSearcher("SELECT Caption FROM Win32_PnPEntity WHERE Caption like '%(COM%'"))
            {
                comPorts = searcher.Get().OfType<ManagementObject>().ToList().Select(p => p["Caption"].ToString()).ToList();
            }

            return comPorts;
        }

        public static string ExtractComPort(string comDescription)
        {
            return comDescription.Split('(')[1].Replace(")", "");
        }

        public static Tuple<int, int> GetMinuteSecondsFromMillis(double millis)
        {
            int minutes = (int)millis / 60000;
            int seconds = (int)(millis / 1000) - minutes * 60;

            return new Tuple<int, int>(minutes, seconds);
        }
    }
}
