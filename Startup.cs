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
            TemplateContext.GlobalMemberAccessStrategy.Register<SectionPart>();
        }

        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            
            services.AddScoped<IContentPartDisplayDriver, SectionPartDisplay>();
            services.AddScoped<IContentPartDisplayDriver, HtmlAttributesPartDisplay>();

            services.AddSingleton<ContentPart, HtmlAttributesPart>();
            services.AddSingleton<ContentPart, SectionPart>();

            services.AddScoped<IDataMigration, Migrations>();
        }
    }
}
