using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Adapter
{
    public class Program
    {
        static void Main(string[] args)
        {
            WeatherForecast weatherForecast = new WeatherForecast()
            {
                ExceptionCode = "3000",
                ExceptionMessage = "county code is not found"
            };


            ILogger[] loggers =
            {
                new FileLogger() {Message = "File not found", Code = "404", Priority = 5},
                new ServiceLogger() {Message = "services failed", Code = "500", Priority = 4},
                new WeatherForecastLoggerAdapter(weatherForecast),
            };

            foreach (ILogger logger in loggers)
            {
                logger.Write();
            }
        }
    }

    public interface ILogger
    {
        string Message { get; set; }
        string Code { get; set; }
        int Priority { get; set; }
        void Write();
    }

    public class FileLogger : ILogger
    {
        public string Message { get; set; }
        public string Code { get; set; }
        public int Priority { get; set; }
        public void Write()
        {
            Console.WriteLine("Message:{0} \n Code:{1} \n Priority:{2}", this.Message, 
                                                                         this.Code, 
                                                                         this.Priority);
        }
    }

    public class ServiceLogger : ILogger
    {
        public string Message { get; set; }
        public string Code { get; set; }
        public int Priority { get; set; }
        
        public string ServiceName { get; set; }
        public string ServiceUrl { get; set; }

        public void Write()
        {
            Console.WriteLine("Message:{0} \n Code:{1} \n Priority:{2} \n ServiceName:{3} \n ServiceUrl:{4}", this.Message,
                                                                                                              this.Code,
                                                                                                              this.Priority, 
                                                                                                              this.ServiceName, 
                                                                                                              this.ServiceUrl);
        }
    }

    public class WeatherForecastLoggerAdapter : ILogger
    {
        public string Message { get; set; }
        public string Code { get; set; }
        public int Priority { get; set; }

        private WeatherForecast _weatherForecast;

        public WeatherForecastLoggerAdapter(WeatherForecast weatherForecast)
        {
            _weatherForecast = weatherForecast;
        }
        
        public void Write()
        {
            Console.WriteLine("Message:{0} \n Code:{1} \n Priority:{2} \n ExceptionMessage:{3} \n ExceptionCode:{4}", this.Message,
                                                                                                                      this.Code,
                                                                                                                      this.Priority,
                                                                                                                      this._weatherForecast.ExceptionMessage,
                                                                                                                      this._weatherForecast.ExceptionCode);
        }
    }

    public class WeatherForecast
    {
        public string ExceptionMessage { get; set; }
        public string ExceptionCode { get; set; }

        public List<Weather> WeathersByCountyCode(string countyCode)
        {
            Console.WriteLine("Return of County of Weather");
            return new List<Weather>();
        }
    }

    public class Weather
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public string CityCode { get; set; }
        public string CountyCode { get; set; }
    }
}
