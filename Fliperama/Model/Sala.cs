using System.ComponentModel.DataAnnotations.Schema;

namespace Fliperama.Model
{
    [Table("room")]
    public class Sala
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("room_name")]
        public string Nome { get; set; }

        [ForeignKey("game_fk")]
        public Jogo Jogo { get; set; }

        
    }
}
