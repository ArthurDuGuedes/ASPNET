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
                    Id = dac.Id,
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
                    Id = dac.Id,
                    AlunoId = dac.AlunoId,
                    AlunoNome = dac.Aluno.Nome,
                    DisciplinaId = dac.DisciplinaId,
                    DisciplinaNome = dac.Disciplina.Descricao,
                    CursoId = dac.CursoId,
                    CursoDescricao = dac.Curso.Descricao
                })
                .FirstOrDefaultAsync(dac => dac.Id == id);

            return Ok(dac);
        }


        [HttpPost]
        public async Task<ActionResult> Post([FromBody] DisciplinaAlunoCursoDTO dac)
        {
            var aluno = await _context.Alunos.FirstOrDefaultAsync(a => a.Nome == dac.AlunoNome);
            if (aluno == null) return BadRequest("Aluno não encontrado");

            var curso = await _context.Cursos.FirstOrDefaultAsync(c => c.Descricao == dac.CursoDescricao);
            if (curso == null) return BadRequest("Curso não encontrado");

            var disciplina = await _context.Disciplinas.FirstOrDefaultAsync(d => d.Descricao == dac.DisciplinaNome);
            if (disciplina == null) return BadRequest("Disciplina não encontrada");

            var novaRelacao = new DisciplinaAlunoCurso
            {
                AlunoId = aluno.Id,
                CursoId = curso.Id,
                DisciplinaId = disciplina.Id
            };

            _context.DisciplinaAlunoCursos.Add(novaRelacao);
            await _context.SaveChangesAsync();

            return Ok(new { mensagem = "Cadastro realizado com sucesso" });
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> Put([FromBody] DisciplinaAlunoCursoDTO dac, int id)
        {
            var existente = await _context.DisciplinaAlunoCursos
                .Include(d => d.Aluno)
                .Include(d => d.Curso)
                .Include(d => d.Disciplina)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (existente == null)
                return NotFound("Relação não encontrada.");

            // Buscar entidades atualizadas com base nos nomes (como seu POST faz)
            var aluno = await _context.Alunos.FirstOrDefaultAsync(a => a.Nome == dac.AlunoNome);
            if (aluno == null) return BadRequest("Aluno não encontrado");

            var curso = await _context.Cursos.FirstOrDefaultAsync(c => c.Descricao == dac.CursoDescricao);
            if (curso == null) return BadRequest("Curso não encontrado");

            var disciplina = await _context.Disciplinas.FirstOrDefaultAsync(d => d.Descricao == dac.DisciplinaNome);
            if (disciplina == null) return BadRequest("Disciplina não encontrada");

            // Atualiza os dados
            existente.AlunoId = aluno.Id;
            existente.CursoId = curso.Id;
            existente.DisciplinaId = disciplina.Id;

            _context.DisciplinaAlunoCursos.Update(existente);
            await _context.SaveChangesAsync();

            return Ok("Atualização realizada com sucesso.");
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var dacExistente = await _context.DisciplinaAlunoCursos.FirstOrDefaultAsync(dac => dac.Id == id);
            if(dacExistente == null) return NotFound("Disciplina Aluno Curso não encontrada");

            _context.DisciplinaAlunoCursos.Remove(dacExistente);
            await _context.SaveChangesAsync();
            return Ok("Removido com sucesso");
        }


    }
    
}