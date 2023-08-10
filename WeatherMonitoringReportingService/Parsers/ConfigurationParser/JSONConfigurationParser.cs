using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WeatherMonitoringReportingService.Data;

namespace WeatherMonitoringReportingService.Parsers.ConfigurationParser
{
    public class JSONConfigurationParser : IConfigurationParser
    {
        public Dictionary<Common.Bots, ConfigurationData> ParseConfiguration(string fileName)
        {
            if (!File.Exists(fileName))
            {
                throw new FileNotFoundException("JSON file not found.", fileName);
            }

            string jsonData = File.ReadAllText(fileName);

            Dictionary<Common.Bots, ConfigurationData> configDict = JsonSerializer.Deserialize<Dictionary<Common.Bots, ConfigurationData>>(jsonData);

            return configDict;
        }
    }
}
