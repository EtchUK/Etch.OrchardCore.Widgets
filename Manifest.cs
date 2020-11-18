using OrchardCore.Modules.Manifest;

[assembly: Module(
    Name = "Common Widgets",
    Author = "Etch",
    Website = "https://etchuk.com",
    Version = "0.10.2"
)]

[assembly: Feature(
    Id = "Etch.OrchardCore.Widgets",
    Name = "Common Widgets",
    Description = "Provides widgets commonly found on web pages.",
    Dependencies = new[] { "OrchardCore.Widgets", "OrchardCore.Flows", "OrchardCore.Html", "Etch.OrchardCore.Blocks", "Etch.OrchardCore.Fields.CodeField", "Etch.OrchardCore.Fields.ResponsiveMedia" },
    Category = "Content"
)]