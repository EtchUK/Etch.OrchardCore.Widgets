using Fluid; 
using Fluid.Values; 
using OrchardCore.Liquid; 
using System.Linq; 
using System.Threading.Tasks; 
 
namespace Etch.OrchardCore.Widgets.Filters
{ 
    public class EmphasizeTextFilter : ILiquidFilter 
    { 
        public ValueTask<FluidValue> ProcessAsync(FluidValue input, FilterArguments arguments, LiquidTemplateContext ctx) 
        { 
            var text = input.ToStringValue(); 
            var terms = arguments.Names.Any(x => x.Equals("terms")) ? arguments["terms"] as ArrayValue : null; 
 
            if (terms == null) 
            { 
                return new StringValue(text); 
            } 
 
            foreach (var term in terms.Values.Select(x => x.ToStringValue())) 
            { 
                text = text.Replace(term, $"<span class=\"text--emphasis\">{term}</span>"); 
            } 
 
            return new StringValue(text); 
        } 
    } 
}