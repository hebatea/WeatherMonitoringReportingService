using WeatherMonitoringReportingService;
using WeatherMonitoringReportingService.Bots;
using WeatherMonitoringReportingService.Data;
using Xunit;
using static WeatherMonitoringReportingService.Common;
using FluentAssertions;

namespace WeatherService.Tests.BotsTest
{
    public class WeatherBotFactoryShould
    {
        [Fact]
        public void returnRainBotObjectWhenRainBotNeeded()
        {
            var rainBot = WeatherBotsFactory.GetWeatherBot(Bots.RainBot, new ConfigurationData());
            Assert.NotNull(rainBot);
            rainBot.Should().BeOfType<RainBot>();
        }

        [Fact]
        public void returnSnowBotObjectWhenSnowBotNeeded()
        {
            var snowBot = WeatherBotsFactory.GetWeatherBot(Bots.SnowBot, new ConfigurationData());
            Assert.NotNull(snowBot);
            snowBot.Should().BeOfType<SnowBot>();
        }

        [Fact]
        public void returnSunBotObjectWhenSunBotNeeded()
        {
            var sunBot = WeatherBotsFactory.GetWeatherBot(Bots.SunBot, new ConfigurationData());
            Assert.NotNull(sunBot);
            sunBot.Should().BeOfType<SunBot>();
        }
    }
}
