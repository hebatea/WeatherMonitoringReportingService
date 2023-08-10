using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Xml.Linq;
using WeatherMonitoringReportingService.Bots;
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
                
                WriteWeclomingAndChoicesInConsole();

                int number = (int)Common.HandleIntUserInput((int)IntOrDouble.integern, 1, 3);

                if (number == 3) break;


                Console.WriteLine("Please Enter the File Path for Weather Parser: ");

                string fileName = Console.ReadLine();

                IWeatherParser weatherParser = WeatherParserFactory.GetWeatherParser((Common.WhichParser) number);
                try
                {

                    WeatherData weatherData = weatherParser.Parse(@fileName);
                    Console.WriteLine(weatherData + "\n");
                    DealingWithConfiguration(weatherData);
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
            Console.WriteLine("****************       1. Load from XML      *******************");
            Console.WriteLine("****************       2. Load from JSON     *******************");
            Console.WriteLine("****************       3. Exsit     *******************");
            Console.WriteLine("****************************************************************");
        }

        private static void DealingWithConfiguration(WeatherData weatherData)
        {
            Console.WriteLine("Please Enter the File Path for Configuration: ");
            string fileName = Console.ReadLine();

            IConfigurationParser configurationParser = new JSONConfigurationParser();
            Dictionary<Common.Bots, ConfigurationData> configurationsDictionary = configurationParser.ParseConfiguration(fileName);
            WeatherObserver weatherObserver = new WeatherObserver();

            foreach (var botConfigurationPair in configurationsDictionary)
            {
                var bot = botConfigurationPair.Key;
                var configuration = botConfigurationPair.Value;

                WeatherBot weatherBot = WeatherBotsFactory.GetWeatherBot(bot, configuration);

                weatherObserver.RegisterObserver(weatherBot);

            }

            weatherObserver.NotifyObserver(weatherData);
        }
    }
}
