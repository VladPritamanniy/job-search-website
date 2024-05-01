using System.ComponentModel.DataAnnotations;

namespace JobSearch.DLL.EfClasses;

public class EmploymentType
{
    public int EmploymentTypeId { get; set; }

    [MaxLength(256)]
    public string Name { get; set; }
}
