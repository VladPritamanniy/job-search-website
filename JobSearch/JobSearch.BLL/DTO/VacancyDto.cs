namespace JobSearch.BLL.DTO
{
    public class VacancyDto
    {
        public int VacancyId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime? PublicationDate { get; set; }

        public int IsPublished { get; set; }

        public int? FormatId { get; set; }

        public int? ExperienceId { get; set; }

        public int? EmploymentTypeId { get; set; }
    }
}
