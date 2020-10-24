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
    public class PreEvaluacionPrestamoesController : ControllerBase
    {
        private readonly MVCProyecto10Context _context;

        public PreEvaluacionPrestamoesController(MVCProyecto10Context context)
        {
            _context = context;
        }

        // GET: api/PreEvaluacionPrestamoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PreEvaluacionPrestamo>>> GetPreEvaluacionPrestamo()
        {
            return await _context.PreEvaluacionPrestamo.ToListAsync();
        }

        // GET: api/PreEvaluacionPrestamoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PreEvaluacionPrestamo>> GetPreEvaluacionPrestamo(int id)
        {
            var preEvaluacionPrestamo = await _context.PreEvaluacionPrestamo.FindAsync(id);

            if (preEvaluacionPrestamo == null)
            {
                return NotFound();
            }

            return preEvaluacionPrestamo;
        }

        // PUT: api/PreEvaluacionPrestamoes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPreEvaluacionPrestamo(int id, PreEvaluacionPrestamo preEvaluacionPrestamo)
        {
            if (id != preEvaluacionPrestamo.EvaEvaluacionPrestamo)
            {
                return BadRequest();
            }

            _context.Entry(preEvaluacionPrestamo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PreEvaluacionPrestamoExists(id))
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

        // POST: api/PreEvaluacionPrestamoes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PreEvaluacionPrestamo>> PostPreEvaluacionPrestamo(PreEvaluacionPrestamo preEvaluacionPrestamo)
        {
            _context.PreEvaluacionPrestamo.Add(preEvaluacionPrestamo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPreEvaluacionPrestamo", new { id = preEvaluacionPrestamo.EvaEvaluacionPrestamo }, preEvaluacionPrestamo);
        }

        // DELETE: api/PreEvaluacionPrestamoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PreEvaluacionPrestamo>> DeletePreEvaluacionPrestamo(int id)
        {
            var preEvaluacionPrestamo = await _context.PreEvaluacionPrestamo.FindAsync(id);
            if (preEvaluacionPrestamo == null)
            {
                return NotFound();
            }

            _context.PreEvaluacionPrestamo.Remove(preEvaluacionPrestamo);
            await _context.SaveChangesAsync();

            return preEvaluacionPrestamo;
        }

        private bool PreEvaluacionPrestamoExists(int id)
        {
            return _context.PreEvaluacionPrestamo.Any(e => e.EvaEvaluacionPrestamo == id);
        }
    }
}
