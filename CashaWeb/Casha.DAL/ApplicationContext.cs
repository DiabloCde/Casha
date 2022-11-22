using Casha.Core.DbModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casha.DAL
{
    public class ApplicationContext : IdentityDbContext<User>
    {
        public DbSet<Category> Categories { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Post> Posts { get; set; }  

        public DbSet<Product> Products { get; set; }

        public DbSet<Recipe> Recipes { get; set; }

        public DbSet<RecipeCategory> RecipeCategories { get; set; }

        public DbSet<RecipeProduct> RecipeProducts { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<UserProduct> UserProducts { get; set; }

        public ApplicationContext(DbContextOptions options) : base(options)
        {
        }

        private void SeedUsers(ModelBuilder builder)
        {
            User user = new User
            {
                Id = "b74ddd14-6340-4840-95c2-db12554843e5",
                UserName = "admin@gmail.com",
                Email = "admin@gmail.com",
                NormalizedUserName = "ADMIN@GMAIL.COM",
                NormalizedEmail = "ADMIN@GMAIL.COM",
                LockoutEnabled = false,
                IsCertified = true,
                FirstName = "admin",
                LastName = "admin",
                DisplayName = "admin",
            };

            PasswordHasher<User> passwordHasher = new PasswordHasher<User>();
            var password = passwordHasher.HashPassword(user, "Admin123*");
            user.PasswordHash = password;
            builder.Entity<User>().HasData(user);
        }

        private void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole() { Id = "fab4fac1-c546-41de-aebc-a14da6895711", Name = "Admin", ConcurrencyStamp = "1", NormalizedName = "Admin" },
                new IdentityRole() { Id = "c7b013f0-5201-4317-abd8-c211f91b7330", Name = "User", ConcurrencyStamp = "2", NormalizedName = "User" }
            );
        }

        private void SeedUserRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>() { RoleId = "fab4fac1-c546-41de-aebc-a14da6895711", UserId = "b74ddd14-6340-4840-95c2-db12554843e5" }
            );
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            this.SeedUsers(modelBuilder);
            this.SeedRoles(modelBuilder);
            this.SeedUserRoles(modelBuilder);

            modelBuilder.Entity<RecipeCategory>()
                .HasKey(x => new { x.RecipeId, x.CategoryId });

            modelBuilder.Entity<RecipeProduct>()
                .HasKey(x => new { x.RecipeId, x.ProductId });

            modelBuilder.Entity<Comment>()
                .HasOne(x => x.User)
                .WithMany(y => y.Comments)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Comment>()
                .HasOne(x => x.Post)
                .WithMany(y => y.Comments)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Post>()
                .HasOne(x => x.User)
                .WithMany(y => y.Posts);

            modelBuilder.Entity<Recipe>()
                .HasOne(x => x.User)
                .WithMany(y => y.Recipes);

            modelBuilder.Entity<RecipeCategory>()
                .HasOne(x => x.Recipe)
                .WithMany(y => y.RecipeCategories);

            modelBuilder.Entity<RecipeCategory>()
                .HasOne(x => x.Category)
                .WithMany(y => y.RecipeCategories);

            modelBuilder.Entity<RecipeProduct>()
                .HasOne(x => x.Recipe)
                .WithMany(y => y.RecipeProducts);

            modelBuilder.Entity<RecipeProduct>()
                .HasOne(x => x.Product)
                .WithMany(y => y.RecipeProducts);

            modelBuilder.Entity<UserProduct>()
                .HasOne(x => x.Product)
                .WithMany(y => y.UserProducts);

            modelBuilder.Entity<UserProduct>()
                .HasOne(x => x.User)
                .WithMany(y => y.UserProducts);
        }
    }
}
