using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherMonitoringReportingService.Data;

namespace WeatherMonitoringReportingService.Bots
{
    public class WeatherObserver : IWeatherObserver
    {
        List<IWeatherBot> _observers;

        public WeatherObserver()
        {
            _observers = new List<IWeatherBot>();
        }

        public void NotifyObserver(WeatherData weatherData)
        {
            foreach (var observer in _observers)
            {
                observer.Update(weatherData);
            }
        }

        public void RegisterObserver(IWeatherBot weatherBot)
        {
            _observers.Add(weatherBot);
        }

        public void RemoveObserver(IWeatherBot weatherBot)
        {
            _observers.Add(weatherBot);
        }
    }
}
