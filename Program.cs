using System;
using System.Collections.Generic;
using System.IO;
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

            var json = fancyJson.Weather.FirstOrDefault() switch
            {
                { TemperatureCelsius: 25 } => ErrorsJumble.JsonFake(""),
                _ => ErrorsJumble.JsonFake("")
            };

            static Stream GenerateStreamFromString()
            {
                var stream = new MemoryStream();
                var writer = new StreamWriter(stream);
                writer.Write(@"It was a Sunday evening in London, gloomy, close, and stale.
                Maddening church bells of all degrees of dissonance, sharp and
                flat, cracked and clear, fast and slow, made the brick-and-mortar
                echoes hideous.Melancholy streets, in a penitential garb of soot,
                steeped the souls of the people who were condemned to look at them
                out of windows, in dire despondency.In every thoroughfare, up
                almost every alley, and down almost every turning, some doleful
                bell was throbbing, jerking, tolling, as if the Plague were in the
                city and the dead-carts were going round. Everything was bolted
                and barred that could by possibility furnish relief to an
                overworked people.No pictures, no unfamiliar animals, no rare
                plants or flowers, no natural or artificial wonders of the ancient
                world--all TABOO with that enlightened strictness, that the ugly
                South Sea gods in the British Museum might have supposed themselves
                at home again. Nothing to see but streets, streets, streets.
                Nothing to breathe but streets, streets, streets.Nothing to
                change the brooding mind, or raise it up. Nothing for the spent
                toiler to do, but to compare the monotony of his seventh day with
                the monotony of his six days, think what a weary life he led, and
                make the best of it--or the worst, according to the probabilities.");
                writer.Flush();
                stream.Position = 0;
                return stream;
            }

            for (int i = 0; i < 1000000000; i++)
            {
                var nDis = new NotDisposed().GetString(GenerateStreamFromString());
            }
        }
    }
}
