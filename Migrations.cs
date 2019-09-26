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

            await _recipeMigrator.ExecuteAsync("create.recipe.json", this);

            return 4;
        }

        public int UpdateFrom1()
        {
            // previous recipes were created pre RC1 where content type/part/field
            // settings had a breaking API change
            //await _recipeMigrator.ExecuteAsync("1.recipe.json", this);

            return 2;
        }

        public int UpdateFrom2()
        {
            // previous recipes were created pre RC1 where content type/part/field
            // settings had a breaking API change
            //await _recipeMigrator.ExecuteAsync("2.recipe.json", this);

            return 3;
        }

        public async Task<int> UpdateFrom3Async()
        {
            #region Run Recipe

            await _recipeMigrator.ExecuteAsync("create.recipe.json", this);

            #endregion Run Recipe

            return 4;
        }
    }
}