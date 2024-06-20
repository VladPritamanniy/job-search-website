using AutoMapper;
using JobSearch.BLL.DTO;
using JobSearch.BLL.Interfaces;
using JobSearch.DAL.EfClasses;
using JobSearch.DAL.Interfaces;

namespace JobSearch.BLL.Services
{
    public class VacancyService : IVacancyService
    {
        private readonly IMapper _mapper;
        private readonly IVacancyRepository _vacancyRepository;

        public VacancyService(IMapper mapper, IVacancyRepository vacancyRepository)
        {
            _mapper = mapper;
            _vacancyRepository = vacancyRepository;
        }

        public async Task<VacancyDto> Get(int id)
        {
            var vacancy = await _vacancyRepository.GetById(id);
            return _mapper.Map<VacancyDto>(vacancy);
        }

        public async Task CreateOrUpdateIfExist(VacancyDto vacancyDto)
        {
            await _vacancyRepository.CreateOrUpdateIfExist(_mapper.Map<Vacancy>(vacancyDto));
        }

        public async Task Delete(int id)
        {
            await _vacancyRepository.Delete(id);
        }

        public async Task<IEnumerable<VacancyDto>> GetAll()
        {
            var vacancies = await _vacancyRepository.GetAll();
            return _mapper.Map<IEnumerable<VacancyDto>>(vacancies);
        }

        public async Task<IEnumerable<VacancyDto>> GetAll(int pageNumber, int pageSize, string searchString)
        {
            var vacancies = await _vacancyRepository.GetAll(pageNumber, pageSize, searchString);
            return _mapper.Map<IEnumerable<VacancyDto>>(vacancies);
        }

        public int GetCount()
        {
            return _vacancyRepository.GetCount();
        }

        public int GetCount(string searchString)
        {
            return _vacancyRepository.GetCount(searchString);
        }

        public async Task AddResponse(VacancyResponseDto responseDto)
        {
            await _vacancyRepository.AddResponse(_mapper.Map<VacancyResponse>(responseDto));
        }

        public async Task<IEnumerable<VacancyResponseDto>> GetResponsesByVacancyId(int id)
        {
            var responses = await _vacancyRepository.GetResponsesByVacancyId(id);
            return _mapper.Map<IEnumerable<VacancyResponseDto>>(responses);
        }

        public async Task<byte[]> GetResumeById(int id)
        {
            return await _vacancyRepository.GetResumeById(id);
        }
    }
}
