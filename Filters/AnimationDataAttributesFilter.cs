using Etch.OrchardCore.Widgets.Extensions;
using Fluid;
using Fluid.Values;
using OrchardCore.ContentManagement;
using OrchardCore.Liquid;
using System.Threading.Tasks;

namespace Etch.OrchardCore.Widgets.Filters
{
    public class AnimationDataAttributesFilter : ILiquidFilter
    {
        public ValueTask<FluidValue> ProcessAsync(FluidValue input, FilterArguments arguments, TemplateContext ctx)
        {
            var contentItem = input.ToObjectValue();

            if (!(contentItem is ContentItem) || !(contentItem as ContentItem).Has("AnimationPart"))
            {
                return new ValueTask<FluidValue>(new StringValue(string.Empty));
            }

            var animationPart = (contentItem as ContentItem).GetAnimationPart();

            if (animationPart.Type == "none" || !animationPart.Repeat)
            {
                return new ValueTask<FluidValue>(new StringValue(string.Empty));
            }

            return new ValueTask<FluidValue>(new StringValue("data-repeat=\"true\"") { Encode = false });
        }
    }
}
