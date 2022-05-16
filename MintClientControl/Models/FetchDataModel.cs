using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace MintClientControl.Models
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public string Summary { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
    }
    public interface IFetchDataModel
    {
        Task<WeatherForecast[]> RetrieveForecastsAsync();
    }
    public class FetchDataModel : IFetchDataModel
    {
        private HttpClient _http;
        public FetchDataModel(HttpClient http)
        {
            _http = http;
        }
        public async Task<WeatherForecast[]> RetrieveForecastsAsync()
        {
            return await _http.GetFromJsonAsync<WeatherForecast[]>("sample-data/weather.json");
        }
    }
}
