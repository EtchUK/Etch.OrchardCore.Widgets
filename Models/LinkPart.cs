using OrchardCore.ContentManagement;
using System.ComponentModel.DataAnnotations;

namespace Etch.OrchardCore.Widgets.Models
{
    public class LinkPart : ContentPart
    {
        [Required]
        public string Text { get; set; }

        [Required]
        public string Url { get; set; }
    }
}
