using OrchardCore.ContentFields.Fields;
using OrchardCore.ContentManagement;

namespace Etch.OrchardCore.Widgets.Models
{
    public class LinkDestinationPart : ContentPart
    {
        public TextField DestinationUrl { get; set; }
    }
}