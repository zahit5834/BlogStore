using BlogStore.BusinessLayer.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using BlogStore.BusinessLayer.Abstract;
using System.Text.Json.Serialization;

namespace BlogStore.BusinessLayer.Services
{
    public class ToxicityChecker: IToxicityChecker
    {
        private readonly string _apiKey;
        private readonly HttpClient _httpClient;

        public ToxicityChecker(HttpClient httpClient, IOptions<HuggingSettings> options)
        
        {
            _httpClient = httpClient; 
            _apiKey = options.Value.ApiKey;

            _httpClient.DefaultRequestHeaders.Authorization =
            new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _apiKey);
        }
        public async Task<bool> IsToxicAsync(string comment)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://api-inference.huggingface.co/models/unitary/toxic-bert"),
                Headers = {
                { "Authorization", $"Bearer {_apiKey}" }
            },
                Content = new StringContent(JsonSerializer.Serialize(new { inputs = comment }), Encoding.UTF8, "application/json")
            };

            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();

            // Çıktıyı deserialize et
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var result = JsonSerializer.Deserialize<List<List<Prediction>>>(json, options);

            // İlk skoru kontrol et (genelde 0.5 üstü ise toxic kabul edilir)
            var score = result?[0]?[0]?.Score ?? 0;

            return score >= 0.5;
        }
        private class Prediction
        {
            [JsonPropertyName("label")]
            public string Label { get; set; }

            [JsonPropertyName("score")]
            public float Score { get; set; }
        }
    }
}

// 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