using OrchardCore.Modules.Manifest;

[assembly: Module(
    Name = "Common Widgets",
    Author = "Moov2",
    Website = "https://moov2.com",
    Version = "0.2.1"
)]

[assembly: Feature(
    Id = "Moov2.OrchardCore.Widgets",
    Name = "Common Widgets",
    Description = "Provides widgets commonly found on web pages.",
    Dependencies = new[] { "OrchardCore.Widgets", "OrchardCore.Flows", "OrchardCore.Html" },
    Category = "Content"
)]