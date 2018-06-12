using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Drawing;

namespace value_conversion
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new ThemeContext())
            {
                foreach (var theme in db.Themes)
                {
                    Console.WriteLine(
                        $"Id = {theme.ThemeId}, Name = {theme.Name}, Color = {theme.TitleColor}");
                }
            }

            Console.ReadKey();
        }
    }


    public class ThemeContext : DbContext
    {
        private static readonly ILoggerFactory _loggerFactory = new LoggerFactory()
            .AddConsole((s, l) => l == LogLevel.Information && s.EndsWith("Command"));

        public DbSet<Theme> Themes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Theme>()
                .HasData(
                    new Theme { ThemeId = 1, Name = "MSDN", TitleColor = Color.AliceBlue },
                    new Theme { ThemeId = 2, Name = "TechNet", TitleColor = Color.DarkCyan },
                    new Theme { ThemeId = 3, Name = "EF", TitleColor = Color.Purple },
                    new Theme { ThemeId = 4, Name = "Personal", TitleColor = Color.LightBlue });

            modelBuilder
                .Entity<Theme>()
                .Property(t => t.TitleColor)
                .HasConversion(c => c.Name, s => Color.FromName(s))
                ;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder
                .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Demo.DataValue1;Trusted_Connection=True;ConnectRetryCount=0")
                .UseLoggerFactory(_loggerFactory);
    }


    public class Theme
    {
        public ushort ThemeId { get; set; }
        public string Name { get; set; }
        public Color TitleColor { get; set; }
    }
}
