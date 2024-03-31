using JobSearch.DLL.Entities;
using Microsoft.EntityFrameworkCore;

namespace JobSearch.DLL.Context;

public partial class JobSearchContext : DbContext
{
    public JobSearchContext()
    {
    }

    public JobSearchContext(DbContextOptions<JobSearchContext> options)
        : base(options)
    {
    }

    public virtual DbSet<EmploymentTypeEntity> EmploymentTypes { get; set; }

    public virtual DbSet<ExperienceEntity> Experiences { get; set; }

    public virtual DbSet<UserEntity> Users { get; set; }

    public virtual DbSet<VacancyEntity> Vacancies { get; set; }

    public virtual DbSet<VacancyResponseEntity> VacancyResponses { get; set; }

    public virtual DbSet<WorkFormatEntity> WorkFormats { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=JobSearch;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Cyrillic_General_CI_AS");

        modelBuilder.Entity<EmploymentTypeEntity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Employme__3214EC07F46CC0DA");

            entity.ToTable("EmploymentType");

            entity.Property(e => e.Name).HasMaxLength(1000);
        });

        modelBuilder.Entity<ExperienceEntity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Experien__3214EC0704262731");

            entity.ToTable("Experience");

            entity.Property(e => e.Name).HasMaxLength(1000);
        });

        modelBuilder.Entity<UserEntity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC075BBA4D36");

            entity.Property(e => e.Email).HasMaxLength(1000);
            entity.Property(e => e.PasswordHash).HasMaxLength(1000);
            entity.Property(e => e.RefreshToken)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)");
            entity.Property(e => e.RefreshTokenExpiry)
                .HasDefaultValueSql("(NULL)")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<VacancyEntity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Vacancy__3214EC07097D1577");

            entity.ToTable("Vacancy");

            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Description).HasColumnType("ntext");
            entity.Property(e => e.IsPublished).HasDefaultValue(0);
            entity.Property(e => e.PublicationDate).HasColumnType("datetime");
            entity.Property(e => e.Title).HasMaxLength(1000);

            entity.HasOne(d => d.EmploymentType).WithMany(p => p.Vacancies)
                .HasForeignKey(d => d.EmploymentTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Vacancy__Employm__7B5B524B");

            entity.HasOne(d => d.Experience).WithMany(p => p.Vacancies)
                .HasForeignKey(d => d.ExperienceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Vacancy__Experie__7A672E12");

            entity.HasOne(d => d.Format).WithMany(p => p.Vacancies)
                .HasForeignKey(d => d.FormatId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Vacancy__FormatI__797309D9");
        });

        modelBuilder.Entity<VacancyResponseEntity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__VacancyR__3214EC079872BD01");

            entity.ToTable("VacancyResponse");

            entity.Property(e => e.CoverLetter).HasColumnType("ntext");
            entity.Property(e => e.Fname)
                .HasMaxLength(1000)
                .HasColumnName("FName");
            entity.Property(e => e.Lname)
                .HasMaxLength(1000)
                .HasColumnName("LName");

            entity.HasOne(d => d.Vacancy).WithMany(p => p.VacancyResponses)
                .HasForeignKey(d => d.VacancyId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__VacancyRe__Vacan__160F4887");
        });

        modelBuilder.Entity<WorkFormatEntity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__WorkForm__3214EC07C3E32564");

            entity.ToTable("WorkFormat");

            entity.Property(e => e.Name).HasMaxLength(1000);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
