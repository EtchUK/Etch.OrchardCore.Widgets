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
            _contentDefinitionManager.AlterPartDefinition("HtmlAttributesPart", part => part
                .Attachable()
                .WithDescription("Customise common attributes on HTML element.")
                .WithDisplayName("HTML Attributes"));

            _contentDefinitionManager.AlterPartDefinition("SectionPart", part => part
                .WithDescription("Properties for section widget."));

            _contentDefinitionManager.AlterTypeDefinition("Section", type => type
                .WithPart("TitlePart")
                .WithPart("SectionPart")
                .WithPart("HtmlAttributesPart")
                .WithPart("FlowPart")
                .Stereotype("Widget"));

            _contentDefinitionManager.AlterPartDefinition("HeadingPart", part => part
                .WithDescription("Properties for heading widget."));

            _contentDefinitionManager.AlterTypeDefinition("Heading", type => type
                .WithPart("HeadingPart")
                .WithPart("HtmlAttributesPart")
                .Stereotype("Widget"));

            _contentDefinitionManager.AlterPartDefinition("LinkPart", part => part
                .WithDescription("Properties for link widget."));

            _contentDefinitionManager.AlterTypeDefinition("Link", type => type
                .WithPart("LinkPart")
                .WithPart("HtmlAttributesPart")
                .Stereotype("Widget"));

            return 4;
        }

        public int UpdateFrom1()
        {
            _contentDefinitionManager.AlterPartDefinition("HtmlAttributesPart", part => part
                .Attachable()
                .WithDescription("Customise common attributes on HTML element.")
                .WithDisplayName("HTML Attributes"));

            _contentDefinitionManager.AlterTypeDefinition("Section", type => type
                .WithPart("HtmlAttributesPart"));

            return 2;
        }

        public int UpdateFrom2()
        {
            _contentDefinitionManager.AlterPartDefinition("HeadingPart", part => part
                .WithDescription("Properties for heading widget."));

            _contentDefinitionManager.AlterTypeDefinition("Heading", type => type
                .WithPart("HeadingPart")
                .WithPart("HtmlAttributesPart")
                .Stereotype("Widget"));

            return 3;
        }

        public int UpdateFrom3()
        {
            _contentDefinitionManager.AlterPartDefinition("LinkPart", part => part
                .WithDescription("Properties for link widget."));

            _contentDefinitionManager.AlterTypeDefinition("Link", type => type
                .WithPart("LinkPart")
                .WithPart("HtmlAttributesPart")
                .Stereotype("Widget"));

            return 4;
        }
    }
}

