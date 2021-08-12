using Microsoft.EntityFrameworkCore;
using DataAccessLayer.Models;

namespace DataAccessLayer.Setups
{
    public class EFCoreContext : DbContext
    {
        public DbSet<StudentsInfoDTO> StudentsInfos { get; set; }
        public DbSet<UserDTO> Users { get; set; }

        public EFCoreContext(DbContextOptions<EFCoreContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
