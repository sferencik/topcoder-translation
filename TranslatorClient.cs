using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace translation {
    public class TranslatorClient {
        private readonly HttpClient _googleTranslateClient;
        public TranslatorClient() {
            _googleTranslateClient = new HttpClient();
            _googleTranslateClient.BaseAddress = new Uri("https://translate.google.com/");
        }

        public async Task<string> Translate(string original) {
            var request = new HttpRequestMessage(
                HttpMethod.Post,
                new Uri("translate_a/single?client=at&dt=t&dt=ld&dt=qca&dt=rm&dt=bd&dj=1&hl=%25s&ie=UTF-8&oe=UTF-8&inputm=2&otf=2&iid=1dd3b944-fa62-4b55-b330-74909a99969e&", UriKind.Relative)) {
                    Content = new FormUrlEncodedContent(new List<KeyValuePair<string, string>> {
                        new KeyValuePair<string, string>("sl", "auto"),
                        new KeyValuePair<string, string>("tl", "es"),
                        new KeyValuePair<string, string>("q", original),
                    }),
                };
            request.Headers.TryAddWithoutValidation("User-Agent", "AndroidTranslate/5.3.0.RC02.130475354-53000263 5.1 phone TRANSLATE_OPM5_TEST_1");
            var response = await _googleTranslateClient.SendAsync(request);
            if (!response.IsSuccessStatusCode) {
                throw new Exception($"Failed to translate: {await response.Content.ReadAsStringAsync()}.");
            }

            return (string)JObject.Parse(await response.Content.ReadAsStringAsync())["sentences"][0]["trans"];
        }
    }
}