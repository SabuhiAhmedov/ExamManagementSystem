using ExamManagementSystem.Application.Abstractions;
using ExamManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ExamManagementSystem.Persistence.AppDbContext
{
    public class ExamsDbContext : DbContext
    {
        public ExamsDbContext(DbContextOptions context) : base(context)
        {

        }

        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Exam> Exams { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(opt =>
            {
                opt.MigrationsHistoryTable("__EFMigrationsHistory", "ExamManagementSystemDB");
            });

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
    }
}
