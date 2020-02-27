﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MovieCore.Data;

namespace MovieCore.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MovieCore.Models.Contributor", b =>
                {
                    b.Property<Guid>("ContributorID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<bool>("IsActive");

                    b.Property<int>("LanguageID");

                    b.Property<string>("Name");

                    b.Property<string>("Title");

                    b.HasKey("ContributorID");

                    b.ToTable("Contributors");
                });

            modelBuilder.Entity("MovieCore.Models.ContributorManager", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("ContributorID");

                    b.Property<Guid>("ContributorTypeID");

                    b.HasKey("ID");

                    b.HasIndex("ContributorID");

                    b.HasIndex("ContributorTypeID");

                    b.ToTable("ContributorManagers");
                });

            modelBuilder.Entity("MovieCore.Models.ContributorType", b =>
                {
                    b.Property<Guid>("ContributorTypeID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<bool>("IsActive");

                    b.Property<int>("LanguageID");

                    b.Property<string>("Name");

                    b.Property<string>("Title");

                    b.HasKey("ContributorTypeID");

                    b.ToTable("ContributorTypes");
                });

            modelBuilder.Entity("MovieCore.Models.Genre", b =>
                {
                    b.Property<Guid>("GenreID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<bool>("IsActive");

                    b.Property<int>("LanguageID");

                    b.Property<string>("Name");

                    b.Property<string>("Title");

                    b.HasKey("GenreID");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("MovieCore.Models.Movie", b =>
                {
                    b.Property<Guid>("MovieID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<bool>("IsActive");

                    b.Property<int>("LanguageID");

                    b.Property<string>("Name");

                    b.Property<string>("Title");

                    b.HasKey("MovieID");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("MovieCore.Models.MovieContributor", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("ContributorID");

                    b.Property<Guid>("MovieID");

                    b.HasKey("ID");

                    b.HasIndex("ContributorID");

                    b.HasIndex("MovieID");

                    b.ToTable("MovieContributors");
                });

            modelBuilder.Entity("MovieCore.Models.MovieContributorType", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("ContributorTypeID");

                    b.Property<Guid>("MovieID");

                    b.HasKey("ID");

                    b.HasIndex("ContributorTypeID");

                    b.HasIndex("MovieID");

                    b.ToTable("MovieContributorTypes");
                });

            modelBuilder.Entity("MovieCore.Models.MovieGenre", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("GenreID");

                    b.Property<Guid>("MovieID");

                    b.HasKey("ID");

                    b.HasIndex("GenreID");

                    b.HasIndex("MovieID");

                    b.ToTable("MovieGenres");
                });

            modelBuilder.Entity("MovieCore.Models.ContributorManager", b =>
                {
                    b.HasOne("MovieCore.Models.Contributor")
                        .WithMany("ContributorManagers")
                        .HasForeignKey("ContributorID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MovieCore.Models.ContributorType", "ContributorTypes")
                        .WithMany()
                        .HasForeignKey("ContributorTypeID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MovieCore.Models.MovieContributor", b =>
                {
                    b.HasOne("MovieCore.Models.Contributor", "Contributors")
                        .WithMany()
                        .HasForeignKey("ContributorID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MovieCore.Models.Movie")
                        .WithMany("MovieContributors")
                        .HasForeignKey("MovieID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MovieCore.Models.MovieContributorType", b =>
                {
                    b.HasOne("MovieCore.Models.ContributorType", "ContributorTypes")
                        .WithMany()
                        .HasForeignKey("ContributorTypeID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MovieCore.Models.Movie")
                        .WithMany("MovieContributorTypes")
                        .HasForeignKey("MovieID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MovieCore.Models.MovieGenre", b =>
                {
                    b.HasOne("MovieCore.Models.Genre", "Genres")
                        .WithMany()
                        .HasForeignKey("GenreID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MovieCore.Models.Movie")
                        .WithMany("MovieGenres")
                        .HasForeignKey("MovieID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}