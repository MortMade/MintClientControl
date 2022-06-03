using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace MintClientControl
{
    public class PersistenceService<T>
    {
        const string serverURL = "https://mintcontrolapi.azurewebsites.net/";
        static HttpClient client = new HttpClient();

        public static async Task<List<T>> GetData(string controllerName)
        {
            return await client.GetFromJsonAsync<List<T>>(serverURL+controllerName);
        }

        public static async Task<Uri> PostData(T valueToAdd, string controllerName)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync(serverURL + controllerName, valueToAdd);
            return response.Headers.Location;
        }

        public static async Task<Uri> UpdateData(T valueToUpdate, string controllerName)
        {
            HttpResponseMessage response = await client.PutAsJsonAsync(serverURL + controllerName, valueToUpdate);
            return response.Headers.Location;
        }

        public static async Task DeleteData(string controllerName)
        {
            await client.DeleteAsync(serverURL + controllerName);
        }
    }
}
