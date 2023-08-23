using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherMonitoringReportingService.Data;

namespace WeatherMonitoringReportingService.Bots.Strategy
{
    public class RainStrategy: IWeatherStrategy
    {
        public bool CheckActivation(WeatherData weatherData, ConfigurationData configurationData)
        {
            if (configurationData.Enabled)
            {
                if (weatherData.Humidity > configurationData.HumidityThreshold)
                {
                    Console.WriteLine("RainBot Activated!");
                    Console.WriteLine(configurationData.Message);
                    return true;
                }
            }
            return false;
        }
    }
}
