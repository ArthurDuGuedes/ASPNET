using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SistemaEscolarAPI.DB;
using SistemaEscolarAPI.Models;
using SistemaEscolarAPI.DTO;
using Microsoft.AspNetCore.Mvc;

namespace SistemaEscolarAPI.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoContoller : ControllerBase
    {
        private readonly AppDbContext _context;
        public AlunoContoller(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AlunoDTO>>> Get()
        {
            var alunos = await _context.Alunos
                .Include(a => a.Curso)
                .Select(alunos => new AlunoDTO{
                    Nome = alunos.Nome, Curso = alunos.Curso.Descricao
                }).ToListAsync();
            return Ok(alunos);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] AlunoDTO alunoDto ){
            var Curso = await _context.Cursos.FirstOrDefaultAsync(c => c.Descricao == alunoDto.Curso);
            if (Curso == null) return BadRequest("Curso não escontrado");

            var aluno = new Aluno {
                Nome = alunoDto.Nome,
                CursoId = Curso.Id
            };
            _context.Alunos.Add(aluno);
            await _context.SaveChangesAsync();

            return Ok(aluno);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put([FromBody] AlunoDTO aluno, int id)
        {
            var alunoExistente = await _context.Alunos.FindAsync(id);
            if (alunoExistente == null) return NotFound();

            alunoExistente.Nome = aluno.Nome;
            alunoExistente.Curso = aluno.Curso == null ? null : await _context.Cursos.FirstOrDefaultAsync(c => c.Descricao == aluno.Curso);

            _context.Alunos.Update(alunoExistente);
            await _context.SaveChangesAsync();
            return Ok();

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var alunoExistente = await _context.Alunos.FindAsync(id);
            if (alunoExistente == null) return NotFound();

            _context.Alunos.Remove(alunoExistente);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}