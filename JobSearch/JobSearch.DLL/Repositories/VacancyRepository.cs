using JobSearch.DLL.Context;
using JobSearch.DLL.EfClasses;
using JobSearch.DLL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JobSearch.DLL.Repositories
{
    public class VacancyRepository : IVacancyRepository
    {
        private readonly JobSearchContext _context;

        public VacancyRepository(JobSearchContext context)
        {
            _context = context;
        }

        public async Task CreateOrUpdateIfExist(Vacancy vacancy)
        {
            if (await GetById(vacancy.VacancyId) != null)
            {
                await Update(vacancy);
            }
            else
            {
                await _context.Vacancies.AddAsync(vacancy);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<Vacancy> GetById(int id)
        {
            return await _context.Vacancies.AsNoTracking().SingleOrDefaultAsync(v => v.VacancyId == id);
        }

        public async Task<IEnumerable<Vacancy>> GetAll()
        {
            return await _context.Vacancies.AsNoTracking().ToListAsync();
        }

        public async Task Delete(int id)
        {
            await _context.Vacancies.Where(v => v.VacancyId == id).ExecuteDeleteAsync();
            await _context.SaveChangesAsync();
        }

        private async Task Update(Vacancy vacancy)
        {
            await _context.Vacancies.Where(v => v.VacancyId == vacancy.VacancyId).ExecuteUpdateAsync(s => s
                .SetProperty(v => v.Title, vacancy.Title)
                .SetProperty(v => v.Description, vacancy.Description)
                .SetProperty(v => v.ExperienceId, vacancy.ExperienceId)
                .SetProperty(v => v.EmploymentTypeId, vacancy.EmploymentTypeId)
                .SetProperty(v => v.PublicationDate, vacancy.PublicationDate)
                .SetProperty(v => v.IsPublished, vacancy.IsPublished)
                .SetProperty(v => v.FormatId, vacancy.FormatId)
            );
        }

        public async Task AddResponse(VacancyResponse response)
        {
            await _context.VacancyResponses.AddAsync(response);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<VacancyResponse>> GetResponsesByVacancyId(int id)
        {
            return await _context.VacancyResponses.AsNoTracking().Where(vr => vr.VacancyId == id).ToListAsync();
        }

        public async Task<byte[]> GetResumeById(int id)
        {
            return await _context.VacancyResponses
                                 .AsNoTracking()
                                 .Where(vr => vr.VacancyResponseId == id)
                                 .Select(vr => vr.Resume)
                                 .SingleAsync();
                                 }
    }
}
