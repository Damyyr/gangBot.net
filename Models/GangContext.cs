using Microsoft.EntityFrameworkCore;

namespace GangBot.net.Models
{
    public class GangContext : DbContext
    {
        public GangContext(DbContextOptions<GangContext> options)
            : base(options)
        {
        }

        public DbSet<CodeName> TodoItems { get; set; }
    }
}