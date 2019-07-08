using OrchardCore.ContentManagement.Metadata;
using OrchardCore.ContentManagement.Metadata.Settings;
using OrchardCore.Data.Migration;
using OrchardCore.Recipes.Services;
using System.Threading.Tasks;

namespace Etch.OrchardCore.Widgets
{
    public class Migrations : DataMigration
    {
        private readonly IContentDefinitionManager _contentDefinitionManager;
        private readonly IRecipeMigrator _recipeMigrator;

        public Migrations(IContentDefinitionManager contentDefinitionManager, IRecipeMigrator recipeMigrator)
        {
            _contentDefinitionManager = contentDefinitionManager;
            _recipeMigrator = recipeMigrator;
        }

        public async Task<int> CreateAsync()
        {
            #region Html Attributes

            _contentDefinitionManager.AlterPartDefinition("HtmlAttributesPart", part => part
                .Attachable()
                .WithDescription("Customise common attributes on HTML element.")
                .WithDisplayName("HTML Attributes"));

            #endregion HtmlAttributes

            #region Run Recipe

            await _recipeMigrator.ExecuteAsync("create.recipe.json", this);

            #endregion Run Recipe

            return 1;
        }
    }
}