using core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace lazy_loading
{
    class Program
    {
        static void Main(string[] args)
        {

            SetupDatabase();

            using (var db = new BloggingContext())
            {
                foreach (var blog in db.Blogs) // Load the blogs
                {
                    Console.WriteLine(blog.Url);

                    if (!blog.Posts.Any()) // Access the Posts navigation property
                    {
                        Console.WriteLine("No posts!");
                    }
                    else
                    {
                        foreach (var post in blog.Posts)
                        {
                            Console.WriteLine($" - {post.Title}");
                        }
                    }

                    Console.WriteLine();
                }
                Console.ReadKey();

            }
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
                            Name = "CatFish",
                            Url = "http://sample.com/blogs/catfish",
                            Posts = new List<Post>
                            {
                                new Post { Title = "Catfish care 101" },
                                new Post { Title = "History of the catfish name" }
                            }
                        });

                    db.SaveChanges();
                }
            }
        }
    }

    public class BloggingContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                //.UseLazyLoadingProxies()
                .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Demo.LazyLoading;Trusted_Connection=True;ConnectRetryCount=0;");
                    
        }
    }
}
