using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherMonitoringReportingService.Data
{
    public class ConfigurationData
    {
        public Common.Bots BotName { get; set; }
        public bool Enabled { get; set; }
        public double Threshold { get; set; }
        public string Message { get; set; }
    }
}
