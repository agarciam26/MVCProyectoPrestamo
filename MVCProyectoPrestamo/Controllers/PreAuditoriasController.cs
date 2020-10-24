using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCProyectoPrestamo.Models.EntidadesBD;

namespace MVCProyectoPrestamo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PreAuditoriasController : ControllerBase
    {
        private readonly MVCProyecto10Context _context;

        public PreAuditoriasController(MVCProyecto10Context context)
        {
            _context = context;
        }

        // GET: api/PreAuditorias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PreAuditoria>>> GetPreAuditoria()
        {
            return await _context.PreAuditoria.ToListAsync();
        }

        // GET: api/PreAuditorias/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PreAuditoria>> GetPreAuditoria(int id)
        {
            var preAuditoria = await _context.PreAuditoria.FindAsync(id);

            if (preAuditoria == null)
            {
                return NotFound();
            }

            return preAuditoria;
        }

        // PUT: api/PreAuditorias/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPreAuditoria(int id, PreAuditoria preAuditoria)
        {
            if (id != preAuditoria.AudAuditoria)
            {
                return BadRequest();
            }

            _context.Entry(preAuditoria).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PreAuditoriaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/PreAuditorias
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PreAuditoria>> PostPreAuditoria(PreAuditoria preAuditoria)
        {
            _context.PreAuditoria.Add(preAuditoria);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPreAuditoria", new { id = preAuditoria.AudAuditoria }, preAuditoria);
        }

        // DELETE: api/PreAuditorias/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PreAuditoria>> DeletePreAuditoria(int id)
        {
            var preAuditoria = await _context.PreAuditoria.FindAsync(id);
            if (preAuditoria == null)
            {
                return NotFound();
            }

            _context.PreAuditoria.Remove(preAuditoria);
            await _context.SaveChangesAsync();

            return preAuditoria;
        }

        private bool PreAuditoriaExists(int id)
        {
            return _context.PreAuditoria.Any(e => e.AudAuditoria == id);
        }
    }
}
