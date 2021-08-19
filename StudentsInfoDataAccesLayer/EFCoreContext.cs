using Microsoft.EntityFrameworkCore;
using DataAccessLayer.Models;

namespace DataAccessLayer.Setups
{
    public class EFCoreContext : DbContext
    {
        public DbSet<StudentsInfoDTO> StudentsInfos { get; set; }
        public DbSet<UserDTO> Users { get; set; }
        public DbSet<EmailDTO> Emails { get; set; }
        public DbSet<UserRoles> UserRoles { get; set; }
        public DbSet<Role> Roles { get; set; }

        public EFCoreContext(DbContextOptions<EFCoreContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRoles>()
                .HasKey(x => new { x.UserId, x.RoleId });
        }
    }
}
