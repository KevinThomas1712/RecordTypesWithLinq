using System;
using System.Text.Json.Serialization;

namespace RecordTypesWithLinq
{
    // [property: JsonPropertyName("quotes")] 
    internal record WeatherForecast([property: JsonPropertyName("date")] DateTime Date,
        [property: JsonPropertyName("temperature-celsius")] int? TemperatureCelsius,
        [property: JsonPropertyName("summary")] string Summary);
}