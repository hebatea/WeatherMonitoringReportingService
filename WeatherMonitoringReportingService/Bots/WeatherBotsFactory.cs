using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherMonitoringReportingService.Bots.Strategy;
using WeatherMonitoringReportingService.Data;
using WeatherMonitoringReportingService.DataFiles;

namespace WeatherMonitoringReportingService.Bots
{
    public class WeatherBotsFactory
    {
        public static WeatherBot GetWeatherBot(Common.Bots botName, ConfigurationData configuration)
        {
            WeatherBot weatherBot = null;
            IWeatherStrategy strategy = null;
            
            if (botName.Equals(Common.Bots.RainBot))
            {
                strategy = new RainStrategy();
                weatherBot = new RainBot(strategy, configuration);
            }
            else if (botName.Equals(Common.Bots.SnowBot))
            {
                strategy = new SnowStrategy();
                weatherBot = new SnowBot(strategy, configuration);
            }
            else if (botName.Equals(Common.Bots.SunBot))
            {
                strategy = new SunStrategy();
                weatherBot = new SunBot(strategy, configuration);
            }

            return weatherBot;
        }
    }
}
