﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using data_seed;

namespace dataseed.Migrations
{
    [DbContext(typeof(BloggingContext))]
    partial class BloggingContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.0-rtm-30799")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("core.Blog", b =>
                {
                    b.Property<int>("BlogId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BlogUrl");

                    b.Property<int?>("ThemeId");

                    b.HasKey("BlogId");

                    b.HasIndex("ThemeId");

                    b.ToTable("Blogs");
                });

            modelBuilder.Entity("core.Theme", b =>
                {
                    b.Property<int>("ThemeId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<string>("TitleColor");

                    b.HasKey("ThemeId");

                    b.ToTable("Themes");

                    b.HasData(
                        new { ThemeId = 1, Name = "MSDN", TitleColor = "Red" },
                        new { ThemeId = 2, Name = "TechNet", TitleColor = "DarkCyan" },
                        new { ThemeId = 3, Name = "Personal", TitleColor = "LightBlue" },
                        new { ThemeId = 5, Name = "Argentina", TitleColor = "LightBlue" },
                        new { ThemeId = 6, Name = "River Plate", TitleColor = "Red" }
                    );
                });

            modelBuilder.Entity("core.Blog", b =>
                {
                    b.HasOne("core.Theme", "Theme")
                        .WithMany()
                        .HasForeignKey("ThemeId");
                });
#pragma warning restore 612, 618
        }
    }
}
