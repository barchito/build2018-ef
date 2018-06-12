using core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Drawing;

namespace data_seed
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new BloggingContext())
            {
                foreach (var theme in db.Themes)
                {
                    Console.WriteLine(
                        $"Id = {theme.ThemeId}, Name = {theme.Name}, Color = {theme.TitleColor}");
                }
            }

            Console.WriteLine("Completed");
            Console.ReadKey();

        }
    }

    
    public class BloggingContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Theme> Themes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Demo.DataSeeding2;Trusted_Connection=True;Integrated Security=True;ConnectRetryCount=0");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Theme>()
                .HasData(
                    new Theme { ThemeId = 1, Name = "MSDN", TitleColor = Color.Red.Name },
                    new Theme { ThemeId = 2, Name = "TechNet", TitleColor = Color.DarkCyan.Name },
                    new Theme { ThemeId = 3, Name = "Personal", TitleColor = Color.LightBlue.Name },
                    new Theme { ThemeId = 5, Name = "Argentina", TitleColor = Color.LightBlue.Name },
                    new Theme { ThemeId = 6, Name = "River Plate", TitleColor = Color.Red.Name }
                    );

        }

    }
}
