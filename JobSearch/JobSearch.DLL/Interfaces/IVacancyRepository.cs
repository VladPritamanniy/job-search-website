using JobSearch.DLL.Entities;

namespace JobSearch.DLL.Interfaces
{
    public interface IVacancyRepository
    {
        Task Add(VacancyEntity vacancy);

        Task<VacancyEntity> GetById(int id);

        Task<IEnumerable<VacancyEntity>> GetAll();

        Task Delete(int id);

        Task Update(VacancyEntity vacancy);

        Task AddResponse(VacancyResponseEntity response);

        Task<IEnumerable<VacancyResponseEntity>> GetResponsesByVacancyId(int id);

        Task<byte[]> GetResumeById(int id);
    }
}
