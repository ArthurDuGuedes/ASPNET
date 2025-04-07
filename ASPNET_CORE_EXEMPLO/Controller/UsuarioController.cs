using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using ASPNET_CORE_EXEMPLO.Models;
using ASPNET_CORE_EXEMPLO.db;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;



namespace ASPNET_CORE_EXEMPLO.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuariosController : ControllerBase // Classe única, sem aninhamento
    {
        private readonly Conexao _context;

        public UsuariosController(Conexao context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Usuarios>> Get()
        {
            return await _context.Usuarios.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Usuarios>> Post([FromBody] Usuarios usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Usuarios>> Put(int id, [FromBody] Usuarios usuario)
        {
            var existente = await _context.Usuarios.FindAsync(id);
            if (existente == null) return NotFound();

            existente.password = usuario.password;
            existente.nome = usuario.nome;
            existente.ramal = usuario.ramal;
            existente.especialidade = usuario.especialidade;

            await _context.SaveChangesAsync();
            return existente;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existente = await _context.Usuarios.FindAsync(id);
            if (existente == null) return NotFound();
            _context.Usuarios.Remove(existente);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}