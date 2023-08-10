using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherMonitoringReportingService.Data;

namespace WeatherMonitoringReportingService.Bots
{
    public interface IWeatherObserver
    {
        void RegisterObserver(IWeatherBot weatherBot);
        void RemoveObserver(IWeatherBot weatherBot);
        void NotifyObserver(WeatherData weatherData);
    }
}
