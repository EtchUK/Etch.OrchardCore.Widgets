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
        public ValueTask<FluidValue> ProcessAsync(FluidValue input, FilterArguments arguments, TemplateContext ctx)
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
                styles.Add($"--animationFadeTiming: {animationPart.Timing};");
            }

            if (animationPart.Delay.HasValue)
            {
                styles.Add($"--animationFadeDelay: {animationPart.Delay}s;");
            }

            if (animationPart.Duration.HasValue)
            {
                styles.Add($"--animationFadeDuration: {animationPart.Duration}s;");
            }

            return new ValueTask<FluidValue>(new StringValue(string.Join(" ", styles)));
        }
    }
}