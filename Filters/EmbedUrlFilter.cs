using Fluid;
using Fluid.Values;
using OrchardCore.Liquid;
using System.Threading.Tasks;

namespace Etch.OrchardCore.Widgets.Filters
{
    public class EmbedUrlFilter : ILiquidFilter
    {
        public ValueTask<FluidValue> ProcessAsync(FluidValue input, FilterArguments arguments, LiquidTemplateContext context)
        {
            var videoUrl = input.ToObjectValue().ToString();

            if (videoUrl.Contains("youtube.com/watch?v="))
            {
                return new ValueTask<FluidValue>(new StringValue(ConvertToEmbed(videoUrl)));
            }

            return new ValueTask<FluidValue>(new StringValue(videoUrl));
        }

        public static string ConvertToEmbed(string url)
        {
            url = url.Replace("watch?v=", "embed/");

            if (url.Contains('&'))
            {
                url = url.Substring(0, url.IndexOf("&"));
            }

            return url;
        }
    }
}