using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFHiLoPractise.Models
{
    public class HiLoContext : DbContext
    {
        public HiLoContext(DbContextOptions<HiLoContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<VipUser> VipUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>(ConfigUser);
            builder.Entity<VipUser>(ConfigVipUsers);
        }

        public void ConfigUser(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.Property(m => m.ID).ForSqlServerUseSequenceHiLo("sequence_test").IsRequired();
        }

        public void ConfigVipUsers(EntityTypeBuilder<VipUser> builder)
        {
            builder.ToTable("VipUsers");
            builder.Property(m => m.ID).ForSqlServerUseSequenceHiLo("sequence_test").IsRequired();
        }
    }
}
