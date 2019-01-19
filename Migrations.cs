using OrchardCore.ContentManagement.Metadata;
using OrchardCore.ContentManagement.Metadata.Settings;
using OrchardCore.Lists.Models;
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
            // by default the `FlowPart` isn't reusable, so we'll make it
            // reusable to provide a cleaner UI
            _contentDefinitionManager.AlterPartDefinition("FlowPart", part => part
                .Reusable());

            #region HtmlAttributes

            _contentDefinitionManager.AlterPartDefinition("HtmlAttributesPart", part => part
                .Attachable()
                .WithDescription("Customise common attributes on HTML element.")
                .WithDisplayName("HTML Attributes"));

            #endregion

            #region Section

            _contentDefinitionManager.AlterPartDefinition("SectionPart", part => part
                .WithDescription("Properties for section widget."));

            _contentDefinitionManager.AlterTypeDefinition("Section", type => type
                .WithPart("TitlePart")
                .WithPart("SectionPart")
                .WithPart("HtmlAttributesPart")
                .WithPart("Content", "FlowPart", part => part
                    .WithDescription("Elements displayed within section")
                    .WithDisplayName("Content"))
                .Stereotype("Widget"));

            #endregion

            #region Heading

            _contentDefinitionManager.AlterPartDefinition("HeadingPart", part => part
                .WithDescription("Properties for heading widget."));

            _contentDefinitionManager.AlterTypeDefinition("Heading", type => type
                .WithPart("HeadingPart")
                .WithPart("HtmlAttributesPart")
                .Stereotype("Widget"));

            #endregion

            #region Link

            _contentDefinitionManager.AlterPartDefinition("LinkPart", part => part
                .WithDescription("Properties for link widget."));

            _contentDefinitionManager.AlterTypeDefinition("Link", type => type
                .WithPart("LinkPart")
                .WithPart("HtmlAttributesPart")
                .Stereotype("Widget"));

            #endregion

            #region Container

            _contentDefinitionManager.AlterTypeDefinition("Container", type => type
                .WithPart("TitlePart")
                .WithPart("Children", "FlowPart", part => part
                    .WithDescription("Elements displayed within container")
                    .WithDisplayName("Children"))
                .WithPart("HtmlAttributesPart")
                .Stereotype("Widget"));

            #endregion

            #region Paragraph 

            _contentDefinitionManager.AlterPartDefinition("ParagraphPart", part => part
                .WithDescription("Properties for paragraph widget."));

            _contentDefinitionManager.AlterTypeDefinition("Paragraph", type => type
                .WithPart("ParagraphPart")
                .WithPart("HtmlAttributesPart")
                .Stereotype("Widget"));

            #endregion

            #region Media

            _contentDefinitionManager.AlterTypeDefinition("Media", type => type
                .WithSetting("Description", "Displays media accompanied with text content")
                .WithPart("TitlePart")
                .WithPart("MediaItems", "BagPart", part => part
                    .WithDisplayName("Media Items")
                    .WithDescription("Images, video, embeds or HTML to be displayed")
                    .WithSetting("DisplayType", "Detail")
                    .ContainedContentTypes(new string[] { "Html" })
                )
                .WithPart("Body", "FlowPart", part => part
                    .WithDisplayName("Body")
                    .WithDescription("Content displayed alongside media")
                )
                .WithPart("HtmlAttributesPart")
                .Stereotype("Widget"));

            #endregion

            #region Html

            _contentDefinitionManager.AlterTypeDefinition("Html", type => type
                .WithPart("HtmlBodyPart")
                .Stereotype("Widget"));

            #endregion

            return 8;
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

        public int UpdateFrom4()
        {
            _contentDefinitionManager.AlterTypeDefinition("Container", type => type
                .WithPart("TitlePart")
                .WithPart("Children", "FlowPart", part => part
                    .WithDescription("Elements displayed within container")
                    .WithDisplayName("Children"))
                .WithPart("HtmlAttributesPart")
                .Stereotype("Widget"));

            return 5;
        }

        public int UpdateFrom5()
        {
            _contentDefinitionManager.AlterPartDefinition("ParagraphPart", part => part
                .WithDescription("Properties for paragraph widget."));

            _contentDefinitionManager.AlterTypeDefinition("Paragraph", type => type
                .WithPart("ParagraphPart")
                .WithPart("HtmlAttributesPart")
                .Stereotype("Widget"));

            return 6;
        }

        public int UpdateFrom6()
        {
            _contentDefinitionManager.AlterTypeDefinition("Media", type => type
                .WithSetting("Description", "Displays media accompanied with text content")
                .WithPart("TitlePart")
                .WithPart("MediaItems", "BagPart", part => part
                    .WithDisplayName("Media Items")
                    .WithDescription("Images, video, embeds or HTML to be displayed")
                    .WithSetting("DisplayType", "Detail")
                    .ContainedContentTypes(new string[] { "Html" })
                )
                .WithPart("Body", "FlowPart", part => part
                    .WithDisplayName("Body")
                    .WithDescription("Content displayed alongside media")
                )
                .WithPart("HtmlAttributesPart")
                .Stereotype("Widget"));

            return 7;
        }

        public int UpdateFrom7()
        {
            _contentDefinitionManager.AlterTypeDefinition("Html", type => type
                .WithPart("HtmlBodyPart")
                .Stereotype("Widget"));

            return 8;
        }
    }
}

