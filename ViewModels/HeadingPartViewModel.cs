using Microsoft.AspNetCore.Mvc.ModelBinding;
using Moov2.OrchardCore.Widgets.Models;
using System.ComponentModel.DataAnnotations;

namespace Moov2.OrchardCore.Widgets.ViewModels
{
    public class HeadingPartViewModel
    {
        [Range(1, 6)]
        public int Level { get; set; }
        public string Text { get; set; }

        [BindNever]
        public HeadingPart HeadingPart { get; set; }

        public string Tag
        {
            get { return $"h{Level}"; }
        }
    }
}
