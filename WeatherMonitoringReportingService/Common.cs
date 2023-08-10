using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherMonitoringReportingService
{
    public static class Common
    {
        public const string weatherDataTag = "//WeatherData";
        public const string locationTag = "Location";
        public const string temperatureTag = "Temperature";
        public const string humidityTag = "Humidity";
        
        public enum IntOrDouble
        {
            integern = 0,
            doublen = 1
        }

        public enum WhichParser
        {
            XML = 1,
            JSON = 2,
        }
        
        public enum Bots
        {
            RainBot,
            SunBot,
            SnowBot
        }

        static Dictionary<string, Bots> botsDictionary = new Dictionary<string, Bots>
        {
            { "RainBot", Bots.RainBot },
            { "SunBot", Bots.SunBot  },
            { "SnowBot", Bots.SnowBot  }
        };

        public static double HandleIntUserInput(int IsIntOrDouble, int? StartRange = null, int? EndRange = null)
        {
            double output;
            int intOutput;
            bool isVaild = false;
            do
            {
                switch (IsIntOrDouble)
                {
                    case (int)IntOrDouble.integern:

                        string userInput = Console.ReadLine();
                        if (int.TryParse(userInput, out intOutput))
                        {
                            isVaild = IsInRange(intOutput, StartRange, EndRange);
                            if (isVaild)
                                return intOutput;
                            else
                            {
                                Console.WriteLine($"Please Enter Value between {StartRange} and {EndRange}");
                            }

                        }
                        else
                        {
                            Console.WriteLine("Invalid input! Please enter a valid integer value.");
                        }


                        break;

                    case (int)IntOrDouble.doublen:
                        userInput = Console.ReadLine();
                        if (double.TryParse(userInput, out output))
                        {
                            isVaild = true;
                            return output;
                        }
                        else
                        {
                            Console.WriteLine("Invalid input! Please enter a valid double value.");
                        }
                        break;

                    default:
                        break;
                }
            } while (!isVaild);
            return -1;
        }

        private static bool IsInRange(int input, int? StartRange = null, int? EndRange = null)
        {
            if (StartRange == null) return true;
            if (StartRange != null && EndRange != null)
            {
                if (input >= StartRange && input <= EndRange) return true;
            }
            return false;
        }
    }
}
