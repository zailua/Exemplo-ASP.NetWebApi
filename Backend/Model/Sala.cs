using Microsoft.EntityFrameworkCore.Infrastructure;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Fliperama.Model
{
    [Table("room")]
    public class Sala
    {
        private readonly ILazyLoader _lazyLoader;

        public Sala()
        {

        }

        public Sala(ILazyLoader lazyLoader)
        {
            _lazyLoader = lazyLoader;
        }


        [Column("id")]
        public int Id { get; set; }

        [Column("room_name")]
        [Required]
        public string Nome { get; set; }

        
        private Jogo _Jogo;
        
        [ForeignKey("jogo_fk")]
        public Jogo Jogo
        {
            get => _lazyLoader.Load(this, ref _Jogo);
            set => _Jogo = value;
        }

    }
}
