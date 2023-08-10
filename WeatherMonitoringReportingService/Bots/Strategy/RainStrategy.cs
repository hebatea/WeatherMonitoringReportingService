using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherMonitoringReportingService.Data;

namespace WeatherMonitoringReportingService.Bots.Strategy
{
    internal class RainStrategy: IWeatherStrategy
    {
        public void CheckActivation(WeatherData weatherData, ConfigurationData configurationData)
        {
            if (configurationData.Enabled)
            {
                if (weatherData.Temperature > configurationData.HumidityThreshold)
                {
                    Console.WriteLine("RainBot Activated!");
                    Console.WriteLine(configurationData.Message);
                }
            }
        }
    }
}
