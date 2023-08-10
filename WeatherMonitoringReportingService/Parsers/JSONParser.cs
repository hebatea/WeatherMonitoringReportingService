using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WeatherMonitoringReportingService.Data;

namespace WeatherMonitoringReportingService.DataFiles
{
    public class JSONParser : IWeatherParser
    {
        public WeatherData Parse(string fileName)
        {
            if (!File.Exists(fileName))
            {
                throw new FileNotFoundException("JSON file not found.", fileName);
            }

            using (StreamReader reader = new StreamReader(fileName))
            {
                string jsonData = reader.ReadToEnd();

                WeatherData weatherData = JsonSerializer.Deserialize<WeatherData>(jsonData);

                return weatherData;
            }
        }
    }
}
