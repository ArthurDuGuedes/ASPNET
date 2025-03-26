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
    [Route("[controller]")]
    public class SoftwaresController : ControllerBase 
    {
        private readonly Conexao _context;

        public SoftwaresController(Conexao context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Software>> Get()
        {
            return await _context.Softwares.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Software>> Post([FromBody] Software software)
        {
            _context.Softwares.Add(software);
            await _context.SaveChangesAsync();
            return software;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Software>> Put(int id, [FromBody] Software software)
        {
            var existente = await _context.Softwares.FindAsync(id);
            if (existente == null) return NotFound();

            existente.Produto = software.Produto;
            existente.Harddisk = software.Harddisk;
            existente.Ram = software.Ram;
            existente.fk_maquina = software.fk_maquina;
            await _context.SaveChangesAsync();
            return existente;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existente = await _context.Softwares.FindAsync(id);
            if (existente == null) return NotFound();
            _context.Softwares.Remove(existente);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }

}