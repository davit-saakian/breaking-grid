using BreakingGrid.API.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace BreakingGrid.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FaceRecognitionController : ControllerBase
    {
        private readonly ILogger<FaceRecognitionController> _logger;
        private readonly IEmojiDetector _emojiDetector;
        private readonly IRecommendationService _emotionToEffectsConverter;

        public FaceRecognitionController(ILogger<FaceRecognitionController> logger, IEmojiDetector emojiDetector, IRecommendationService emotionToEffectsConverter)
        {
            _logger = logger;
            _emojiDetector = emojiDetector;
            _emotionToEffectsConverter = emotionToEffectsConverter;
        }

        [HttpPost("emotions")]
        public async Task<string> Post_Emotions(string url)
        {
            var emotions = await _emojiDetector.GetEmotions(url);

            if (emotions == null)
                return string.Empty;

            return JsonConvert.SerializeObject(emotions);
        }

        [HttpPost("effects")]
        public async Task<string> Post_Effects(string url)
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