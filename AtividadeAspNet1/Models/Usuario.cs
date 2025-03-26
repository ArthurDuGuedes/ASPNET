using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AtividadeAspNet1.Models
{
    [Table ("usuarios")]
    public class Usuarios
    {
        [Key]
        [Column("id_usuario")]
        public int Id { get; set; }
        [Column("password")]
        public string password { get; set; }
        [Column("nome_usuario")]
        public string nome { get; set; }
        [Column("ramal")]
        public int ramal { get; set; }
        [Column("especialidade")]
        public string especialidade { get; set; }

    }
}