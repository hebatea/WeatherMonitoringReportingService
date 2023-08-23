using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherMonitoringReportingService.Data;

namespace WeatherMonitoringReportingService.Bots.Observers
{
    public interface IWeatherBot
    {
        public void Update(WeatherData data);
    }
}
