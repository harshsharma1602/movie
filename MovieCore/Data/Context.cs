using Microsoft.EntityFrameworkCore;
using MovieCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieCore.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        public DbSet<ContributorType> ContributorTypes { get; set; }
        public DbSet<Contributor> Contributors { get; set; }
        
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Movie> Movies { get; set; }

        public DbSet<ContributorManager> ContributorManagers { get; set; }

        public DbSet<MovieGenre> MovieGenres { get; set; }
        public DbSet<MovieContributor> MovieContributors { get; set; }
        public DbSet<MovieContributorType> MovieContributorTypes { get; set; }
    }
}
