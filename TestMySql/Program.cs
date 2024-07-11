using System;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace TestMySql
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MyDbContext>();
            optionsBuilder.UseMySql("Server=localhost;Database=test;User=root;Password=yourpassword;",
                new MySqlServerVersion(new Version(8, 0, 23)));

            using (var context = new MyDbContext(optionsBuilder.Options))
            {
                Console.WriteLine("Database connection successful!");
            }
        }
    }

    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        public DbSet<Recipe> Recipes { get; set; }
    }

    public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Ingredients { get; set; }
        public string Instructions { get; set; }
    }
}
