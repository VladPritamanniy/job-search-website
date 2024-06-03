using JobSearch.DAL.EfClasses;

namespace JobSearch.DAL.Repositories.QueryObjects
{
    static class QuerySearch
    {
        public static IQueryable<Vacancy> Search
        (this IQueryable<Vacancy> vacancies,
            string searchString)
        {
            if (!string.IsNullOrEmpty(searchString))
            {
                return vacancies.Where(p => p.Title.Contains(searchString) || p.Description.Contains(searchString));
            }
            return vacancies;
        }
    }
}
