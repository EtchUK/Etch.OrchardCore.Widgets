using Microsoft.AspNetCore.Mvc.ModelBinding;
using Moov2.OrchardCore.Widgets.Models;

namespace Moov2.OrchardCore.Widgets.ViewModels
{
    public class LinkPartViewModel
    {
        public string Text { get; set; }
        public string Url { get; set; }

        [BindNever]
        public LinkPart LinkPart { get; set; }
    }
}
