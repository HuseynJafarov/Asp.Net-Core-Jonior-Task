using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ToDo.Core.Data;
using ToDo.Core.Entities;

namespace ToDo.Helpers
{
    public static class ConvertJsonToObject
    {
        private static readonly HttpClient _httpClient = new HttpClient();

        public static async Task<T> JsonDeserialize<T>(string url)
        {
            var json = await _httpClient.GetStringAsync(url);
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
