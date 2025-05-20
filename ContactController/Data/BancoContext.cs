using ContactController.Data.Map;
using ContactController.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactController.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        { }

        public DbSet<ContactModel> Contact { get; set; }
        public DbSet<UserModel> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ContactMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
