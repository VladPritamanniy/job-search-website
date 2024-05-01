using JobSearch.WEB.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace JobSearch.WEB.Areas.Admin.Models
{
    public class VacancyViewModel
    {
        public int VacancyId { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Resource), ErrorMessageResourceName = "Error_RequiredField")]
        [DataType(DataType.Text)]
        public string Title { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Resource), ErrorMessageResourceName = "Error_RequiredField")]
        [DataType(DataType.Text)]
        public string Description { get; set; }

        public DateTime? PublicationDate { get; set; }

        public bool IsPublished { get; set; }

        public WorkFormatEnum FormatId { get; set; }

        public ExperienceEnum ExperienceId { get; set; }

        public EmploymentTypeEnum EmploymentTypeId { get; set; }
    }
}
