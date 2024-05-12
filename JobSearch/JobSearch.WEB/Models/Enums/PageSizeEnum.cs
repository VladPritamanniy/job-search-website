using System.ComponentModel.DataAnnotations;

namespace JobSearch.WEB.Models.Enums
{
    public enum PageSizeEnum
    {
        [Display (Name = "5")]
        Five = 5,
        [Display(Name = "10")]
        Ten = 10,
        [Display(Name = "15")]
        Fifteen = 15,
        [Display(Name = "20")]
        Twenty = 20
    }
}
