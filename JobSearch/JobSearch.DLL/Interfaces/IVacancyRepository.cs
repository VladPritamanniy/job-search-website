using JobSearch.DLL.EfClasses;

namespace JobSearch.DLL.Interfaces
{
    public interface IVacancyRepository
    {
        Task CreateOrUpdateIfExist(Vacancy vacancy);

        Task<Vacancy> GetById(int id);

        Task<IEnumerable<Vacancy>> GetAll();

        Task Delete(int id);

        Task AddResponse(VacancyResponse response);

        Task<IEnumerable<VacancyResponse>> GetResponsesByVacancyId(int id);

        Task<byte[]> GetResumeById(int id);
    }
}
