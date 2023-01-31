using Etch.OrchardCore.Fields.Code.Fields;
using OrchardCore.ContentFields.Fields;
using OrchardCore.ContentManagement;

namespace Etch.OrchardCore.Widgets.Models
{
    public class LinkBehaviourPart : ContentPart
    {
        public CodeField ClickEvent { get; set; }
        public TextField OpenIn { get; set; }
    }
}