using JobSearch.WEB.Models.Enums;

namespace JobSearch.WEB.Models
{
    public class VacancyModel
    {
        public int VacancyId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime? PublicationDate { get; set; }

        public bool IsPublished { get; set; }

        public WorkFormatEnum FormatId { get; set; }

        public ExperienceEnum ExperienceId { get; set; }

        public EmploymentTypeEnum EmploymentTypeId { get; set; }
    }
}
