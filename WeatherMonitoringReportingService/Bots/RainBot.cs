﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherMonitoringReportingService.Data;

namespace WeatherMonitoringReportingService.Bots
{
    public class RainBot : WeatherBot
    {
        public RainBot(IWeatherStrategy strategy, ConfigurationData configuration) : base(strategy, configuration)
        {
        }

        public override void Update(WeatherData data)
        {
            _strategy.CheckActivation(data, _configuration);
        }

       
    }
}
