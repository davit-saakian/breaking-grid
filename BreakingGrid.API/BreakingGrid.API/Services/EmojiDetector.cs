using BreakingGrid.API.Abstractions;
using BreakingGrid.API.Models;
using BreakingGrid.API.Services.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace BreakingGrid.API.Services
{
    public class EmojiDetector : IEmojiDetector
    {
        private IConfiguration _configuration;
        public EmojiDetector(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IEnumerable<IEmoji>> GetEmotions(string url)
        {
            using (var client = new HttpClient())
            {
                // Setting Base address.  
                client.BaseAddress = new Uri(_configuration.GetSection("FaceAPI").GetSection("BaseUrl").Value);

                // Setting content type.  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", _configuration.GetSection("FaceAPI").GetSection("ApiToken").Value);

                // Initialization.  
                HttpContent content = new StringContent("{\"url\":\"" + url + "\"}", System.Text.Encoding.UTF8, "application/json");

                // HTTP Post  
                var response = await client.PostAsync("face/v1.0/detect?detectionModel=detection_01&returnFaceId=true&returnFaceLandmarks=false&returnFaceAttributes=emotion", content).ConfigureAwait(false);

                // Verification  
                if (response.IsSuccessStatusCode)
                {
                    // Reading Response.  
                    string result = response.Content.ReadAsStringAsync().Result;
                    var model = JsonConvert.DeserializeObject<List<Root>>(result);

                    return Emotion.CreateEmojis(model.FirstOrDefault()?.faceAttributes.emotion);
                }
            }

            return null;
        }
    }
}

