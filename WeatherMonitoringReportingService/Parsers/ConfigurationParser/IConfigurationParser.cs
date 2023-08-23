using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherMonitoringReportingService.Data;

namespace WeatherMonitoringReportingService.Parsers
{
    public interface IConfigurationParser
    {
        public Dictionary<Common.Bots, ConfigurationData> ParseConfiguration(string fileName);
    }
}
