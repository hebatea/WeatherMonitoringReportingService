using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherMonitoringReportingService.DataFiles;

namespace WeatherMonitoringReportingService.Parsers
{
    public class WeatherParserFactory
    {
        public static IWeatherParser GetWeatherParser(Common.WhichParser parser)
        {
            // TODO : Make it automatic using reflection

            IWeatherParser weatherParser = null;
            if (parser.Equals(Common.WhichParser.JSON))
            {
                weatherParser = new JSONParser();
            }
            else if (parser.Equals(Common.WhichParser.XML))
            {
                weatherParser = new XMLParser();
            }

            return weatherParser;
        }
        
    }
}
