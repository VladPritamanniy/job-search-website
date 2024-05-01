using JobSearch.DLL.EfClasses;

namespace JobSearch.DLL.Interfaces
{
    public interface IVacancyRepository
    {
        Task Add(Vacancy vacancy);

        Task<Vacancy> GetById(int id);

        Task<IEnumerable<Vacancy>> GetAll();

        Task Delete(int id);

        Task Update(Vacancy vacancy);

        Task AddResponse(VacancyResponse response);

        Task<IEnumerable<VacancyResponse>> GetResponsesByVacancyId(int id);

        Task<byte[]> GetResumeById(int id);
    }
}
