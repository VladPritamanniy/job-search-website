using System.ComponentModel;

namespace JobHub.DAL.Data.Enums
{
    public enum Currency
    {
        [Description("$")]
        USD = 1,
        [Description("\u20ac")]
        EUR = 2,
        [Description("\u00a3")]
        GBP = 3
    }
}
