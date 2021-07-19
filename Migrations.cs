using Etch.OrchardCore.Fields.Code.Fields;
using Etch.OrchardCore.Fields.Code.Settings;
using Etch.OrchardCore.Fields.Colour.Fields;
using Etch.OrchardCore.Fields.Colour.Settings;
using OrchardCore.ContentFields.Fields;
using OrchardCore.ContentFields.Settings;
using OrchardCore.ContentManagement.Metadata;
using OrchardCore.ContentManagement.Metadata.Settings;
using OrchardCore.Data.Migration;

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
                )
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
                        Hint = "Length of animation in seconds.",
                        Scale = 2
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
                        Hint = "Number of seconds to delay start of animation.",
                        Scale = 2
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
    }
}