using JobSearch.DAL.EfClasses;

namespace JobSearch.DAL.Repositories.QueryObjects
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
