using Microsoft.EntityFrameworkCore;

namespace EAD_PredictionTool.Models
{
    public class Break_Context : DbContext
    {
        public Break_Context(DbContextOptions<Break_Context> options) : base(options)
        {
        }

        public DbSet<Break> Breaks { get; set; }
    }
}
