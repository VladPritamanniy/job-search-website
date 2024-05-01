using JobSearch.DLL.EfClasses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobSearch.DLL.EfConfig
{
    public class VacancyResponseConfig : IEntityTypeConfiguration<VacancyResponse>
    {
        public void Configure(EntityTypeBuilder<VacancyResponse> builder)
        {
            builder.Property(p => p.CoverLetter).HasColumnName("ntext");
            builder.Property(p => p.Resume).HasColumnName("varbinary(max)");
        }
    }
}
