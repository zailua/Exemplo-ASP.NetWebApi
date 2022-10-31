using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Fliperama.Model
{



    [Table("game")]
    public class Jogo
    {

        [Column("id")]
        public int Id { get; set; }

        [Column("game_name")]
        public string Nome { get; set; } = string.Empty;

        [Column("game_value")]
        public double Valor { get; set; }

        [Column("game_gen")]
        public string GameGen { get; set; } = string.Empty; 

        [Column("game_img")]
        public string Img { get; set; } = string.Empty;

        [JsonIgnore]
        public virtual ICollection<Sala>? Salas { get; set; }


    }
}
