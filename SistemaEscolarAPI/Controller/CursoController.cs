using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SistemaEscolarAPI.DB;
using SistemaEscolarAPI.DTO;
using Microsoft.AspNetCore.Mvc;
using SistemaEscolarAPI.Models;

namespace SistemaEscolarAPI.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class CursoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CursoController(AppDbContext context)
        {
            _context  = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CursoDTO>>> Get()
        {
            var cursos = await _context.Cursos.Select(c => new CursoDTO { Id = c.Id ,Descricao = c.Descricao }).ToListAsync();
            return Ok(cursos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CursoDTO>> GetId(int id)
        {
            var curso = await _context.Cursos.FirstOrDefaultAsync(c => c.Id == id);

            if(curso == null)return NotFound();

            return Ok(new CursoDTO {Id = curso.Id, Descricao = curso.Descricao});
        }

        [HttpPost]
        public async Task<ActionResult> Post ([FromBody] CursoDTO cursoDto)
        {
            var curso = new Curso {Descricao = cursoDto.Descricao};
            _context.Cursos.Add(curso);
            await _context.SaveChangesAsync();
            return Ok(); 
            
        }

        [HttpPut("{id}")] 
        public async Task<ActionResult> Put ([FromBody] CursoDTO curso, int id)
        {
            var cursoExistente = await _context.Cursos.FindAsync(id);
            if (cursoExistente == null) return NotFound();
            cursoExistente.Descricao = curso.Descricao;
            _context.Cursos.Update(cursoExistente);
            await _context.SaveChangesAsync();
            return Ok();
        }   

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete( int id)
        {
            var cursoExistente = await _context.Cursos.FindAsync(id);
            if (cursoExistente == null) return NotFound();

            _context.Cursos.Remove(cursoExistente);
            await _context.SaveChangesAsync(); 
            return Ok();       
        }
    }
}
