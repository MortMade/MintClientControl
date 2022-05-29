using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace MintClientControl.Models
{
    public class Users
    {
        public long UserId { get; set; }
        public string Username { get; set; }

    }
    public interface IUserDataModel
    {
        Task<List<Users>> RetrieveForecastsAsync();
    }

    public class UserDataModel : IUserDataModel
    {
        private HttpClient _http;
        public UserDataModel(HttpClient http)
        {
            _http = http;
        }
        public async Task<List<Users>> RetrieveForecastsAsync()
        {
            return await _http.GetFromJsonAsync<List<Users>>("https://mintcontrolapi.azurewebsites.net/api/Users");
        }
    }

}
