using JobSearch.DAL.EfClasses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobSearch.DAL.EfConfig
{
    public class VacancyConfig : IEntityTypeConfiguration<Vacancy>
    {
        public void Configure(EntityTypeBuilder<Vacancy> builder)
        {
            builder.HasOne(p => p.EmploymentType)
                .WithOne()
                .HasForeignKey<Vacancy>(p => p.EmploymentTypeId);

            builder.HasOne(p => p.Experience)
                .WithOne()
                .HasForeignKey<Vacancy>(p => p.ExperienceId);

            builder.HasOne(p => p.Format)
                .WithOne()
                .HasForeignKey<Vacancy>(p => p.FormatId);

            builder.HasMany(p => p.VacancyResponses)
                .WithOne()
                .HasForeignKey(p => p.VacancyId);

            builder.Property(p => p.IsPublished).HasDefaultValue(0);
            builder.Property(p => p.CreationDate).HasDefaultValueSql("getdate()");
            builder.Property(p => p.Description).HasColumnType("ntext");
        }
    }
}
