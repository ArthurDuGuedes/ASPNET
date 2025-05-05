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
    public class DisciplinaAlunoCursoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DisciplinaAlunoCursoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DisciplinaAlunoCursoDTO>>> Get()
        {
            var dac = await _context.DisciplinaAlunoCursos
                .Include(d => d.Aluno)
                .Include(d => d.Disciplina)
                .Include(d => d.Curso)
                .Select(dac => new DisciplinaAlunoCursoDTO
                {
                    Id = dac.AlunoId + dac.DisciplinaId + dac.CursoId, // ou algum identificador lógico
                    AlunoId = dac.AlunoId,
                    AlunoNome = dac.Aluno.Nome,
                    DisciplinaId = dac.DisciplinaId,
                    DisciplinaNome = dac.Disciplina.Descricao,
                    CursoId = dac.CursoId,
                    CursoDescricao = dac.Curso.Descricao
                })
                .ToListAsync();

            return Ok(dac);
        }



        [HttpGet("{id}")]
        public async Task<ActionResult<DisciplinaAlunoCursoDTO>> GetId(int id)
        {
            var dac = await _context.DisciplinaAlunoCursos
                .Include(d => d.Aluno)
                .Include(d => d.Disciplina)
                .Include(d => d.Curso)
                .Select(dac => new DisciplinaAlunoCursoDTO
                {
                    Id = dac.AlunoId + dac.DisciplinaId + dac.CursoId, // ou algum identificador lógico
                    AlunoId = dac.AlunoId,
                    AlunoNome = dac.Aluno.Nome,
                    DisciplinaId = dac.DisciplinaId,
                    DisciplinaNome = dac.Disciplina.Descricao,
                    CursoId = dac.CursoId,
                    CursoDescricao = dac.Curso.Descricao
                })
                .ToListAsync();

            return Ok(dac);
        }


        [HttpPost]
        public async Task<ActionResult> Post([FromBody] DisciplinaAlunoCursoDTO dac)
        {
            var dacExistente = await _context.DisciplinaAlunoCursos.FirstOrDefaultAsync(dac => dac.DisciplinaId == dac.DisciplinaId && dac.AlunoId == dac.AlunoId && dac.CursoId == dac.CursoId);
            if(dacExistente == null) return BadRequest("Disciplina Aluno Curso nao encontrado");
            _context.DisciplinaAlunoCursos.Add(dacExistente);
            await _context.SaveChangesAsync();
            return Ok(dacExistente);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put([FromBody] DisciplinaAlunoCursoDTO dac, int id)
        {
            var dacExistente = await _context.DisciplinaAlunoCursos.FirstOrDefaultAsync(dac => dac.DisciplinaId == dac.DisciplinaId && dac.AlunoId == dac.AlunoId && dac.CursoId == dac.CursoId);
            if(dacExistente == null) return BadRequest("Disciplina Aluno Curso nao encontrado");
            dacExistente.DisciplinaId = dac.DisciplinaId;
            dacExistente.AlunoId = dac.AlunoId;
            dacExistente.CursoId = dac.CursoId;
            _context.DisciplinaAlunoCursos.Update(dacExistente);
            await _context.SaveChangesAsync();
            return Ok(dacExistente);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var dacExistente = await _context.DisciplinaAlunoCursos.FirstOrDefaultAsync(dac => dac.DisciplinaId == dac.DisciplinaId && dac.AlunoId == dac.AlunoId && dac.CursoId == dac.CursoId);
            if(dacExistente == null) return BadRequest("Disciplina Aluno Curso nao encontrado");
            _context.DisciplinaAlunoCursos.Remove(dacExistente);
            await _context.SaveChangesAsync();
            return Ok(dacExistente);
        }

    }
    
}