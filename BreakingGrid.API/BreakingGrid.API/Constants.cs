using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BreakingGrid.API
{
    class Constants
    {
        public static readonly IList<string> POTENTIAL_EMOJI_ICON_LIST = new ReadOnlyCollection<string>
            (new List<string> { "😐", "😄", "😮", "😭", "😠", "🤢", "😨", "🙄" });
    }
}