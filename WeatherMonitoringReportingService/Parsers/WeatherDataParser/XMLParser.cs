using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using WeatherMonitoringReportingService.Data;

namespace WeatherMonitoringReportingService.DataFiles
{
    public class XMLParser : IWeatherParser
    {
        public WeatherData Parse(string fileName)
        {
            if (!File.Exists(fileName))
            {
                throw new FileNotFoundException($"XML file not found {fileName}.", fileName);
            }

            XmlDocument xmlDoc = new XmlDocument();

            xmlDoc.Load(fileName);

            var weatherDataNode = xmlDoc.SelectNodes(Common.weatherDataTag)[0];

            string location = weatherDataNode.SelectSingleNode("Location").InnerText;
            double temperature = double.Parse(weatherDataNode.SelectSingleNode("Temperature").InnerText);
            double humidity = double.Parse(weatherDataNode.SelectSingleNode("Humidity").InnerText);

            WeatherData weatherData = new WeatherData
            {
                Location = location,
                Temperature = temperature,
                Humidity = humidity
            };

            return weatherData;
        }
    }
}
