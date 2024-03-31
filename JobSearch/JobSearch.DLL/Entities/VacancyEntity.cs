namespace JobSearch.DLL.Entities;

public class VacancyEntity
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public DateTime? CreationDate { get; set; }

    public DateTime? PublicationDate { get; set; }

    public int? IsPublished { get; set; }

    public int FormatId { get; set; }

    public int ExperienceId { get; set; }

    public int EmploymentTypeId { get; set; }

    public virtual EmploymentTypeEntity EmploymentType { get; set; } = null!;

    public virtual ExperienceEntity Experience { get; set; } = null!;

    public virtual WorkFormatEntity Format { get; set; } = null!;

    public virtual ICollection<VacancyResponseEntity> VacancyResponses { get; set; } = new List<VacancyResponseEntity>();
}
