using BreakingGrid.API.Abstractions;

namespace BreakingGrid.API.Models
{
    public class Emoji : IEmoji
    {
        public Emoji(EmojiStyle style, double score)
        {
            Type = style;
            Score = score;
            Icon = Constants.POTENTIAL_EMOJI_ICON_LIST[(int)style];
        }

        public string Icon { get; }

        public EmojiStyle Type { get; private set; }

        public double Score { get; private set; }
    }

    public enum EmojiStyle
    {
        NeutralFace,
        HappyFace,
        SurprisedFace,
        SadFace,
        AngryFace,
        DisgustedFace,
        FearfulFace,
        ContemptFace
    }
}