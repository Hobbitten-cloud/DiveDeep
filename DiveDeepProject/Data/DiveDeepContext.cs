using DiveDeepProject.Models.Domain;
using DiveDeepProject.Models.Inferfaces:
using Microsoft.EntityFrameworkCore;

namespace DiveDeepProject.Data
{
    public class DiveDeepContext
    {
        public DbSet<BCD> BCDs { get; set; }
        public DbSet<DivingSuit> DivingSuits { get; set; }
        public DbSet<Flipper> Flippers { get; set; }
        public DbSet<Regulatorset> Regulatorsets { get; set; }
        public DbSet<SnorkelSet> SnorkelSets { get; set; }
        public DbSet<Tank> Tanks { get; set; }
        public DbSet<IProduct> IProducts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IProduct>()
                .HasOne<BCD>(b => b.BCD)
        }
    }
}
