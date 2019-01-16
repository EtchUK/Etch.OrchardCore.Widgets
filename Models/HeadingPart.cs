using OrchardCore.ContentManagement;

namespace Moov2.OrchardCore.Widgets.Models
{
    public class HeadingPart : ContentPart
    {
        private const int DefaultLevelValue = 1;

        public int Level { get; set; }
        public string Text { get; set; }

        public HeadingPart()
        {
            Level = DefaultLevelValue;
        }
    }
}
