using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AtividadeAspNet1.Models
{
    [Table("maquina")]
    public class Maquina
    {
        [Key]
        [Column("id_maquina")]
        public int Id {get; set;}
        [Column("tipo")]
        public string tipo {get; set;}
        [Column("velocidade")]
        public int velocidade {get; set;}
        [Column("harddisk")]
        public int HardDisk {get; set;}
        [Column("placa_rede")]
        public int PlacaRede {get; set;}
        [Column("memoria_ram")]
        public int MemoriaRam {get; set;}   
        [ForeignKey("usuario")]
        public int fk_usuario {get; set;}
        public Usuarios Usuarios {get; set;}


    }
}