using Etch.OrchardCore.Widgets.Extensions;
using Fluid;
using Fluid.Values;
using OrchardCore.ContentManagement;
using OrchardCore.Liquid;
using System.Threading.Tasks;

namespace Etch.OrchardCore.Widgets.Filters
{
    public class AnimationCssFilter : ILiquidFilter
    {
        public ValueTask<FluidValue> ProcessAsync(FluidValue input, FilterArguments arguments, LiquidTemplateContext context)
        {
            var contentItem = input.ToObjectValue();

            if (!(contentItem is ContentItem) || !(contentItem as ContentItem).Has("AnimationPart"))
            {
                return new ValueTask<FluidValue>(new StringValue(string.Empty));
            }

            var animationPart = (contentItem as ContentItem).GetAnimationPart();

            if (animationPart.Type == "none")
            {
                return new ValueTask<FluidValue>(new StringValue(string.Empty));
            }

            return new ValueTask<FluidValue>(new StringValue($"js-in-viewport {animationPart.Type}"));
        }
    }
}

