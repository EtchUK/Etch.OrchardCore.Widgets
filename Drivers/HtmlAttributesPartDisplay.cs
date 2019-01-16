using Moov2.OrchardCore.Widgets.Models;
using Moov2.OrchardCore.Widgets.ViewModels;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.ContentManagement.Display.Models;
using OrchardCore.DisplayManagement.ModelBinding;
using OrchardCore.DisplayManagement.Views;
using System.Threading.Tasks;

namespace Moov2.OrchardCore.Widgets.Drivers
{
    public class HtmlAttributesPartDisplay : ContentPartDisplayDriver<HtmlAttributesPart>
    {
        public override IDisplayResult Edit(HtmlAttributesPart part, BuildPartEditorContext context)
        {
            return Initialize<HtmlAttributesPartEditViewModel>("HtmlAttributesPart_Fields_Edit", m =>
            {
                m.CssClasses = part.CssClasses;
                m.Id = part.Id;
            });
        }

        public async override Task<IDisplayResult> UpdateAsync(HtmlAttributesPart part, IUpdateModel updater)
        {
            var viewModel = new HtmlAttributesPartEditViewModel();

            if (await updater.TryUpdateModelAsync(viewModel, Prefix))
            {
                part.CssClasses = viewModel.CssClasses?.Trim();
                part.Id = viewModel.Id?.Trim();
            }

            return Edit(part);
        }
    }
}
