using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaEscolarAPI.DB;
using SistemaEscolarAPI.DTO;
using SistemaEscolarAPI.Models;

namespace SistemaEscolarAPI.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class DisciplinaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DisciplinaController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DisciplinaDTO>>> Get()
        {
            var disciplinas = await _context.Disciplinas
                .Include(d => d.Curso)
                .Select(d => new DisciplinaDTO
                {
                    Descricao = d.Descricao,
                    Curso = d.Curso.Descricao
                })
                .ToListAsync();

            return Ok(disciplinas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DisciplinaDTO>> GetId(int id)
        {
            var disciplina = await _context.Disciplinas.Include(d => d.Curso).FirstOrDefaultAsync(d => d.Id == id);

            if (disciplina == null) return NotFound();
            
            return Ok(new DisciplinaDTO { Id = disciplina.Id, Descricao = disciplina.Descricao, Curso = disciplina.Curso.Descricao });

        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] DisciplinaDTO dto)
        {
            var curso = await _context.Cursos.FirstOrDefaultAsync(c => c.Descricao == dto.Curso);
            if (curso == null) return BadRequest("Curso não encontrado");

            var disciplina = new Disciplina
            {
                Descricao = dto.Descricao,
                Curso = curso
            };

            _context.Disciplinas.Add(disciplina);
            await _context.SaveChangesAsync();
            return Ok(new { mensagem = "Disciplina cadastrada com sucesso" });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] DisciplinaDTO dto)
        {
            var disciplinaExistente = await _context.Disciplinas.Include(d => d.Curso).FirstOrDefaultAsync(d => d.Id == id);
            if (disciplinaExistente == null) return NotFound();

            var curso = await _context.Cursos.FirstOrDefaultAsync(c => c.Descricao == dto.Curso);
            if (curso == null) return BadRequest("Curso não encontrado");

            disciplinaExistente.Descricao = dto.Descricao;
            disciplinaExistente.Curso = curso;

            _context.Disciplinas.Update(disciplinaExistente);
            await _context.SaveChangesAsync();

            return Ok(new { mensagem = "Disciplina atualizada com sucesso" });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var disciplina = await _context.Disciplinas.FindAsync(id);
            if (disciplina == null) return NotFound();

            _context.Disciplinas.Remove(disciplina);
            await _context.SaveChangesAsync();

            return Ok(new{mensagem = "Disciplina removida com sucesso"});   
        }
    }
}
