using JobSearch.BLL.DTO;

namespace JobSearch.BLL.Interfaces
{
    public interface IVacancyService
    {
        Task<Vacancy> Get(int id);

        Task Create(Vacancy vacancy);

        Task Delete(int id);

        Task<IEnumerable<Vacancy>> GetAll();

        Task AddResponse(VacancyResponse response);

        Task<IEnumerable<VacancyResponse>> GetResponsesByVacancyId(int id);

        Task<byte[]> GetResumeById(int id);
    }
}
