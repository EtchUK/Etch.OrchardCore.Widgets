using Moov2.OrchardCore.Widgets.Models;
using Moov2.OrchardCore.Widgets.ViewModels;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.ContentManagement.Display.Models;
using OrchardCore.DisplayManagement.ModelBinding;
using OrchardCore.DisplayManagement.Views;
using System.Threading.Tasks;

namespace Moov2.OrchardCore.Widgets.Drivers
{
    public class SectionPartDisplay : ContentPartDisplayDriver<SectionPart>
    {
        public override IDisplayResult Edit(SectionPart part, BuildPartEditorContext context)
        {
            return Initialize<SectionPartEditViewModel>("SectionPart_Fields_Edit", m =>
            {
                
            });
        }

        public async override Task<IDisplayResult> UpdateAsync(SectionPart part, IUpdateModel updater)
        {
            var viewModel = new SectionPartEditViewModel();

            if (await updater.TryUpdateModelAsync(viewModel, Prefix))
            {

            }

            return Edit(part);
        }
    }
}
