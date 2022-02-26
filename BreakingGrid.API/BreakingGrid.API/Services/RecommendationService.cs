using BreakingGrid.API.Abstractions;
using BreakingGrid.API.Models;
using System.Collections.Generic;
using System.Linq;

namespace BreakingGrid.API.Services
{
    public class RecommendationService : IRecommendationService
    {
        public IEmoji GetTop(IEnumerable<IEmoji> emotions)
        {
            IEmoji result = emotions?.FirstOrDefault();
            if (result == null) 
                return null;

            foreach (var emotion in emotions)
            {
                result = emotion.Type != EmojiStyle.NeutralFace && emotion.Score > result.Score ? emotion : result;
            }

            return result;
        }

        public IEnumerable<string> GetEffects(EmojiStyle emojiStyle)
        {
            Constants.EFFECTS.TryGetValue((int)emojiStyle, out var effects);
            return effects;
        }
    }
}