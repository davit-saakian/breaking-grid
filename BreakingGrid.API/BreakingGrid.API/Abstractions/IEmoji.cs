using BreakingGrid.API.Models;

namespace BreakingGrid.API.Abstractions
{
    public interface IEmoji
    {
        string Icon { get; }

        EmojiStyle Type { get; }

        double Score { get; }
    }
}