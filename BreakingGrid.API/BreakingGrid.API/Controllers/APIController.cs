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
        private readonly IRecommendationService _emotionToEffectsConverter;

        public APIController(ILogger<APIController> logger, IEmojiDetector emojiDetector, IRecommendationService emotionToEffectsConverter)
        {
            _logger = logger;
            _emojiDetector = emojiDetector;
            _emotionToEffectsConverter = emotionToEffectsConverter;
        }
         
        [HttpPost]
        public async Task<string> Post(string url)
        {
            var emotions = await _emojiDetector.GetEmotions(url);

            if (emotions == null)
                return string.Empty;

            var topEmoji = _emotionToEffectsConverter.GetTop(emotions);

            if (topEmoji == null)
                return string.Empty;

            var effects = _emotionToEffectsConverter.GetEffects(topEmoji.Type);

            return JsonConvert.SerializeObject(effects);
        }
    }
}