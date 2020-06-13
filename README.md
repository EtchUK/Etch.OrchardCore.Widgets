# Etch.OrchardCore.Widgets

Module for [Orchard Core](https://github.com/OrchardCMS/OrchardCore) that provides common widgets used when constructing a web page.

## Build Status

[![Build Status](https://secure.travis-ci.org/etchuk/Etch.OrchardCore.Widgets.png?branch=master)](http://travis-ci.org/etchuk/Etch.OrchardCore.Widgets) [![NuGet](https://img.shields.io/nuget/v/Etch.OrchardCore.Widgets.svg)](https://www.nuget.org/packages/Etch.OrchardCore.Widgets)

## Orchard Core Reference

This module is referencing the RC2 build of Orchard Core ([`1.0.0-rc2-13450`](https://www.nuget.org/packages/OrchardCore.Module.Targets/1.0.0-rc2-13450)).

## Installing

This module is available on [NuGet](https://www.nuget.org/packages/Etch.OrchardCore.Widgets). Add a reference to your Orchard Core web project via the NuGet package manager. Search for "Etch.OrchardCore.Widgets", ensuring include prereleases is checked.

### Configuration

#### Content Definitions

Content definitions provided by this module have to be manually by either running the content definitions recipe, adding the content definitions to your own setup recipe or running the content definitions recipe in this module within a custom setup recipe.

#### Hero

The "Hero" widget uses a [responsive media field](https://github.com/EtchUK/Etch.OrchardCore.Fields#responsive-media) that represents the images displayed for the background. The responsive media field requires additional project configuration to cater for resizing images via the `width` query string when accessing the media. To make the hero breakpoints work with the image resize the various sizes need to be defined in the application settings. The below snippet should be included in the `appsettings.json` for your Orchard Core web project.

```
{
  "OrchardCore": {
    "OrchardCore.Media": {
      "SupportedSizes": [ 375, 425, 600, 768, 1024, 1280, 1440, 1920, 2560 ]
    }
  }
}
```

These breakpoints can be configured within the field settings, however any ammendments should also be applied to the `appsettings.json` file.
