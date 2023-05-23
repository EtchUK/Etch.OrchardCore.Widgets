using Etch.OrchardCore.Fields.Code.Fields;
using Etch.OrchardCore.Fields.Code.Settings;
using Etch.OrchardCore.Fields.Colour.Fields;
using Etch.OrchardCore.Fields.Colour.Settings;
using Etch.OrchardCore.Fields.ResponsiveMedia.Fields;
using Etch.OrchardCore.Fields.ResponsiveMedia.Settings;
using Etch.OrchardCore.Fields.Values.Settings;
using Etch.OrchardCore.Widgets.Models;
using Newtonsoft.Json.Linq;
using OrchardCore.ContentFields.Fields;
using OrchardCore.ContentFields.Settings;
using OrchardCore.ContentManagement.Metadata;
using OrchardCore.ContentManagement.Metadata.Settings;
using OrchardCore.Data.Migration;
using OrchardCore.Flows.Models;
using OrchardCore.Title.Models;

namespace Etch.OrchardCore.Widgets
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
            #region Html Attributes

            _contentDefinitionManager.AlterPartDefinition("HtmlAttributesPart", part => part
                .Attachable()
                .WithDescription("Customise common attributes on HTML element.")
                .WithDisplayName("HTML Attributes"));

            #endregion HtmlAttributes

            return 1;
        }

        public int UpdateFrom1()
        {
            _contentDefinitionManager.AlterPartDefinition("BackgroundPart", part => part
                .Attachable()
                .WithDescription("Define background properties.")
                .WithDisplayName("Background")
                .WithField("BackgroundColour", field => field
                    .OfType(nameof(ColourField))
                    .WithDisplayName("Background Colour")
                    .WithPosition("0")
                    .WithSettings(new ColourFieldSettings
                    {
                        AllowCustom = true,
                        AllowTransparent = true,
                        DefaultValue = "transparent",
                        UseGlobalColours = true
                    })
                )
                .WithField("BackgroundPattern", field => field
                    .OfType(nameof(TextField))
                    .WithDisplayName("Background Style")
                    .WithPosition("1")
                    .WithEditor("PredefinedList")
                    .WithSettings(new TextFieldPredefinedListEditorSettings
                    {
                        Editor = EditorOption.Dropdown,
                        Options = new ListValueOption[] { new ListValueOption { Name = "None", Value = string.Empty } }
                    })
                )
                .WithField("InvertTextColour", field => field
                    .OfType(nameof(BooleanField))
                    .WithDisplayName("Invert Text Colour")
                    .WithPosition("2")
                    .WithSettings(new BooleanFieldSettings
                    {
                        Hint = "For example, if the text is currently a dark colour, this will make it light, and vice versa.",
                        Label = "Invert Text Colour"
                    })
                )
                .WithField("BackgroundFixed", field => field
                    .OfType(nameof(BooleanField))
                    .WithDisplayName("Background Fixed")
                    .WithPosition("3")
                    .WithSettings(new BooleanFieldSettings
                    {
                        Hint = "Fix background in place to give a faux parallax effect.",
                        Label = "Fix Background Pattern"
                    })
                ));

            return 2;
        }

        public int UpdateFrom2()
        {
            _contentDefinitionManager.AlterPartDefinition("JavaScriptEventsPart", part => part
                .Attachable()
                .WithDescription("Define handlers for JavaScript events.")
                .WithDisplayName("JavaScript Events")
                .WithField("OnClick", field => field
                    .OfType(nameof(CodeField))
                    .WithDisplayName("Click")
                    .WithPosition("1")
                    .WithSettings(new CodeFieldSettings
                    {
                        Language = "javascript"
                    })
                ));

            return 3;
        }

        public int UpdateFrom3()
        {
            _contentDefinitionManager.AlterPartDefinition("ColumnablePart", part => part
               .Attachable()
               .WithDescription("Define properties for controlling column layout.")
               .WithDisplayName("Columnable")
               .WithField("Columns", field => field
                    .OfType(nameof(TextField))
                    .WithDisplayName("Columns")
                    .WithPosition("1")
                    .WithEditor("PredefinedList")
                    .WithSettings(new TextFieldSettings
                    {
                        Hint = "Specify how many columns to display the items in on desktop devices."
                    })
                    .WithSettings(new TextFieldPredefinedListEditorSettings
                    {
                        DefaultValue = "three",
                        Editor = EditorOption.Dropdown,
                        Options = new ListValueOption[] { 
                            new ListValueOption { Name = "Four", Value = "four" }, 
                            new ListValueOption { Name = "Three", Value = "three" }, 
                            new ListValueOption { Name = "Two", Value = "two" }, 
                            new ListValueOption { Name = "One", Value = "one" } 
                        }
                    })
                ));

            return 4;
        }

        public int UpdateFrom4()
        {
            _contentDefinitionManager.AlterPartDefinition("AnimationPart", part => part
                .Attachable()
                .WithDescription("Define settings for animating widget.")
                .WithDisplayName("Animation")
                .WithField("Type", field => field
                    .OfType(nameof(TextField))
                    .WithDisplayName("Type")
                    .WithPosition("1")
                    .WithEditor("PredefinedList")
                    .WithSettings(new TextFieldSettings
                    {
                        Hint = "Define type of animation."
                    })
                    .WithSettings(new TextFieldPredefinedListEditorSettings
                    {
                        DefaultValue = "none",
                        Editor = EditorOption.Dropdown,
                        Options = new ListValueOption[] {
                            new ListValueOption { Name = "None", Value = "none" },
                            new ListValueOption { Name = "Fade in", Value = "fade-in" },
                            new ListValueOption { Name = "Fade in from left", Value = "fade-in fade-in--from-left" },
                            new ListValueOption { Name = "Fade in from right", Value = "fade-in fade-in--from-right" },
                            new ListValueOption { Name = "Grow in from centre", Value = "grow-in" },
                            new ListValueOption { Name = "Grow in from top", Value = "grow-in grow-in--from-top" },
                            new ListValueOption { Name = "Grow in from right", Value = "grow-in grow-in--from-right" },
                            new ListValueOption { Name = "Grow in from bottom", Value = "grow-in grow-in--from-bottom" },
                            new ListValueOption { Name = "Grow in from left", Value = "grow-in grow-in--from-left" }
                        }
                    })
                )
                .WithField("Duration", field => field
                    .OfType(nameof(NumericField))
                    .WithDisplayName("Duration")
                    .WithPosition("2")
                    .WithEditor("Number")
                    .WithSettings(new NumericFieldSettings
                    {
                        DefaultValue = "600",
                        Minimum = 0,
                        Hint = "Length of animation in milliseconds.",
                        Scale = 0
                    })
                )
                .WithField("Timing", field => field
                    .OfType(nameof(TextField))
                    .WithDisplayName("Timing")
                    .WithPosition("3")
                    .WithEditor("PredefinedList")
                    .WithSettings(new TextFieldSettings
                    {
                        Hint = "Define how animation progresses through the duration of each cycle."
                    })
                    .WithSettings(new TextFieldPredefinedListEditorSettings
                    {
                        DefaultValue = "ease-in-out",
                        Editor = EditorOption.Dropdown,
                        Options = new ListValueOption[] {
                            new ListValueOption { Name = "Ease", Value = "ease" },
                            new ListValueOption { Name = "Ease in", Value = "ease-in" },
                            new ListValueOption { Name = "Ease out", Value = "ease-out" },
                            new ListValueOption { Name = "Ease in out", Value = "ease-in-out" },
                            new ListValueOption { Name = "Linear", Value = "linear" },
                            new ListValueOption { Name = "Overshoot", Value = "cubic-bezier(0.175, 0.885, 0.32, 1.275)" }
                        }
                    })
                )
                .WithField("Delay", field => field
                    .OfType(nameof(NumericField))
                    .WithDisplayName("Delay")
                    .WithPosition("4")
                    .WithEditor("Number")
                    .WithSettings(new NumericFieldSettings
                    {
                        DefaultValue = "0",
                        Minimum = 0,
                        Hint = "Number of milliseconds to delay start of animation.",
                        Scale = 0
                    })
                )
                .WithField("Repeat", field => field
                    .OfType(nameof(BooleanField))
                    .WithDisplayName("Repeat")
                    .WithPosition("5")
                    .WithSettings(new BooleanFieldSettings
                    {
                        Hint = "Repeat animation every time widget is scrolled in to view.",
                        Label = "Repeat"
                    })
                ));

            return 5;
        }

        public int UpdateFrom5()
        {
            _contentDefinitionManager.AlterPartDefinition("BackgroundPart", part => part
                .WithField("BackgroundFill", field => field
                    .OfType(nameof(BooleanField))
                    .WithDisplayName("Background Fill")
                    .WithPosition("4")
                    .WithSettings(new BooleanFieldSettings
                    {
                        Hint = "By default, background styles will tile and repeat. In some cases, you may want to force the background to fill the available space and not repeat. To do so, tick this box. Please note that depending on the chosen background and content, this option may result in backgrounds being 'stretched'.",
                        Label = "Background Fill"
                    })
                ));
            return 6;
        }

        public int UpdateFrom6()
        {
            _contentDefinitionManager.AlterPartDefinition("BleedPart", part => part
                .Attachable()
                .WithDescription("Adds \"bleed\" imagery options to make this area appear to blend in to adjacent ones")
                .WithDisplayName("Bleed")
                .WithField("BleedIn", field => field
                    .OfType(nameof(ResponsiveMediaField))
                    .WithDisplayName("Bleed In")
                    .WithPosition("1")
                    .WithSettings(new ResponsiveMediaFieldSettings
                    {
                        AllowMediaText = false,
                        Breakpoints = "375, 425, 600, 768, 1024, 1280, 1440, 1920, 2560",
                        Hint = "Image displayed at top of area, used to create a 'bleed' effect that blends this area with an adjacent one.",
                        Multiple = false,
                    })
                )
                .WithField("BleedOut", field => field
                    .OfType(nameof(ResponsiveMediaField))
                    .WithDisplayName("Bleed Out")
                    .WithPosition("2")
                    .WithSettings(new ResponsiveMediaFieldSettings
                    {
                        AllowMediaText = false,
                        Breakpoints = "375, 425, 600, 768, 1024, 1280, 1440, 1920, 2560",
                        Hint = "Image displayed at bottom of area, used to create a 'bleed' effect that blends this area with an adjacent one.",
                        Multiple = false,
                    })
                ));

            return 7;
        }

        public int UpdateFrom7()
        {
            _contentDefinitionManager.AlterPartDefinition("LinkVisualPart", part => part
               .Attachable()
               .WithDescription("Define visual properties for a link.")
               .WithDisplayName("Link Visual")
               .WithField("Style", field => field
                   .OfType(nameof(TextField))
                   .WithDisplayName("Style")
                   .WithPosition("1")
                   .WithEditor("PredefinedList")
                   .WithSettings(new TextFieldSettings
                   {
                       Hint = "Control the style of the link"
                   })
                   .WithSettings(new TextFieldPredefinedListEditorSettings
                   {
                       Editor = EditorOption.Dropdown,
                       Options = new ListValueOption[] {
                           new ListValueOption {
                               Name = "Default",
                               Value = string.Empty
                           },
                           new ListValueOption {
                               Name = "Primary Button",
                               Value = "btn--primary"
                           },
                           new ListValueOption {
                               Name = "Secondary Button",
                               Value = "btn--secondary"
                           }
                       }
                   })
               )
            );

            return 8;
        }

        public int UpdateFrom8()
        {
            _contentDefinitionManager.AlterPartDefinition(nameof(VisibilityPart), builder => builder
                 .Attachable()
                 .WithDisplayName("Visibility")
                 .WithDescription("Control when a content item is visible based on factors like screen size.")
                 .WithDefaultPosition("20")
                 .WithField(nameof(VisibilityPart.ResponsiveVisibility), field => field
                    .WithDisplayName("Responsive Visibility")
                    .OfType(nameof(TextField))
                    .WithEditor("PredefinedList")
                    .WithSettings(new TextFieldPredefinedListEditorSettings
                    {
                        DefaultValue = "",
                        Editor = EditorOption.Dropdown,
                        Options = new[]
                        {
                            new ListValueOption
                            {
                                Name = "Show at all sizes",
                                Value = "",
                            },
                            new ListValueOption
                            {
                                Name = "Large screens only",
                                Value = "responsive-display--large-only",
                            },
                            new ListValueOption
                            {
                                Name = "Small screens only",
                                Value = "responsive-display--small-only",
                            },
                        },
                    })));

            return 9;
        }

        public int UpdateFrom9()
        {
            _contentDefinitionManager.AlterPartDefinition(nameof(LinkBehaviourPart), builder => builder
                .Attachable()
                .WithDisplayName("Link Behaviour")
                .WithDescription("Define behaviour when user interacts with link.")
                .WithDefaultPosition("15")
                .WithField(nameof(LinkBehaviourPart.OpenIn), field => field
                    .WithDisplayName("Open In")
                    .OfType(nameof(TextField))
                    .WithSettings(new TextFieldSettings
                    {
                        Hint = "Define how you would like the link to open."
                    })
                    .WithEditor("PredefinedList")
                    .WithSettings(new TextFieldPredefinedListEditorSettings
                    {
                        DefaultValue = "_self",
                        Editor = EditorOption.Dropdown,
                        Options = new[]
                        {
                            new ListValueOption
                            {
                                Name = "Current window",
                                Value = "_self"
                            },
                            new ListValueOption
                            {
                                Name = "New window",
                                Value = "_blank",
                            },
                            new ListValueOption
                            {
                                Name = "Portrait Modal",
                                Value = "modal"
                            },
                            new ListValueOption
                            {
                                Name = "Landscape Modal",
                                Value = "modal-wide"
                            }
                        }
                    }))
                .WithField(nameof(LinkBehaviourPart.ClickEvent), field => field
                    .WithDisplayName("Click Event")
                    .OfType(nameof(CodeField))
                    .WithSettings(new CodeFieldSettings
                    {
                        Language= "javascript"
                    })));

            _contentDefinitionManager.AlterPartDefinition(nameof(LinkDestinationPart), builder => builder
                .Attachable()
                .WithDisplayName("Link Destination")
                .WithDescription("Define location user is navigated to when interacting with a linkable element.")
                .WithDefaultPosition("10")
                .WithField(nameof(LinkDestinationPart.DestinationUrl), field => field
                    .WithDisplayName("Link Url")
                    .OfType(nameof(TextField))
                    .WithSettings(new TextFieldSettings
                    {
                        Hint = "URL user is navigated to when selecting link. If left blank then item won't be linked."
                    })));

            return 10;
        }

        public int UpdateFrom10()
        {
            _contentDefinitionManager.AlterPartDefinition("LinkVisualPart", part => part
               .WithField("Style", field => field
                   .WithSettings(new TextFieldPredefinedListEditorSettings
                   {
                       Editor = EditorOption.Dropdown,
                       Options = new ListValueOption[] {
                           new ListValueOption {
                               Name = "Default",
                               Value = string.Empty
                           },
                           new ListValueOption {
                               Name = "Primary Button",
                               Value = "btn btn--primary"
                           },
                           new ListValueOption {
                               Name = "Secondary Button",
                               Value = "btn btn--secondary"
                           }
                       }
                   })
               )
            );

            return 11;
        }
        
        public int UpdateFrom11()
        {
            _contentDefinitionManager.AlterPartDefinition("SharedGalleryItem", builder => builder
                .WithField("SharedGallery", field => field
                    .WithDisplayName("Shared Gallery")
                    .OfType(nameof(ContentPickerField))
                    .WithSettings(new ContentPickerFieldSettings
                    {
                        DisplayedContentTypes = new string[] { "SharedGallery" }
                    })));

            _contentDefinitionManager.AlterTypeDefinition("SharedGalleryItem", builder => builder
                .WithPart("SharedGalleryItem", part => part
                   .WithPosition("0"))
                   .MergeSettings(JObject.FromObject(new
                   {
                       Category = "Content",
                       Description = "Add items from a shared gallery, known as a 'Shared Gallery'",
                       Icon = "image"
                   })));

            _contentDefinitionManager.AlterTypeDefinition("SharedGallery", builder => builder
                .WithPart(nameof(TitlePart), builder => builder
                   .WithPosition("0"))
                .WithPart("SharedGallery", builder => builder
                    .WithPosition("1"))
                .WithSettings(new ContentTypeSettings
                {
                    Creatable = true,
                    Draftable = true,
                    Listable = true,
                    Securable = true,
                    Versionable = true
                })
                .WithPart("Items", nameof(BagPart), part => part
                    .WithDisplayName("Items")
                    .WithPosition("2")
                    .WithDescription("Specify items for this gallery")
                    .WithSettings(new BagPartSettings
                    {
                        ContainedContentTypes = new string[] { "GalleryEmbedItem", "GalleryMediaItem" }
                    })));

            _contentDefinitionManager.AlterTypeDefinition("Gallery", builder => builder
                .WithPart("Items", nameof(BagPart), builder => builder
                    .WithDisplayName("Items")
                    .WithSettings(new BagPartSettings
                    {
                        ContainedContentTypes = new string[] { "GalleryEmbedItem", "GalleryMediaItem", "SharedGalleryItem" }
                    })));

            return 12;
        }

        public int UpdateFrom12()
        {
            _contentDefinitionManager.AlterPartDefinition(nameof(Heading), builder => builder
                .WithField(nameof(Heading.Emphasize), field => field
                    .OfType(nameof(Fields.Values.Fields.ValuesField))
                    .WithSettings(new ValuesFieldSettings
                    {
                        EmptyMessage = "Currently no text will be emphasized.",
                        Hint = "Content within the heading text that should be given emphasis.",
                        NewItemPlaceholder = "Text matching is case sensitive."
                    })
                    .WithDisplayName("Emphasize")
                    .WithPosition("5")));
                    
            return 13;
        }
    }
}