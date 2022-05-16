using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace MintClientControl.Models
{
    public enum Rights
    {
        Admin,
        Moderator
    }
    public class Functions
    {
        public int FuncId { get; set; }
        public string Title { get; set; }
        public string Command { get; set; }
        public int UserId { get; set; }
        public Rights FuncRights { get; set; }
    }
    public interface IFunctionDataModel
    {
        Task<Functions[]> RetrieveFunctionsAsync();
    }
    public class FunctionDataModel : IFunctionDataModel
    {
        private HttpClient _http;
        public FunctionDataModel(HttpClient http)
        {
            _http = http;
        }

        public async Task<Functions[]> RetrieveFunctionsAsync()
        {
            return await _http.GetFromJsonAsync<Functions[]>("sample-data/Functions.json");
        }
    }
}
