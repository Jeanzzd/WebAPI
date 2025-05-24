using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Net.Models
{
    public class Usuario
    {
        [Key]
        public int UserId { get; set; }

        [Column("Nome")]

        public string Nome { get; set; } = string.Empty;

        [Column("Cpf")]
        public string Cpf { get; set; } = string.Empty;

        [Column("Email")]
        public string Email { get; set; } = string.Empty;

 
    }
}
