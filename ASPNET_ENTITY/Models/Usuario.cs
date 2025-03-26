using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
//comando dotnet add package System.ComponentModel
using System.Linq;
using System.Threading.Tasks;

// Como usar o Entity Framework para acesasar o banco de dados 
// Vamos mapear as classes para as tabelas do banco de dados

namespace ASPNET_ENTITY.Models
{
    [Table("usuario")]
    public class Usuario
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("nome")]
        public string Nome { get; set; }
        [Column("email")]
        public string Email { get; set; }
    }
}