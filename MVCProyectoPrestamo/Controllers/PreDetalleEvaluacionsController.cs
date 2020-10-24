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
    public class PreDetalleEvaluacionsController : ControllerBase
    {
        private readonly MVCProyecto10Context _context;

        public PreDetalleEvaluacionsController(MVCProyecto10Context context)
        {
            _context = context;
        }

        // GET: api/PreDetalleEvaluacions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PreDetalleEvaluacion>>> GetPreDetalleEvaluacion()
        {
            return await _context.PreDetalleEvaluacion.ToListAsync();
        }

        // GET: api/PreDetalleEvaluacions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PreDetalleEvaluacion>> GetPreDetalleEvaluacion(int id)
        {
            var preDetalleEvaluacion = await _context.PreDetalleEvaluacion.FindAsync(id);

            if (preDetalleEvaluacion == null)
            {
                return NotFound();
            }

            return preDetalleEvaluacion;
        }

        // PUT: api/PreDetalleEvaluacions/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPreDetalleEvaluacion(int id, PreDetalleEvaluacion preDetalleEvaluacion)
        {
            if (id != preDetalleEvaluacion.DetevalDetalleEvaluacion)
            {
                return BadRequest();
            }

            _context.Entry(preDetalleEvaluacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PreDetalleEvaluacionExists(id))
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

        // POST: api/PreDetalleEvaluacions
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PreDetalleEvaluacion>> PostPreDetalleEvaluacion(PreDetalleEvaluacion preDetalleEvaluacion)
        {
            _context.PreDetalleEvaluacion.Add(preDetalleEvaluacion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPreDetalleEvaluacion", new { id = preDetalleEvaluacion.DetevalDetalleEvaluacion }, preDetalleEvaluacion);
        }

        // DELETE: api/PreDetalleEvaluacions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PreDetalleEvaluacion>> DeletePreDetalleEvaluacion(int id)
        {
            var preDetalleEvaluacion = await _context.PreDetalleEvaluacion.FindAsync(id);
            if (preDetalleEvaluacion == null)
            {
                return NotFound();
            }

            _context.PreDetalleEvaluacion.Remove(preDetalleEvaluacion);
            await _context.SaveChangesAsync();

            return preDetalleEvaluacion;
        }

        private bool PreDetalleEvaluacionExists(int id)
        {
            return _context.PreDetalleEvaluacion.Any(e => e.DetevalDetalleEvaluacion == id);
        }
    }
}
