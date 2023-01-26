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
        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddContentPart<VisibilityPart>();
            
            services.AddContentPart<HtmlAttributesPart>()
                .UseDisplayDriver<HtmlAttributesPartDisplay>();

            services.Configure<TemplateOptions>(o =>
            {
                o.MemberAccessStrategy.Register<HtmlAttributesPart>();
                o.MemberAccessStrategy.Register<VisibilityPart>();
            })
                .AddLiquidFilter<AnimationCssFilter>("animation_css")
                .AddLiquidFilter<AnimationDataAttributesFilter>("animation_data_attributes")
                .AddLiquidFilter<AnimationStyles>("animation_styles")
                .AddLiquidFilter<EmbedUrlFilter>("embed_url");

            services.AddScoped<IDataMigration, Migrations>();
        }
    }
}