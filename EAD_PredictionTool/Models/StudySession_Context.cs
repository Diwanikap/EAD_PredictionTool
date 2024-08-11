using Microsoft.EntityFrameworkCore;

namespace EAD_PredictionTool.Models
{
    public class StudySession_Context : DbContext
    {
        public StudySession_Context(DbContextOptions<StudySession_Context> options) : base(options)
        {
        }

        public DbSet<StudySession> StudySessions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudySession>().ToTable("StudySession");
        }

    }
}
