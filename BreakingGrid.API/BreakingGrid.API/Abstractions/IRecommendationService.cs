using BreakingGrid.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BreakingGrid.API.Abstractions
{
    public interface IRecommendationService
    {
        public IEmoji GetTop(IEnumerable<IEmoji> emotions);
        public IEnumerable<string> GetEffects(EmojiStyle emojiStyle);
    }
}