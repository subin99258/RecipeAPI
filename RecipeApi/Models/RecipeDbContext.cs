using Microsoft.EntityFrameworkCore;
using RecipeApi.Models;

namespace RecipeApi.Data
{
    public class RecipeDbContext : DbContext
    {
        public RecipeDbContext(DbContextOptions<RecipeDbContext> options) : base(options)
        {
        }

        public DbSet<Recipe> Recipes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Recipe>(entity =>
            {
                entity.ToTable("recipes");

                entity.HasKey(e => e.recipe_id);

                entity.Property(e => e.recipe_id)
                    .HasColumnName("recipe_id")
                    .IsRequired()
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Ingredients)
                    .HasColumnName("ingredients")
                    .IsRequired();

                entity.Property(e => e.Instructions)
                    .HasColumnName("instructions")
                    .IsRequired();
            });
        }
    }
}
