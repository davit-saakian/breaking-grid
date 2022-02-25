using System.Collections.Generic;
using System.Threading.Tasks;

namespace BreakingGrid.API.Abstractions
{
    public interface IEmojiDetector
    {
        Task<IEnumerable<IEmoji>> GetEmotions(string url);
    }
}