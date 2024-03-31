using System.ComponentModel.DataAnnotations;

namespace JobSearch.WEB.Models.Enums
{
    public enum EmploymentTypeEnum
    {
        [Display(ResourceType = typeof(Resources.Resource), Name = "FullEmployment")]
        FullEmployment = 1,
        [Display(ResourceType = typeof(Resources.Resource), Name = "PartTimeEmployment")]
        PartTimeEmployment = 2,
        [Display(ResourceType = typeof(Resources.Resource), Name = "Internship")]
        Internship = 3
    }
}
