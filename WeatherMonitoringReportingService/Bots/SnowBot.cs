﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherMonitoringReportingService.Data;

namespace WeatherMonitoringReportingService.Bots
{
    public class SnowBot : IWeatherBot, IWeatherStrategy
    {
        
        public void Update(WeatherData data)
        {
            throw new NotImplementedException();
        }

        public void CheckActivation(WeatherData weatherData, ConfigurationData configurationData)
        {
            if (configurationData.Enabled)
            {
                if (weatherData.Temperature < configurationData.TemperatureThreshold)
                {
                    Console.WriteLine("SnowBot Activated!");
                    Console.WriteLine(configurationData.Message);
                }
            }
        }
    }
}
