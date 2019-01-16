using Moov2.OrchardCore.Widgets.Models;
using Moov2.OrchardCore.Widgets.ViewModels;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.ContentManagement.Display.Models;
using OrchardCore.DisplayManagement.ModelBinding;
using OrchardCore.DisplayManagement.Views;
using System.Threading.Tasks;

namespace Moov2.OrchardCore.Widgets.Drivers
{
    public class HeadingPartDisplay : ContentPartDisplayDriver<HeadingPart>
    {
        public override IDisplayResult Display(HeadingPart headingPart)
        {
            return Initialize<HeadingPartViewModel>("HeadingPart", model =>
            {
                model.Text = headingPart.Text;
                model.Level = headingPart.Level;
                model.HeadingPart = headingPart;
            })
            .Location("Detail", "Header:5")
            .Location("Summary", "Header:5");
        }

        public override IDisplayResult Edit(HeadingPart part, BuildPartEditorContext context)
        {
            return Initialize<HeadingPartViewModel>("HeadingPart_Fields_Edit", m =>
            {
                m.Level = part.Level;
                m.Text = part.Text;
            });
        }

        public async override Task<IDisplayResult> UpdateAsync(HeadingPart part, IUpdateModel updater)
        {
            var viewModel = new HeadingPartViewModel();

            if (await updater.TryUpdateModelAsync(viewModel, Prefix))
            {
                part.Level = viewModel.Level;
                part.Text = viewModel.Text?.Trim();
            }

            part.ContentItem.DisplayText = part.Text;

            return Edit(part);
        }
    }
}
