using OrchardCore.ContentManagement.Metadata;
using OrchardCore.ContentManagement.Metadata.Settings;
using OrchardCore.Data.Migration;

namespace Moov2.OrchardCore.Widgets
{
    public class Migrations : DataMigration
    {
        private readonly IContentDefinitionManager _contentDefinitionManager;

        public Migrations(IContentDefinitionManager contentDefinitionManager)
        {
            _contentDefinitionManager = contentDefinitionManager;
        }

        public int Create()
        {
            // Form
            _contentDefinitionManager.AlterPartDefinition("SectionPart", part => part
                .Attachable()
                .WithDescription("Properties for a section widget."));

            _contentDefinitionManager.AlterTypeDefinition("Section", type => type
                .WithPart("TitlePart")
                .WithPart("SectionPart")
                .WithPart("FlowPart")
                .Stereotype("Widget"));
            
            return 1;
        }
    }
}

