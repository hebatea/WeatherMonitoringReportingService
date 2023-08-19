using Moq;
using System.Runtime.InteropServices;
using WeatherMonitoringReportingService.Bots;
using WeatherMonitoringReportingService.Data;
using Xunit;
namespace WeatherService.Tests.BotsTest
{
    public class WeatherObserverShould
    {
        private readonly Mock<IWeatherObserver> weatherObserver;
        private readonly Mock<IWeatherStrategy> mockWeatherStrategy;
        private readonly SunBot weatherBot;
        private readonly WeatherData weatherData;

        public WeatherObserverShould()
        {
            weatherObserver = new Mock<IWeatherObserver>();
            mockWeatherStrategy = new Mock<IWeatherStrategy>();

            weatherBot = new SunBot(mockWeatherStrategy.Object, new ConfigurationData());
            weatherData = new WeatherData();
        }

        [Fact]
        public void RegisterObserver()
        {
            weatherObserver.Object.RegisterObserver(weatherBot);

            weatherObserver.Verify(o => o.RegisterObserver(weatherBot), Times.Once);
        }

        [Fact]
        public void NotifyObserver()
        {
            weatherObserver.Object.NotifyObserver(weatherData);

            weatherObserver.Verify(o => o.NotifyObserver(weatherData), Times.Once);
        }

        [Fact]
        public void RemoveObserver()
        {
            weatherObserver.Object.RemoveObserver(weatherBot);

            weatherObserver.Verify(o => o.RemoveObserver(weatherBot), Times.Once);
        }
    }
}
