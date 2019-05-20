using Microsoft.AspNetCore.Mvc.ModelBinding;
using Etch.OrchardCore.Widgets.Models;

namespace Etch.OrchardCore.Widgets.ViewModels
{
    public class ParagraphPartViewModel
    {
        public string Text { get; set; }

        [BindNever]
        public ParagraphPart ParagraphPart {get; set; }
    }
}
