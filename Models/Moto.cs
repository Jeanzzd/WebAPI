using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Net.Models
{
    public class Moto
    {
        [Key]
        public int MotoId { get; set; }

        [Column("Marca")]
        public string Marca { get; set; }

        [Column("Modelo")]
        public string Modelo { get; set; }

        [Column("Ano")]
        public int Ano { get; set; }

        [Column("Cor")]
        public string Cor { get; set; }

    }
}
