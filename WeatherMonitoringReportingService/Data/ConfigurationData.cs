using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherMonitoringReportingService.Data
{
    public class ConfigurationData
    {
        public bool Enabled { get; set; }
        public double? HumidityThreshold { get; set; }
        public double? TemperatureThreshold { get; set; }
        public string Message { get; set; }
    }
}
