using Microsoft.AspNetCore.Mvc.ModelBinding;
using Etch.OrchardCore.Widgets.Models;
using System.ComponentModel.DataAnnotations;

namespace Etch.OrchardCore.Widgets.ViewModels
{
    public class HeadingPartViewModel
    {
        [Range(1, 6)]
        public int Level { get; set; }
        public string Text { get; set; }

        [BindNever]
        public HeadingPart HeadingPart { get; set; }
    }
}
