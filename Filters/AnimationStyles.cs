using Etch.OrchardCore.Widgets.Extensions;
using Fluid;
using Fluid.Values;
using OrchardCore.ContentManagement;
using OrchardCore.Liquid;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Etch.OrchardCore.Widgets.Filters
{
    public class AnimationStyles : ILiquidFilter
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

            var styles = new List<string>();

            if (!string.IsNullOrWhiteSpace(animationPart.Timing))
            {
                styles.Add($"--animationTiming: {animationPart.Timing};");
            }

            if (animationPart.Delay.HasValue)
            {
                styles.Add($"--animationDelay: {animationPart.Delay}ms;");
            }

            if (animationPart.Duration.HasValue)
            {
                styles.Add($"--animationDuration: {animationPart.Duration}ms;");
            }

            return new ValueTask<FluidValue>(new StringValue(string.Join(" ", styles)));
        }
    }
}