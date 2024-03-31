namespace JobSearch.DLL.Entities;

public class ExperienceEntity
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<VacancyEntity> Vacancies { get; set; } = new List<VacancyEntity>();
}
