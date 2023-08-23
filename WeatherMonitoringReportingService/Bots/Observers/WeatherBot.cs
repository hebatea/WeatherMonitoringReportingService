using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherMonitoringReportingService.Bots.Observers;
using WeatherMonitoringReportingService.Data;

namespace WeatherMonitoringReportingService.Bots
{
    public abstract class WeatherBot : IWeatherBot
    {
        protected IWeatherStrategy _strategy;
        protected ConfigurationData _configuration;

        public WeatherBot(IWeatherStrategy behavior, ConfigurationData configuration)
        {
            _strategy = behavior;
            _configuration = configuration;
        }

        public abstract void Update(WeatherData data);

    }
    
}
