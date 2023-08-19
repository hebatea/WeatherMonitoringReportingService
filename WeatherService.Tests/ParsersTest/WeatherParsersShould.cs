using FluentAssertions;
using Moq;
using System;
using System.IO;
using WeatherMonitoringReportingService.Data;
using WeatherMonitoringReportingService.DataFiles;
using Xunit;

namespace WeatherMonitoringReportingService.Tests.Parsers.Test
{
    public class WeatherParsersShould
    {
        [Fact]
        public void CallParseOnce()
        {
            Mock<IWeatherParser> mockParser = new Mock<IWeatherParser>();
           
            mockParser.Setup(x => x.Parse(It.IsAny<string>())).
                Returns(new WeatherData {});

            mockParser.Object.Parse("Anything");

            mockParser.Verify(parser => parser.Parse(It.IsAny<string>()), Times.Once());
        }
        
        [Fact]
        public void ParseXMLFile()
        {
            string fullPath = GiveFullPath(@"weatherdata.xml");

            var xmlParser = new XMLParser();
            var weatherData = xmlParser.Parse(fullPath);

            Assert.NotNull(weatherData);
            weatherData.Location.Should().Be("Khanyounis");
            weatherData.Temperature.Should().Be(-1);
            weatherData.Humidity.Should().Be(90);
        }

        [Fact]
        public void ThrowExceptionIfTheXmlFileDoesnotExsit()
        {
            string fileName = "C:\\Users\\Heba Ashour\\source\\ParsersTest\\weatherdata.xml";

            var xmlParser = new XMLParser();

            Action action = () => xmlParser.Parse(fileName);
            action.Should().Throw<FileNotFoundException>();

        }


        [Fact]
        public void ParseJsonFile()
        {
            string fullPath = GiveFullPath(@"weatherdata.json");

            var jsonParser = new JSONParser();
            var weatherData = jsonParser.Parse(fullPath);

            Assert.NotNull(weatherData);
            weatherData.Location.Should().Be("Khanyounis");
            weatherData.Temperature.Should().Be(-1);
            weatherData.Humidity.Should().Be(90);
        }

        private static string GiveFullPath(string fileName)
        {
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string fullPath = Path.Combine(basePath, fileName);
            return fullPath;
        }

        [Fact]
        public void ThrowExceptionIfTheJsonFileDoesnotExsit()
        {
            string fileName = "C:\\Users\\Heba Ashour\\source\\repos\\WeatherMonitoringReportingService\\WeatherService.Tests\\ihewjl.xml";

            var xmlParser = new XMLParser();

            Action action = () => xmlParser.Parse(fileName);
            action.Should().Throw<FileNotFoundException>();

        }


    }
}
