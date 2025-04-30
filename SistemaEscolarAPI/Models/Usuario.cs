using System.ComponentModel.DataAnnotations;

namespace SistemaEscolarAPI.Models
{
    public class Usuario
    {
        [Key] // Marca como chave primária
        public int Id { get; set; }

        public string Username { get; set; }

        public string PassWord { get; set; }

        public string Role { get; set; } 
    }
}
