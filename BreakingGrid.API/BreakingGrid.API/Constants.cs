using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BreakingGrid.API
{
    class Constants
    {
        public static readonly IList<string> POTENTIAL_EMOJI_ICON_LIST = new ReadOnlyCollection<string>
            (new List<string> { "😐", "😄", "😮", "😭", "😠", "🤢", "😨", "🙄" });

        /// <summary>
        /// The data that we've collected from our users edits and processed using microsofts face API
        /// </summary>
        public static readonly IDictionary<int, IList<string>> EFFECTS = new Dictionary<int, IList<string>>
        {
            { 1, new List<string>
                {
                    "effect_hdr1",
                    "effect_blur",
                    "effect_bw",
                    "effect_noise1",
                    "effect_focal_zoom",
                    "effect_saturation",
                    "effect_film2",
                    "effect_sharpen",
                    "effect_motion_blur",
                    "effect_dodger"
                }
            },
            { 2, new List<string>
                {
                    "effect_hdr1",
                    "effect_blur",
                    "effect_bw",
                    "effect_noise1",
                    "effect_sharpen",
                    "effect_focal_zoom",
                    "effect_motion",
                    "effect_motion_blur",
                    "effect_film2",
                    "effect_colorize"
                }
            },
            { 3, new List<string>
                {
                    "effect_hdr1",
                    "effect_blur",
                    "effect_bw",
                    "effect_noise1",
                    "effect_motion_blur",
                    "effect_focal_zoom",
                    "effect_sharpen",
                    "effect_dodger",
                    "effect_motion",
                    "effect_film2"
                }
            },
            { 4, new List<string>
                {
                    "effect_hdr1",
                    "effect_noise1",
                    "effect_blur",
                    "effect_bw",
                    "effect_film2",
                    "effect_motion_blur",
                    "effect_dodger",
                    "effect_apr2",
                    "effect_saturation",
                    "effect_brl2"
                }
            },
            { 5, new List<string>
                {
                    "effect_hdr1",
                    "effect_brnz4",
                    "effect_bw",
                    "effect_color_replace",
                    "effect_blur",
                    "effect_halftone_dots",
                    "effect_vin1",
                    "effect_stenciler8",
                    "effect_stenciler2",
                    "effect_saturation"
                }
            },
            { 6, new List<string>
                {
                    "effect_hdr1",
                    "effect_bw",
                    "effect_smart_blur",
                    "effect_brnz2",
                    "effect_colorize",
                    "effect_hdr2",
                    "effect_motion",
                    "effect_radial_blur",
                    "effect_vhs3"
                }
            },
            { 7, new List<string>
                {
                    "effect_hdr1",
                    "effect_blur",
                    "effect_noise1",
                    "effect_bw",
                    "effect_dodger",
                    "effect_focal_zoom",
                    "effect_color_replace",
                    "effect_color_splash",
                    "effect_sharpen",
                    "effect_motion_blur"
                }
            }
        };
    }
}