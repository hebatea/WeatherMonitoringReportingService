using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Xml.Linq;
using WeatherMonitoringReportingService.Data;
using WeatherMonitoringReportingService.DataFiles;
using WeatherMonitoringReportingService.Parsers;
using WeatherMonitoringReportingService.Parsers.ConfigurationParser;
using static WeatherMonitoringReportingService.Common;

namespace WeatherMonitoringReportingService
{
    public class Program
    {
        static void Main(string[] args)
        {

            while (true)
            {
                JSONConfigurationParser js = new JSONConfigurationParser();
                js.ParseConfiguration("C:\\Users\\Heba Ashour\\source\\repos\\WeatherMonitoringReportingService\\WeatherMonitoringReportingService\\Data\\Configurations.json");
                WriteWeclomingAndChoicesInConsole();

                int number = (int)Common.HandleIntUserInput((int)IntOrDouble.integern, 1, 3);

                if (number == 3) break;


                Console.WriteLine("Please Enter the File Path");

                string fileName = Console.ReadLine();

                IWeatherParser weatherParser = WeatherParserFactory.GetWeatherParser((Common.WhichParser) number);
                try
                {
                    WeatherData weatherData = weatherParser.Parse(@fileName);
                    Console.WriteLine(weatherData);

                }
                catch (FileNotFoundException fileNotFoundException)
                {
                    Console.WriteLine(fileNotFoundException.Message);
                }

            }

        }

        private static void WriteWeclomingAndChoicesInConsole()
        {
            Console.WriteLine("****************************************************************");
            Console.WriteLine("****** Welcome to Weather Monitoring Reporting Service *********");
            // TODO : Make it automatic using reflection
            Console.WriteLine("****************       1. Load from XML      *******************");
            Console.WriteLine("****************       2. Load from JSON     *******************");
            Console.WriteLine("****************       3. Exsit     *******************");
            Console.WriteLine("****************************************************************");
        }
    }
}
