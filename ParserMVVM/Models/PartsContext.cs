using Microsoft.EntityFrameworkCore;

namespace ParserMVVM.Models
{
    class PartsContext : DbContext
    {
        public DbSet<Part> Parts { get; set; }
        public DbSet<LinkPart> LinkParts { get; set; }
        public PartsContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;UserId=root;Password=2128506;database=partsdb;");
        }
    }
}
