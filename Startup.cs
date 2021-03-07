using Fluid;
using Microsoft.Extensions.DependencyInjection;
using Etch.OrchardCore.Widgets.Drivers;
using Etch.OrchardCore.Widgets.Models;
using OrchardCore.ContentManagement;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.Data.Migration;
using OrchardCore.Modules;
using Etch.OrchardCore.Widgets.Filters;
using OrchardCore.Liquid;

namespace Etch.OrchardCore.Widgets
{
    public class Startup : StartupBase
    {
        static Startup()
        {
            TemplateContext.GlobalMemberAccessStrategy.Register<HtmlAttributesPart>();
        }

        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            
            services.AddContentPart<HtmlAttributesPart>()
                .UseDisplayDriver<HtmlAttributesPartDisplay>();

            services.AddScoped<IDataMigration, Migrations>();

            services.AddLiquidFilter<AnimationCssFilter>("animation_css");
            services.AddLiquidFilter<AnimationDataAttributesFilter>("animation_data_attributes");
            services.AddLiquidFilter<AnimationStyles>("animation_styles");
        }
    }
}
