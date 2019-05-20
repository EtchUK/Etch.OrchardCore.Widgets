using Etch.OrchardCore.Widgets.Models;
using Etch.OrchardCore.Widgets.ViewModels;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.ContentManagement.Display.Models;
using OrchardCore.DisplayManagement.ModelBinding;
using OrchardCore.DisplayManagement.Views;
using System.Threading.Tasks;

namespace Etch.OrchardCore.Widgets.Drivers
{
    public class ParagraphPartDisplay : ContentPartDisplayDriver<ParagraphPart>
    {
        private const int DisplayTextSubStringLength = 50;

        public override IDisplayResult Display(ParagraphPart part)
        {
            return Initialize<ParagraphPartViewModel>("ParagraphPart", model =>
            {
                model.Text = part.Text;
                model.ParagraphPart = part;
            })
            .Location("Detail", "Header:5")
            .Location("Summary", "Header:5");
        }

        public override IDisplayResult Edit(ParagraphPart part, BuildPartEditorContext context)
        {
            return Initialize<ParagraphPartViewModel>("ParagraphPart_Fields_Edit", m =>
            {
                m.Text = part.Text;
            });
        }

        public async override Task<IDisplayResult> UpdateAsync(ParagraphPart part, IUpdateModel updater)
        {
            var viewModel = new ParagraphPartViewModel();

            if (await updater.TryUpdateModelAsync(viewModel, Prefix))
            {
                part.Text = viewModel.Text?.Trim();
            }

            part.ContentItem.DisplayText = part.Text.Length > DisplayTextSubStringLength ? $"{part.Text.Substring(0, DisplayTextSubStringLength)}..." : part.Text;

            return Edit(part);
        }
    }
}
