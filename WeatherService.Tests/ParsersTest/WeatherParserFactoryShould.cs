using FluentAssertions;
using System;
using System.IO;
using WeatherMonitoringReportingService;
using WeatherMonitoringReportingService.DataFiles;
using WeatherMonitoringReportingService.Parsers;
using Xunit;

namespace WeatherService.Tests
{
    public class WeatherParserFactoryShould
    {
        [Fact]  
        public void returnJSONParserObjectWhenJsonParserNeeded()
        {
            var jsonParser = WeatherParserFactory.GetWeatherParser(Common.WhichParser.JSON);
            Assert.NotNull(jsonParser);
            jsonParser.Should().BeOfType<JSONParser>();
        }

        [Fact]
        public void returnXMLParserObjectWhenXMLParserNeeded()
        {
            var xmlParser = WeatherParserFactory.GetWeatherParser(Common.WhichParser.XML);
            Assert.NotNull(xmlParser);
            xmlParser.Should().BeOfType<XMLParser>();
        }

        [Fact]
        public void returnNullWhenOtherCases()
        {
            var parser = WeatherParserFactory.GetWeatherParser(Common.WhichParser.TEST);
            Assert.Null(parser);
        }
    }
}
