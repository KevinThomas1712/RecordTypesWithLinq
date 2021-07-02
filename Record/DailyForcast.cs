using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace RecordTypesWithLinq
{
    internal record DailyForcast([property: JsonPropertyName("Weather")] List<WeatherForecast> Weather);
}
