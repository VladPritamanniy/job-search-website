using AutoMapper;
using JobSearch.BLL.DTO;
using JobSearch.BLL.Interfaces;
using JobSearch.DLL.Entities;
using JobSearch.DLL.Interfaces;

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

        public async Task<Vacancy> Get(int id)
        {
            var vacancy = await _vacancyRepository.GetById(id);
            return _mapper.Map<Vacancy>(vacancy);
        }

        public async Task Create(Vacancy vacancy)
        {
            await _vacancyRepository.Add(_mapper.Map<VacancyEntity>(vacancy));
        }

        public async Task Delete(int id)
        {
            await _vacancyRepository.Delete(id);
        }

        public async Task<IEnumerable<Vacancy>> GetAll()
        {
            var vacancies = await _vacancyRepository.GetAll();
            return _mapper.Map<IEnumerable<Vacancy>>(vacancies);
        }

        public async Task AddResponse(VacancyResponse response)
        {
            await _vacancyRepository.AddResponse(_mapper.Map<VacancyResponseEntity>(response));
        }

        public async Task<IEnumerable<VacancyResponse>> GetResponsesByVacancyId(int id)
        {
            var responses = await _vacancyRepository.GetResponsesByVacancyId(id);
            return _mapper.Map<IEnumerable<VacancyResponse>>(responses);
        }

        public async Task<byte[]> GetResumeById(int id)
        {
            return await _vacancyRepository.GetResumeById(id);
        }
    }
}
