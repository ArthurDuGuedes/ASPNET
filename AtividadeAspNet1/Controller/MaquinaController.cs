using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using AtividadeAspNet1.Models;
using AtividadeAspNet1.db;
using Microsoft.EntityFrameworkCore;

namespace AtividadeAspNet1.Controller
{
    [ApiController]
    [Route("arthur/[controller]")]
    public class MaquinasController : ControllerBase // Classe única, sem aninhamento
    {
        private readonly Conexao _context;

        public MaquinasController(Conexao context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Maquina>> Get()
        {
            return await _context.Maquinas.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Maquina>> Post([FromBody] Maquina maquina)
        {
            _context.Maquinas.Add(maquina);
            await _context.SaveChangesAsync();
            return maquina;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Maquina>> Put(int id, [FromBody] Maquina maquina)
        {
            var existente = await _context.Maquinas.FindAsync(id);
            if (existente == null) return NotFound();

            existente.tipo = maquina.tipo;
            existente.velocidade = maquina.velocidade;
            existente.HardDisk = maquina.HardDisk;
            existente.PlacaRede = maquina.PlacaRede;
            existente.MemoriaRam = maquina.MemoriaRam;
            await _context.SaveChangesAsync();
            return existente;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existente = await _context.Maquinas.FindAsync(id);
            if (existente == null) return NotFound();
            _context.Maquinas.Remove(existente);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
