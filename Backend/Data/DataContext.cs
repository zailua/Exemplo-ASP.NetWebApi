using Fliperama.Model;
using Microsoft.EntityFrameworkCore;

namespace Fliperama.Data
{
    public class DataContext : DbContext
    {


       


        protected readonly IConfiguration _configuration;
  

        public DataContext(IConfiguration configuration)
        {
            _configuration = configuration;
            
 
        }

     

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));

        }


        public DbSet<Sala> Salas { get; set; }

        public DbSet<Jogo> Jogos { get; set; }



    }
}
