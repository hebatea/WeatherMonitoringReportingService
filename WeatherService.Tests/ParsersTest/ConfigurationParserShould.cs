using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using WeatherMonitoringReportingService;
using WeatherMonitoringReportingService.Data;
using WeatherMonitoringReportingService.DataFiles;
using WeatherMonitoringReportingService.Parsers;
using Xunit;
using FluentAssertions;
using WeatherMonitoringReportingService.Parsers.ConfigurationParser;

namespace WeatherService.Tests
{
    public class ConfigurationParserShould
    {
        [Fact]
        public void CallParseOnce()
        {
            Mock<IConfigurationParser> mockParser = new Mock<IConfigurationParser>();

            mockParser.Setup(x => x.ParseConfiguration(It.IsAny<string>())).
                Returns(new Dictionary<Common.Bots, ConfigurationData>());

            mockParser.Object.ParseConfiguration("Anything");

            mockParser.Verify(parser => parser.ParseConfiguration(It.IsAny<string>()), Times.Once());

        }

        [Fact]
        public void ParseConfiguartionFile()
        {
            string fileName = "C:\\Users\\Heba Ashour\\source\\repos\\WeatherMonitoringReportingService\\WeatherService.Tests\\Configurations.json";

            var configurationParser = new JSONConfigurationParser();
            var configuartionData = configurationParser.ParseConfiguration(fileName);
            var keyList = new List<Common.Bots> { Common.Bots.RainBot, Common.Bots.SunBot, Common.Bots.SnowBot };
            List<ConfigurationData> valueList = new List<ConfigurationData>
            {
                new ConfigurationData { Enabled = true, HumidityThreshold = 70, Message = "It looks like it's about to pour down!" },
                new ConfigurationData { Enabled = true, TemperatureThreshold = 30, Message = "Wow, it's a scorcher out there!" },
                new ConfigurationData { Enabled = true, TemperatureThreshold = 0, Message = "Brrr, it's getting chilly!" }
            };


            Assert.NotNull(configuartionData);
            configuartionData.Keys.Should().BeEquivalentTo(keyList);

            configuartionData.Values.Should().BeEquivalentTo(valueList);

        }

        [Fact]
        public void ThrowExceptionIfTheXmlFileDoesnotExsit()
        {
            string fileName = "C:\\Users\\Heba Ashour\\source\\ParsersTest\\Configurations.json";

            var configurationParser = new JSONConfigurationParser();

            Action action = () => configurationParser.ParseConfiguration(fileName);
            action.Should().Throw<FileNotFoundException>();

        }

    }
}
