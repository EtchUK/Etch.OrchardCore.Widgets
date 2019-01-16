using Moov2.OrchardCore.Widgets.Models;
using Moov2.OrchardCore.Widgets.ViewModels;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.ContentManagement.Display.Models;
using OrchardCore.DisplayManagement.ModelBinding;
using OrchardCore.DisplayManagement.Views;
using System.Threading.Tasks;

namespace Moov2.OrchardCore.Widgets.Drivers
{
    public class LinkPartDisplay : ContentPartDisplayDriver<LinkPart>
    {
        public override IDisplayResult Display(LinkPart part)
        {
            return Initialize<LinkPartViewModel>("LinkPart", model =>
            {
                model.Text = part.Text;
                model.Url = part.Url;
                model.LinkPart = part;
            })
            .Location("Detail", "Header:5")
            .Location("Summary", "Header:5");
        }

        public override IDisplayResult Edit(LinkPart part, BuildPartEditorContext context)
        {
            return Initialize<LinkPartViewModel>("LinkPart_Fields_Edit", m =>
            {
                m.Text = part.Text;
                m.Url = part.Url;
            });
        }

        public async override Task<IDisplayResult> UpdateAsync(LinkPart part, IUpdateModel updater)
        {
            var viewModel = new LinkPartViewModel();

            if (await updater.TryUpdateModelAsync(viewModel, Prefix))
            {
                part.Text = viewModel.Text?.Trim();
                part.Url = viewModel.Url?.Trim();
            }

            part.ContentItem.DisplayText = part.Text;

            return Edit(part);
        }
    }
}
