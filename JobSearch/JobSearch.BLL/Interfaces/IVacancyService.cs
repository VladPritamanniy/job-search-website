using JobSearch.BLL.DTO;

namespace JobSearch.BLL.Interfaces
{
    public interface IVacancyService
    {
        Task<VacancyDto> Get(int id);

        Task CreateOrUpdateIfExist(VacancyDto vacancyDto);

        Task Delete(int id);

        Task<IEnumerable<VacancyDto>> GetAll();

        Task<IEnumerable<VacancyDto>> GetAll(int pageNumber, int pageSize, string searchString);

        int GetCount();

        int GetCount(string searchString);

        Task AddResponse(VacancyResponseDto responseDto);

        Task<IEnumerable<VacancyResponseDto>> GetResponsesByVacancyId(int id);

        Task<byte[]> GetResumeById(int id);
    }
}
