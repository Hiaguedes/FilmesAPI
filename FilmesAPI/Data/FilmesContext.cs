using FilmesAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace FilmesAPI.Data
{
    public class FilmesContext : DbContext
    {

        public DbSet<Filme> Filmes { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["FilmeConnection"].ConnectionString);
        }
    }
}
