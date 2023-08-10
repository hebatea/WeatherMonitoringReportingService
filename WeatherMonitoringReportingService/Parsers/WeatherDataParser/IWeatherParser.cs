using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherMonitoringReportingService.Data;

namespace WeatherMonitoringReportingService.DataFiles
{
    public interface IWeatherParser
    {
        public WeatherData Parse(string fileName);
    }
}
