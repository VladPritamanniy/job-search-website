using Humanizer.Localisation;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Resources;

namespace JobSearch.WEB.Models.Enums
{
    public enum WorkFormatEnum
    {
        [Display(ResourceType = typeof(Resources.Resource), Name = "RemoteWork")]
        RemoteWork = 1,
        [Display(ResourceType = typeof(Resources.Resource), Name = "OfficeWork")]
        OfficeWork = 2
    }
}
