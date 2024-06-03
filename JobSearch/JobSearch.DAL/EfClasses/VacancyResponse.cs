using System.ComponentModel.DataAnnotations;

namespace JobSearch.DAL.EfClasses;

public class VacancyResponse
{
    public int VacancyResponseId { get; set; }

    [MaxLength(128)]
    public string FName { get; set; }

    [MaxLength(128)]
    public string LName { get; set; }

    public byte[] Resume { get; set; }

    [MaxLength(256)]
    public string CoverLetter { get; set; }

    public int VacancyId { get; set; }
}
