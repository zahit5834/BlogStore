using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.Extensions.Options;
using BlogStore.BusinessLayer.Configuration;

namespace BlogStore.BusinessLayer.Services
{
    public class GoogleTranslateService
    {
        private readonly HttpClient _httpClient;

        public GoogleTranslateService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> TraslateToEngAsync(string text)
        {
            var url = $"https://translation.googleapis.com/language/translate/v2?key=AIzaSyDBeRNB4qRGBXuy4JZxpUpu9WqR9Hz8WGA";

            var requestBody = new
            {
                q = text,
                source = "tr",
                target = "en",
                format = "text"
            };

            var jsonContent = new StringContent(JsonConvert.SerializeObject(requestBody), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(url, jsonContent);
            if (!response.IsSuccessStatusCode)
                return text; // Çeviri başarısızsa orijinal metni döndür

            var json = await response.Content.ReadAsStringAsync();
            dynamic result = JsonConvert.DeserializeObject(json);

            string translatedText = result.data.translations[0].translatedText;
            return translatedText;
        }
    }
}
//AIzaSyDBeRNB4qRGBXuy4JZxpUpu9WqR9Hz8WGA