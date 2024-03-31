using JobSearch.DLL.Context;
using JobSearch.DLL.Entities;
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

        public async Task Add(VacancyEntity vacancy)
        {
            if (await GetById(vacancy.Id) != null)
            {
                await Update(vacancy);
            }
            else
            {
                await _context.Vacancies.AddAsync(vacancy);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<VacancyEntity> GetById(int id)
        {
            return await _context.Vacancies.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<VacancyEntity>> GetAll()
        {
            return await _context.Vacancies.AsNoTracking().ToListAsync();
        }

        public async Task Delete(int id)
        {
            await _context.Vacancies.Where(c => c.Id == id).ExecuteDeleteAsync();
            await _context.SaveChangesAsync();
        }

        public async Task Update(VacancyEntity vacancy)
        {
            await _context.Vacancies.Where(c => c.Id == vacancy.Id).ExecuteUpdateAsync(s => s
                .SetProperty(c => c.Title, vacancy.Title)
                .SetProperty(c => c.Description, vacancy.Description)
                .SetProperty(c => c.ExperienceId, vacancy.ExperienceId)
                .SetProperty(c => c.EmploymentTypeId, vacancy.EmploymentTypeId)
                .SetProperty(c => c.PublicationDate, vacancy.PublicationDate)
                .SetProperty(c => c.IsPublished, vacancy.IsPublished)
                .SetProperty(c => c.FormatId, vacancy.FormatId)
            );
        }

        public async Task AddResponse(VacancyResponseEntity response)
        {
            await _context.VacancyResponses.AddAsync(response);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<VacancyResponseEntity>> GetResponsesByVacancyId(int id)
        {
            return await _context.VacancyResponses.AsNoTracking().Where(c => c.VacancyId == id).ToListAsync();
        }

        public async Task<byte[]> GetResumeById(int id)
        {
            return await _context.VacancyResponses
                            .Where(vr => vr.Id == id)
                            .Select(vr => vr.Resume)
                            .FirstOrDefaultAsync();
                    }
    }
}
