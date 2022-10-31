using Fliperama.Model;
using Microsoft.EntityFrameworkCore;

namespace Fliperama.Data
{
    public class DataContext : DbContext 
    {



        


        protected readonly IConfiguration Configuration;


        public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = Configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));

        }


        public DbSet<Sala> Sala { get; set; }

        public DbSet<Jogo> Jogos { get; set; }



    }
}
