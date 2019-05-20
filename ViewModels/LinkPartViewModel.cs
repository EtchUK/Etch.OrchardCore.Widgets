using Microsoft.AspNetCore.Mvc.ModelBinding;
using Etch.OrchardCore.Widgets.Models;

namespace Etch.OrchardCore.Widgets.ViewModels
{
    public class LinkPartViewModel
    {
        public string Text { get; set; }
        public string Url { get; set; }

        [BindNever]
        public LinkPart LinkPart { get; set; }
    }
}
