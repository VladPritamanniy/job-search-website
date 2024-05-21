using JobSearch.DLL.EfClasses;

namespace JobSearch.DLL.Repositories.QueryObjects
{
    static class QueryPaging
    {
        public static IQueryable<Vacancy> Page
        (this IQueryable<Vacancy> vacancies,
            int pageNumber, int pageSize)
        {
            return vacancies
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize);
        }
    }
}
