using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaEscolarAPI.Models
{
    public class DisciplinaAlunoCurso
    {
        [Key]
        public int Id {get; set;}
        public int DisciplinaId {get; set; }
        public Disciplina Disciplina { get; set; }
        public int AlunoId {get; set; }
        public Aluno Aluno { get; set; }
        public int CursoId {get; set; }
        public Curso Curso { get; set; }
    }
}