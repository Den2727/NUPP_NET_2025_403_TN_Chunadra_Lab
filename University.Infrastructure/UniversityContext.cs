using Microsoft.EntityFrameworkCore;
using University.Infrastructure.Models;

namespace University.Infrastructure;

public class UniversityContext : DbContext
{
    public DbSet<StudentModel> Students => Set<StudentModel>();
    public DbSet<TeacherModel> Teachers => Set<TeacherModel>();
    public DbSet<GroupModel> Groups => Set<GroupModel>();

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlite("Data Source=university.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PersonModel>()
            .UseTptMappingStrategy();

        modelBuilder.Entity<GroupModel>()
            .HasMany(g => g.Students)
            .WithOne(s => s.Group)
            .HasForeignKey(s => s.GroupId);
    }
}
