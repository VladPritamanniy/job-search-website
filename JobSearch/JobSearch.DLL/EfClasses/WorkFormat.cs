using System.ComponentModel.DataAnnotations;

namespace JobSearch.DLL.EfClasses;

public class WorkFormat
{
    public int WorkFormatId { get; set; }

    [MaxLength(256)]
    public string Name { get; set; } = null!;
}
