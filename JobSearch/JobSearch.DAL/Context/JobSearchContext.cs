using System.Reflection;
using JobSearch.DAL.EfClasses;
using Microsoft.EntityFrameworkCore;

namespace JobSearch.DAL.Context;

public class JobSearchContext : DbContext
{
    public JobSearchContext(DbContextOptions<JobSearchContext> options)
        : base(options)
    {
    }

    public DbSet<EmploymentType> EmploymentTypes { get; set; }

    public DbSet<Experience> Experiences { get; set; }

    public DbSet<User> Users { get; set; }

    public DbSet<Vacancy> Vacancies { get; set; }

    public DbSet<VacancyResponse> VacancyResponses { get; set; }

    public DbSet<WorkFormat> WorkFormats { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
