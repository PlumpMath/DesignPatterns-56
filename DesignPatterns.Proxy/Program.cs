using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Proxy
{
    class Program
    {
        static void Main(string[] args)
        {
            WSWeatherForecastClientProxy proxy = new WSWeatherForecastClientProxy("username", "userpassword");
            proxy.WeathersByCountyCode("90");
            proxy.WeathersByCountyCode("90");
            proxy.WeathersByCountyCode("90");
        }
    }

    public class Weather
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public string CityCode { get; set; }
        public string CountyCode { get; set; }
    }

    public abstract class WSWeatherForecastClient
    {
        public abstract List<Weather> WeathersByCountyCode(string countyCode);
    }

    public class WSWeatherForecast : WSWeatherForecastClient
    {
        public string ExceptionMessage { get; set; }
        public string ExceptionCode { get; set; }
        public List<Weather> Weathers { get; set; }

        public string WSUserName { get; set; }
        public string WSUserPassword { get; set; }

        public override List<Weather> WeathersByCountyCode(string countyCode)
        {
            Console.WriteLine("Return of County of Weather");
            return Weathers;
        }
    }

    public class WSWeatherForecastClientProxy : WSWeatherForecastClient
    {
        public string WSUserName { get; set; }
        public string WSUserPassword { get; set; }

        private WSWeatherForecast weatherForecast;
        public WSWeatherForecastClientProxy(string userName, string userPassword)
        {
            this.WSUserName = userName;
            this.WSUserPassword = userPassword;
        }

        public override List<Weather> WeathersByCountyCode(string countyCode)
        {
            if (this.weatherForecast == null)
            {
                Console.WriteLine("Connecting");
                this.weatherForecast = new WSWeatherForecast();
            }

            return weatherForecast.WeathersByCountyCode(countyCode);
        }
    }
}
