using JobSearch.BLL.DTO;

namespace JobSearch.BLL.Interfaces
{
    public interface IVacancyService
    {
        Task<VacancyDto> Get(int id);

        Task Create(VacancyDto vacancyDto);

        Task Delete(int id);

        Task<IEnumerable<VacancyDto>> GetAll();

        Task AddResponse(VacancyResponseDto responseDto);

        Task<IEnumerable<VacancyResponseDto>> GetResponsesByVacancyId(int id);

        Task<byte[]> GetResumeById(int id);
    }
}
