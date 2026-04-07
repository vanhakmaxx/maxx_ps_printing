using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Windows.Forms;

namespace maxx_pos.Services
{
    public class ApiService
    {
        private readonly string baseUrl;
        private readonly string token;
        private readonly HttpClient client;

        public ApiService(string token, string baseUrl = "")
        {
            this.token = token;
            string path = System.AppDomain.CurrentDomain.BaseDirectory + "\\maxx_configuration.json";
            if (File.Exists(path))
            {
                string readText = File.ReadAllText(path);
                dynamic config = JObject.Parse(readText);

                baseUrl = config.cloud_url.ToString();
                if (baseUrl == "" || baseUrl == null)
                {
                    MessageBox.Show("Url is not found in maxx_configuration!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Unable to find maxx_configuration.json!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            this.baseUrl = baseUrl;
            this.client = new HttpClient();
        }

        public async Task<T> GetAsync<T>(string endpoint) where T : class
        {
            try
            {
                string url = $"{baseUrl}/{endpoint}?token={token}";
                var values = new Dictionary<string, string> { { "token", token } };
                var content = new FormUrlEncodedContent(values);

                HttpResponseMessage response = await client.PostAsync(url, content);
                response.EnsureSuccessStatusCode();

                string json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(json);
            }
            catch (Exception ex)
            {
                throw new Exception($"API Error on {endpoint}: {ex.Message}", ex);
            }
        }

        public async Task<string> PostAsync(string url, object data)
        {
            try
            {
                var json = JsonConvert.SerializeObject(data);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(url, content);
                response.EnsureSuccessStatusCode();

                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                return $"{{\"status\":\"failed\", \"msg\":\"{ex.Message}\"}}";
            }
        }

        public async Task<byte[]> DownloadFileAsync(string url)
        {
            return await client.GetByteArrayAsync(url);
        }
    }
}