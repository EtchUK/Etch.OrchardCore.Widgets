using Microsoft.AspNetCore.Mvc.Rendering;
using OrchardCore.ContentManagement;

namespace Moov2.OrchardCore.Widgets.Models
{
    public class HtmlAttributesPart : ContentPart
    {
        public string Id { get; set; }
        public string CssClasses { get; set; }

        public void ApplyToTagBuilder(TagBuilder tagBuilder)
        {
            if (!string.IsNullOrWhiteSpace(Id))
            {
                tagBuilder.Attributes.Add("id", Id);
            }

            if (!string.IsNullOrWhiteSpace(CssClasses))
            {
                tagBuilder.AddCssClass(CssClasses);
            }
        }
    }
}
