using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace query_types
{
    class Program
    {
        static void Main(string[] args)
        {
            SetupDatabase();

            using (var db = new BloggingContext())
            {
                
                var postCounts = db.BlogPostCounts.ToList();

                foreach (var postCount in postCounts)
                {
                    Console.WriteLine($"{postCount.BlogName} has {postCount.PostCount} posts.");
                    Console.WriteLine();
                }
            }
            Console.ReadKey();
        }


        private static void SetupDatabase()
        {
            using (var db = new BloggingContext())
            {
                if (db.Database.EnsureCreated())
                {

                    db.Blogs.Add(
                        new Blog
                        {
                            Name = "Fish",
                            Url = "http://sample.com/blogs/fish",
                            Posts = new List<Post>
                            {
                                new Post { Title = "Fish care 101" },
                                new Post { Title = "Caring for tropical fish" },
                                new Post { Title = "Types of ornamental fish" }
                            }
                        });

                    db.Blogs.Add(
                        new Blog
                        {
                            Name = "Cat",
                            Url = "http://sample.com/blogs/cats",
                            Posts = new List<Post>
                            {
                                new Post { Title = "Cat care 101" },
                                new Post { Title = "Caring for tropical cats" },
                                new Post { Title = "Types of ornamental cats" }
                            }
                        });

                    db.Blogs.Add(
                        new Blog
                        {
                            Name = "FIshCat",
                            Url = "http://sample.com/blogs/catfish",
                            Posts = new List<Post>
                            {
                                new Post { Title = "Catfish care 101" },
                                new Post { Title = "History of the catfish name" }
                            }
                        });

                    db.Database.ExecuteSqlCommand(
    @"CREATE VIEW View_BlogPostCounts AS 
                            SELECT Name, Count(p.PostId) as PostCount from Blogs b
                            JOIN Posts p on p.BlogId = b.BlogId
                            GROUP BY b.Name");



                    db.SaveChanges();
                }
            }
        }
    }

    public class BloggingContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbQuery<BlogPostsCount> BlogPostCounts { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Demo.QueryTypes3;Trusted_Connection=True;Integrated Security=True;ConnectRetryCount=0");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Query<BlogPostsCount>().ToView("View_BlogPostCounts")
                .Property(v => v.BlogName).HasColumnName("Name");
        }

    }

    public class BlogPostsCount
    {
        public string BlogName { get; set; }
        public int PostCount { get; set; }
    }

    public class Blog
    {
        public int BlogId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public ICollection<Post> Posts { get; set; }
    }

    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int BlogId { get; set; }
    }
}
