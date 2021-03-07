using Etch.OrchardCore.Widgets.Models;
using OrchardCore.ContentFields.Fields;
using OrchardCore.ContentManagement;

namespace Etch.OrchardCore.Widgets.Extensions
{
    public static class ContentItemExtensions
    {
        public static AnimationPart GetAnimationPart(this ContentItem contentItem)
        {
            return new AnimationPart
            {
                Delay = contentItem.Get<ContentPart>("AnimationPart").Get<NumericField>("Delay").Value,
                Duration = contentItem.Get<ContentPart>("AnimationPart").Get<NumericField>("Duration").Value,
                Repeat = contentItem.Get<ContentPart>("AnimationPart").Get<BooleanField>("Repeat").Value,
                Timing = contentItem.Get<ContentPart>("AnimationPart").Get<TextField>("Timing").Text,
                Type = contentItem.Get<ContentPart>("AnimationPart").Get<TextField>("Type").Text,
            };
        }
    }
}
