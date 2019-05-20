using Fluid;
using Microsoft.Extensions.DependencyInjection;
using Etch.OrchardCore.Widgets.Drivers;
using Etch.OrchardCore.Widgets.Models;
using OrchardCore.ContentManagement;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.Data.Migration;
using OrchardCore.Modules;

namespace Etch.OrchardCore.Widgets
{
    public class Startup : StartupBase
    {
        static Startup()
        {
            TemplateContext.GlobalMemberAccessStrategy.Register<HeadingPart>();
            TemplateContext.GlobalMemberAccessStrategy.Register<HtmlAttributesPart>();
            TemplateContext.GlobalMemberAccessStrategy.Register<LinkPart>();
            TemplateContext.GlobalMemberAccessStrategy.Register<ParagraphPart>();
            TemplateContext.GlobalMemberAccessStrategy.Register<SectionPart>();
        }

        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddScoped<IContentPartDisplayDriver, HeadingPartDisplay>();
            services.AddScoped<IContentPartDisplayDriver, HtmlAttributesPartDisplay>();
            services.AddScoped<IContentPartDisplayDriver, LinkPartDisplay>();
            services.AddScoped<IContentPartDisplayDriver, ParagraphPartDisplay>();
            services.AddScoped<IContentPartDisplayDriver, SectionPartDisplay>();

            services.AddSingleton<ContentPart, HeadingPart>();
            services.AddSingleton<ContentPart, HtmlAttributesPart>();
            services.AddSingleton<ContentPart, LinkPart>();
            services.AddSingleton<ContentPart, ParagraphPart>();
            services.AddSingleton<ContentPart, SectionPart>();

            services.AddScoped<IDataMigration, Migrations>();
        }
    }
}
