using JobHub.DAL.Data.DBObjects;
using JobHub.DAL.DataQueries;

namespace JobHub.BLL.WrapperQuery
{
    public partial class WrapperQuery
    {
        public static class WrapperVacancy
        {
            public static IEnumerable<DBVacancy> GetVacancy()
            {
                return DataQuery.VacancyQuery.GetVacancy();
            }

        }
    }
}
