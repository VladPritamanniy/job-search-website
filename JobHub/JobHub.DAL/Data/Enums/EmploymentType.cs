using System.ComponentModel;

namespace JobHub.DAL.Data.Enums
{
    public enum EmploymentType
    {
        [Description("Повна зайнятість")]
        FullEmployment = 1,
        [Description("Неповна зайнятість")]
        Underemployment = 2,
        [Description("Проектна робота")]
        ProjectWork = 3,
        [Description("Змінна робота")]
        ShiftWork = 4
    }
}
