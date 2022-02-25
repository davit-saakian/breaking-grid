using BreakingGrid.API.Models;
using System.Collections.Generic;

namespace BreakingGrid.API.Services.Models
{
    public class FaceRectangle
    {
        public int top { get; set; }
        public int left { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }

    public class Emotion
    {
        public double anger { get; set; }
        public double contempt { get; set; }
        public double disgust { get; set; }
        public double fear { get; set; }
        public double happiness { get; set; }
        public double neutral { get; set; }
        public double sadness { get; set; }
        public double surprise { get; set; }

        public static List<Emoji> CreateEmojis(Emotion emotion)
        {
            if (emotion == null)
                return new List<Emoji>();

            return new List<Emoji>
            {
                new Emoji(EmojiStyle.AngryFace, emotion.anger),
                new Emoji(EmojiStyle.ContemptFace, emotion.contempt),
                new Emoji(EmojiStyle.DisgustedFace, emotion.disgust),
                new Emoji(EmojiStyle.FearfulFace, emotion.fear),
                new Emoji(EmojiStyle.HappyFace, emotion.happiness),
                new Emoji(EmojiStyle.NeutralFace, emotion.neutral),
                new Emoji(EmojiStyle.SadFace, emotion.sadness),
                new Emoji(EmojiStyle.SurprisedFace, emotion.surprise),
            };
        }
    }

    public class FaceAttributes
    {
        public Emotion emotion { get; set; }
    }

    public class Root
    {
        public string faceId { get; set; }
        public FaceRectangle faceRectangle { get; set; }
        public FaceAttributes faceAttributes { get; set; }
    }
}