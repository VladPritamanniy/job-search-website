using JobHub.DAL.Data.DBObjects;
using JobHub.DAL.DataQueries;

namespace JobHub.BLL.WrapperQuery
{
    public partial class WrapperQuery
    {
        public static class WrapperVacancy
        {
            public static IEnumerable<DBVacancy> GetList()
            {
                return DataQuery.VacancyQuery.GetList();
            }

            public static DBVacancy GetItem(int id)
            {
                return DataQuery.VacancyQuery.GetItem(id);
            }

        }
    }
}
