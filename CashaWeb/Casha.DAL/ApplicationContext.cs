using Casha.Core.DbModels;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

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
