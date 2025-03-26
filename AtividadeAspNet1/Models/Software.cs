using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AtividadeAspNet1.Models
{
    [Table("software")]
    public class Software
    {
        [Key]
        [Column ("id_software")]
        public int Id { get; set; }
        [Column("produto")]
        public string Produto { get; set; }
        [Column("harddisk")]
        public int  Harddisk { get; set; }
        [Column("memoria_ram")]
        public int Ram { get; set; }
        [ForeignKey("maquina")]
        public int fk_maquina { get; set; }
        public Maquina maquina { get; set; }

    }
}