using System.ComponentModel.DataAnnotations;

namespace JobSearch.DLL.EfClasses;

public class Vacancy
{
    public int VacancyId { get; set; }

    [MaxLength(256)]
    public string Title { get; set; }

    public string Description { get; set; }

    public DateTime CreationDate { get; set; }

    public DateTime? PublicationDate { get; set; }

    public bool IsPublished { get; set; }

    public int FormatId { get; set; }

    public int ExperienceId { get; set; }

    public int EmploymentTypeId { get; set; }

    public EmploymentType EmploymentType { get; set; }

    public Experience Experience { get; set; }

    public WorkFormat Format { get; set; }

    public ICollection<VacancyResponse> VacancyResponses { get; set; }
}
