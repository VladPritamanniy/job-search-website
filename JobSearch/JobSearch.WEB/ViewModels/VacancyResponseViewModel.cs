using System.ComponentModel.DataAnnotations;

namespace JobSearch.WEB.ViewModels
{
    public class VacancyResponseViewModel
    {
        [Required(ErrorMessageResourceType = typeof(Resources.Resource), ErrorMessageResourceName = "Error_RequiredField")]
        public string FName { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Resource), ErrorMessageResourceName = "Error_RequiredField")]
        public string LName { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Resource), ErrorMessageResourceName = "Error_RequiredField")]
        public IFormFile Resume { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Resource), ErrorMessageResourceName = "Error_RequiredField")]
        public string CoverLetter { get; set; }
    }
}
