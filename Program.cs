using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace RecordTypesWithLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            List<WeatherForecast> dailyWeather = new();

            dailyWeather.Add(new WeatherForecast(DateTime.Parse("2019-08-01"), 25, "Hot"));
            dailyWeather.Add(new WeatherForecast(DateTime.Parse("2019-08-02"), 22, "Cold"));
            dailyWeather.Add(new WeatherForecast(DateTime.Parse("2019-08-03"), 27, "Warm"));
            dailyWeather.Add(new WeatherForecast(DateTime.Parse("2019-08-04"), 29, "Sunny"));
            dailyWeather.Add(new WeatherForecast(DateTime.Parse("2019-08-05"), 26, "Bright"));

            string dailyWeatherJsonString = JsonSerializer.Serialize(dailyWeather);
            var dailyJsonString = JsonSerializer.Serialize(new DailyForcast(dailyWeather));

            Console.WriteLine(dailyWeatherJsonString);
            Console.WriteLine(dailyJsonString);

            var dWeather = JsonSerializer.Deserialize<DailyForcast>(dailyJsonString);

            var summary = dWeather.Weather.Select(e => e.Summary);

            var tempCountGreaterThan = dWeather.Weather.Where(e => e.TemperatureCelsius > 25).Count();

            Console.WriteLine(tempCountGreaterThan);

            Console.WriteLine(Regex.Unescape(FancyJson.Json));

            var fancyJson = JsonSerializer.Deserialize<DailyForcast>(Regex.Unescape(FancyJson.Json));

            foreach (var su in summary)
            {
                Console.WriteLine(su);
            }

            foreach (var fa in fancyJson.Weather)
            {
                ErrorsJumble.JsonFake(fa.Summary);
                Console.WriteLine(fa);
            }
        }
    }
}
