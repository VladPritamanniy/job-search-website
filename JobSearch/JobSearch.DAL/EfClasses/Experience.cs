using System.ComponentModel.DataAnnotations;

namespace JobSearch.DAL.EfClasses;

public class Experience
{
    public int ExperienceId { get; set; }

    [MaxLength(256)]
    public string Name { get; set; }
}
