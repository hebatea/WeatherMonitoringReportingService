﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherMonitoringReportingService.Data;

namespace WeatherMonitoringReportingService.Bots
{
    public interface IWeatherStrategy
    {
        public bool CheckActivation(WeatherData weatherData,ConfigurationData configurationData);
    }
}
