using BreakingGrid.API.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace BreakingGrid.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class APIController : ControllerBase
    {
        private readonly ILogger<APIController> _logger;
        private readonly IEmojiDetector _emojiDetector;

        public APIController(ILogger<APIController> logger, IEmojiDetector emojiDetector)
        {
            _logger = logger;
            _emojiDetector = emojiDetector;
        }
         
        [HttpPost]
        public async Task<string> Post(string url)
        {
            var emotions = await _emojiDetector.GetEmotions(url);

            if (emotions == null)
                return string.Empty;

            return JsonConvert.SerializeObject(emotions);
        }
    }
}