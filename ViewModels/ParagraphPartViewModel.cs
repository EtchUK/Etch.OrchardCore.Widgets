using Microsoft.AspNetCore.Mvc.ModelBinding;
using Moov2.OrchardCore.Widgets.Models;

namespace Moov2.OrchardCore.Widgets.ViewModels
{
    public class ParagraphPartViewModel
    {
        public string Text { get; set; }

        [BindNever]
        public ParagraphPart ParagraphPart {get; set; }
    }
}
