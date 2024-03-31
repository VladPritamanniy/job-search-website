using System.ComponentModel.DataAnnotations;

namespace JobSearch.WEB.Models.Enums
{
    public enum ExperienceEnum
    {
        [Display(ResourceType = typeof(Resources.Resource), Name = "NoExperience")]
        NoExperience = 1,
        [Display(ResourceType = typeof(Resources.Resource), Name = "Less1Year")]
        Less1Year = 2,
        [Display(ResourceType = typeof(Resources.Resource), Name = "From1To2Years")]
        From1To2Years = 3,
        [Display(ResourceType = typeof(Resources.Resource), Name = "From3To5Years")]
        From3To5Years = 4,
        [Display(ResourceType = typeof(Resources.Resource), Name = "More5Years")]
        More5Years = 5
    }
}
