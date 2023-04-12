using Microsoft.EntityFrameworkCore;

namespace PA.Education.Dal.Models; 

public class EducationDbContext : DbContext{

    public EducationDbContext(DbContextOptions<EducationDbContext> options):  base(options)
    {

    }
    public DbSet<Lecture> Lectures { get; set; }
    

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        optionsBuilder.UseSqlServer(
                    @"Data Source=.\SQLEXPRESS;Initial Catalog=EducationDb;Integrated Security=True;TrustServerCertificate=true;",
                    providerOptions => { providerOptions.EnableRetryOnFailure(); });
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        base.OnModelCreating(modelBuilder);
    }
}