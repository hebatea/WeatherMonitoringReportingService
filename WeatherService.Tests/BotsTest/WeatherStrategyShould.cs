using FluentAssertions;
using Moq;
using System.Collections.Generic;
using WeatherMonitoringReportingService.Bots;
using WeatherMonitoringReportingService.Bots.Strategy;
using WeatherMonitoringReportingService.Data;
using Xunit;

namespace WeatherService.Tests
{
    public class WeatherStrategyShould
    {
        [Fact]
        public void CallParseOnce()
        {
            Mock<IWeatherStrategy> mockStrategy = new Mock<IWeatherStrategy>();

            mockStrategy.Object.CheckActivation(new WeatherData(), new ConfigurationData());

            mockStrategy.Verify(
                strategy => strategy.CheckActivation(It.IsAny<WeatherData>(), It.IsAny<ConfigurationData>()), 
                Times.Once());

        }

        [Theory]
        [InlineData(false, 80, 70, false)]
        [InlineData(false, 70, 80, false)]
        [InlineData(true, 80, 70, true)]
        [InlineData(true, 70, 80, false)]
        public void CheckActivationRainStrategy(bool enabled, double weatherHumidity,
            double configuarationHumidity, bool expectedResult)
        {
            // Arrange
            var rainStrategy = new RainStrategy();
            var weatherData = new WeatherData { Humidity = weatherHumidity };
            var configuration = new ConfigurationData
            {
                Enabled = enabled,
                HumidityThreshold = configuarationHumidity
            };

            // Act 
            var isActivited = rainStrategy.CheckActivation(weatherData, configuration);

            // Assert 
            isActivited.Should().Be(expectedResult);

        }


        [Theory]
        [InlineData(false, 80, 70, false)]
        [InlineData(false, 70, 80, false)]
        [InlineData(true, 70, 80, true)]
        [InlineData(true, 80, 70, false)]
        public void CheckActivationSnowStrategy(bool enabled, double weatherTemperature,
            double configuarationTemperature, bool expectedResult)
        {
            // Arrange
            var snowStrategy = new SnowStrategy();
            var weatherData = new WeatherData { Temperature = weatherTemperature };
            var configuration = new ConfigurationData
            {
                Enabled = enabled,
                TemperatureThreshold = configuarationTemperature
            };

            // Act 
            var isActivited = snowStrategy.CheckActivation(weatherData, configuration);

            isActivited.Should().Be(expectedResult);

        }


        [Theory]
        [InlineData(false, 80, 70, false)]
        [InlineData(false, 70, 80, false)]
        [InlineData(true, 80, 70, true)]
        [InlineData(true, 70, 80, false)]
        public void CheckActivationSunStrategy(bool enabled, double weatherTemperature,
            double configuarationTemperature, bool expectedResult)
        {
            // Arrange
            var sunStrategy = new SunStrategy();
            var weatherData = new WeatherData { Temperature = weatherTemperature };
            var configuration = new ConfigurationData
            {
                Enabled = enabled,
                TemperatureThreshold = configuarationTemperature
            };

            // Act 
            var isActivited = sunStrategy.CheckActivation(weatherData, configuration);

            isActivited.Should().Be(expectedResult);

        }
    }
}
