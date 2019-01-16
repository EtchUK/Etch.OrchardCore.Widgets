using Fluid;
using Microsoft.Extensions.DependencyInjection;
using Moov2.OrchardCore.Widgets.Drivers;
using Moov2.OrchardCore.Widgets.Models;
using OrchardCore.ContentManagement;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.Data.Migration;
using OrchardCore.Modules;

namespace Moov2.OrchardCore.Widgets
{
    public class Startup : StartupBase
    {
        static Startup()
        {
            TemplateContext.GlobalMemberAccessStrategy.Register<HeadingPart>();
            TemplateContext.GlobalMemberAccessStrategy.Register<HtmlAttributesPart>();
            TemplateContext.GlobalMemberAccessStrategy.Register<LinkPart>();
            TemplateContext.GlobalMemberAccessStrategy.Register<SectionPart>();
        }

        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddScoped<IContentPartDisplayDriver, HeadingPartDisplay>();
            services.AddScoped<IContentPartDisplayDriver, HtmlAttributesPartDisplay>();
            services.AddScoped<IContentPartDisplayDriver, LinkPartDisplay>();
            services.AddScoped<IContentPartDisplayDriver, SectionPartDisplay>();

            services.AddSingleton<ContentPart, HeadingPart>();
            services.AddSingleton<ContentPart, HtmlAttributesPart>();
            services.AddSingleton<ContentPart, LinkPart>();
            services.AddSingleton<ContentPart, SectionPart>();

            services.AddScoped<IDataMigration, Migrations>();
        }
    }
}
