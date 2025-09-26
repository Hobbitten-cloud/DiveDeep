using DiveDeepProject.Models.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DiveDeepProject.Data
{
    public class DiveDeepContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<BCD> BCDs { get; set; }
        public DbSet<DivingSuit> DivingSuits { get; set; }
        public DbSet<Flipper> Flippers { get; set; }
        public DbSet<Regulatorset> Regulatorsets { get; set; }
        public DbSet<SnorkelSet> SnorkelSets { get; set; }
        public DbSet<Tank> Tanks { get; set; }
        public DbSet<Product> Products { get; set; }
		public DbSet<UnavailableDates> UnavailableDates { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
			base.OnModelCreating(modelBuilder);
            // Table references
			#region
			modelBuilder.Entity<BCD>()
                .HasOne<Product>(p => p.Product)
                .WithMany(b => b.BCDs)
                .HasForeignKey(f => f.ProductId);

            modelBuilder.Entity<Flipper>()
                .HasOne<Product>(p => p.Product)
                .WithMany(b => b.Flippers)
                .HasForeignKey(f => f.ProductId);

            modelBuilder.Entity<DivingSuit>()
                .HasOne<Product>(p => p.Product)
                .WithMany(b => b.DivingSuits)
                .HasForeignKey(f => f.ProductId);

            modelBuilder.Entity<Tank>()
                .HasOne<Product>(p => p.Product)
                .WithMany(b => b.Tanks)
                .HasForeignKey(f => f.ProductId);

            modelBuilder.Entity<Regulatorset>()
                .HasOne<Product>(p => p.Product)
                .WithMany(b => b.Regulatorsets)
                .HasForeignKey(f => f.ProductId);

            modelBuilder.Entity<SnorkelSet>()
                .HasOne<Product>(p => p.Product)
                .WithMany(b => b.SnorkelSets)
                .HasForeignKey(f => f.ProductId);

            modelBuilder.Entity<UnavailableDates>()
                .HasOne<Product>()
				.WithMany(p => p.UnavailableDates)
				.HasForeignKey(f => f.ProductId);

            modelBuilder.Entity<ApplicationUser>()
                .HasMany<Product>(p => p.Products)
                .WithOne(a => a.User)
                .HasForeignKey(i => i.UserId);
			#endregion

			// Seeded data
			#region

			// Product
			modelBuilder.Entity<Product>().HasData(
                // BCDs
                new Product { Id = 1, Brand = "Scubapro", Model= "Navigator Lite BCD", PricePerDay = 125, Description = "Comfortable and durable BCD for all diving levels.",  ImagePath = "lib/Public/BCDProduct.png" },
                new Product { Id = 2, Brand = "Scubapro", Model= "BCD Glide", PricePerDay = 140, Description = "Comfortable and durable BCD for all diving levels.",  ImagePath = "lib/Public/BCDProduct.png" },
                new Product { Id = 3, Brand = "Scubapro", Model = "BCD Hydros Pro", PricePerDay = 200, Description = "Comfortable and durable BCD for all diving levels.", ImagePath = "lib/Public/BCDProduct.png" },
                new Product { Id = 4, Brand = "Seac", Model= "BCD Modular", PricePerDay = 145, Description = "Comfortable and durable BCD for all diving levels.",  ImagePath = "lib/Public/BCDProduct.png" },

                // DivingSuits
                new Product { Id = 5, Brand = "Scubapro", Model= "Definition", PricePerDay = 100, Description = "3 mm wetsuit for warm water diving.", ImagePath = "lib/Public/DivingSuitProduct.png" },
                new Product { Id = 6, Brand = "Scubapro", Model = "Definition", PricePerDay = 100, Description = "5 mm wetsuit for versatile diving.", ImagePath = "lib/Public/DivingSuitProduct.png" },
                new Product { Id = 7, Brand = "Scubapro", Model = "Definition", PricePerDay = 100, Description = "7 mm wetsuit for colder waters.", ImagePath = "lib/Public/DivingSuitProduct.png" },
                new Product { Id = 8, Brand = "Waterproof", Model = "W5", PricePerDay = 100, Description = "3.5 mm wetsuit, flexible and warm.", ImagePath = "lib/Public/DivingSuitProduct.png" },
                new Product { Id = 9, Brand = "Fourth Element", Model = "Proteus", PricePerDay = 120, Description = "5 mm premium wetsuit.", ImagePath = "lib/Public/DivingSuitProduct.png" },
                new Product { Id = 10, Brand = "Scubapro", Model = "Exodry 4.0", PricePerDay = 300, Description = "Durable drysuit.", ImagePath = "lib/Public/DivingSuitProduct.png" },
                new Product { Id = 11, Brand = "Waterproof", Model = "D7 Evo", PricePerDay = 320, Description = "Advanced drysuit for technical diving.", ImagePath = "lib/Public/DivingSuitProduct.png" },
                new Product { Id = 12, Brand = "Santi", Model = "E.Lite Plus", PricePerDay = 350, Description = "Top-tier drysuit for professionals.", ImagePath = "lib/Public/DivingSuitProduct.png" },

                // Tanks
                new Product { Id = 13, Brand = "Scubapro", Model = "", PricePerDay = 150, Description = "Compact tank, good for short dives.", ImagePath = "lib/Public/TankProduct.png" },
                new Product { Id = 14, Brand = "Scubapro", Model = "", PricePerDay = 160, Description = "Standard tank for recreational diving.", ImagePath = "lib/Public/TankProduct.png" },
                new Product { Id = 15, Brand = "Scubapro", Model = "", PricePerDay = 170, Description = "Versatile tank, good for most dives.", ImagePath = "lib/Public/TankProduct.png" },
                new Product { Id = 16, Brand = "Scubapro", Model = "", PricePerDay = 180, Description = "Large tank for extended dives.", ImagePath = "lib/Public/TankProduct.png" },

                // Regulators
                new Product { Id = 17, Brand = "Scubapro", Model = "MK25EVO", PricePerDay = 125, Description = "High performance regulator.", ImagePath = "lib/Public/RegulatorSetProduct.png" },
                new Product { Id = 18, Brand = "Scubapro", Model = "MK17EVO", PricePerDay = 100, Description = "Reliable regulator set.", ImagePath = "lib/Public/RegulatorSetProduct.png" },
                new Product { Id = 19, Brand = "Scubapro", Model = "MK25EVO BT", PricePerDay = 150, Description = "Top-tier regulator with carbon second stage.", ImagePath = "lib/Public/RegulatorSetProduct.png" },

                // SnorkelSets
                new Product { Id = 20, Brand = "Scubapro", Model = "Ghost", PricePerDay = 50, Description = "Frameless mask with wide view.", ImagePath = "lib/Public/MaskProduct.png" },
                new Product { Id = 21, Brand = "Scubapro", Model = "D-Mask", PricePerDay = 60, Description = "Premium diving mask.", ImagePath = "lib/Public/MaskProduct.png" },
                new Product { Id = 22, Brand = "Scubapro", Model = "Spectra Mini", PricePerDay = 50, Description = "Compact mask for smaller faces.", ImagePath = "lib/Public/MaskProduct.png" },
                new Product { Id = 23, Brand = "Scubapro", Model = "Crystal VU", PricePerDay = 75, Description = "Wide field of view mask.", ImagePath = "lib/Public/MaskProduct.png" },
                new Product { Id = 24, Brand = "Fourth Element", Model = "Scout Kontrast", PricePerDay = 75, Description = "Advanced mask for all conditions.", ImagePath = "lib/Public/MaskProduct.png" },
                new Product { Id = 25, Brand = "Fourth Element", Model = "Scout Enhance", PricePerDay = 75, Description = "High clarity mask.", ImagePath = "lib/Public/MaskProduct.png" },
                new Product { Id = 26, Brand = "Tusa", Model = "Element", PricePerDay = 75, Description = "Durable and clear diving mask.", ImagePath = "lib/Public/MaskProduct.png" },

                // Flippers
                new Product { Id = 27, Brand = "Scubapro", Model = "Jet Fin", PricePerDay = 50, Description = "Classic durable fin.", ImagePath = "lib/Public/FinsProduct.png" },
                new Product { Id = 28, Brand = "Scubapro", Model = "GO Travel", PricePerDay = 50, Description = "Lightweight travel fin.", ImagePath = "lib/Public/FinsProduct.png" },
                new Product { Id = 29, Brand = "Scubapro", Model = "Seawing Supernova", PricePerDay = 60, Description = "High performance split fin.", ImagePath = "lib/Public/FinsProduct.png" },
                new Product { Id = 30, Brand = "Seac", Model = "Propulsion", PricePerDay = 50, Description = "Durable and powerful fin.", ImagePath = "lib/Public/FinsProduct.png" },
                new Product { Id = 31, Brand = "Seac", Model = "ALA", PricePerDay = 50, Description = "Compact and flexible fin.", ImagePath = "lib/Public/FinsProduct.png" },
                new Product { Id = 32, Brand = "Fourth Element", Model = "Tech", PricePerDay = 75, Description = "Strong fin for technical diving.", ImagePath = "lib/Public/FinsProduct.png" },
                new Product { Id = 33, Brand = "Fourth Element", Model = "Rec Fin", PricePerDay = 80, Description = "All-round recreational fin.", ImagePath = "lib/Public/FinsProduct.png" }
            );

            // BCD
            modelBuilder.Entity<BCD>().HasData(
                new BCD { Id = 1, ProductId = 1, Model = "Navigator Lite BCD", Size = null },
                new BCD { Id = 2, ProductId = 2, Model = "BCD Glide", Size = null },
                new BCD { Id = 3, ProductId = 3, Model = "BCD Hydros Pro", Size = null },
                new BCD { Id = 4, ProductId = 4, Model = "BCD Modular", Size = null }
            );

            // DivingSuit
            modelBuilder.Entity<DivingSuit>().HasData(
                new DivingSuit { Id = 1, ProductId = 5, Model = "Definition", Size = null, Thickness = "3 mm", Type = "Våddragt" },
                new DivingSuit { Id = 2, ProductId = 6, Model = "Definition", Size = null, Thickness = "5 mm", Type = "Våddragt" },
                new DivingSuit { Id = 3, ProductId = 7, Model = "Definition", Size = null, Thickness = "7 mm", Type = "Våddragt" },
                new DivingSuit { Id = 4, ProductId = 8, Model = "W5", Size = null, Thickness = "3.5 mm", Type = "Våddragt" },
                new DivingSuit { Id = 5, ProductId = 9, Model = "Proteus", Size = null, Thickness = "5 mm", Type = "Våddragt" },
                new DivingSuit { Id = 6, ProductId = 10, Model = "Exodry 4.0", Size = null, Thickness = "N/A", Type = "Tørdragt" },
                new DivingSuit { Id = 7, ProductId = 11, Model = "D7 Evo", Size = null, Thickness = "N/A", Type = "Tørdragt" },
                new DivingSuit { Id = 8, ProductId = 12, Model = "E.Lite Plus", Size = null, Thickness = "N/A", Type = "Tørdragt" }
            );

            // Tank
            modelBuilder.Entity<Tank>().HasData(
                new Tank { Id = 1, ProductId = 13, Volume = "5 L" },
                new Tank { Id = 2, ProductId = 14, Volume = "10 L" },
                new Tank { Id = 3, ProductId = 15, Volume = "12 L" },
                new Tank { Id = 4, ProductId = 16, Volume = "15 L" }
            );

            // Regulatorset
            modelBuilder.Entity<Regulatorset>().HasData(
                new Regulatorset { Id = 1, ProductId = 17, FirstStep = "MK25EVO", SecondStep = "S600", Octopus = "R105" },
                new Regulatorset { Id = 2, ProductId = 18, FirstStep = "MK17EVO", SecondStep = "C370", Octopus = "R095" },
                new Regulatorset { Id = 3, ProductId = 19, FirstStep = "MK25EVO BT", SecondStep = "A700 Carbon BT", Octopus = "S270" }
            );

            // SnorkelSet
            modelBuilder.Entity<SnorkelSet>().HasData(
                new SnorkelSet { Id = 1, ProductId = 20, Model = "Ghost" },
                new SnorkelSet { Id = 2, ProductId = 21, Model = "D-Mask" },
                new SnorkelSet { Id = 3, ProductId = 22, Model = "Spectra Mini" },
                new SnorkelSet { Id = 4, ProductId = 23, Model = "Crystal VU" },
                new SnorkelSet { Id = 5, ProductId = 24, Model = "Scout Kontrast" },
                new SnorkelSet { Id = 6, ProductId = 25, Model = "Scout Enhance" },
                new SnorkelSet { Id = 7, ProductId = 26, Model = "Element" }
            );

            // Flipper
            modelBuilder.Entity<Flipper>().HasData(
                new Flipper { Id = 1, ProductId = 27, Model = "Jet Fin", Size = null },
                new Flipper { Id = 2, ProductId = 28, Model = "GO Travel", Size = null },
                new Flipper { Id = 3, ProductId = 29, Model = "Seawing Supernova", Size = null },
                new Flipper { Id = 4, ProductId = 30, Model = "Propulsion", Size = null },
                new Flipper { Id = 5, ProductId = 31, Model = "ALA", Size = null },
                new Flipper { Id = 6, ProductId = 32, Model = "Tech", Size = null },
                new Flipper { Id = 7, ProductId = 33, Model = "Rec Fin", Size = null }
            );
			

			#endregion
		}

        public DiveDeepContext(DbContextOptions contextOptions) : base(contextOptions)
        {

        }
    }
}
