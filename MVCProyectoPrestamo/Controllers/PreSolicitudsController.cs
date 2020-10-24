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
    public class PreSolicitudsController : ControllerBase
    {
        private readonly MVCProyecto10Context _context;

        public PreSolicitudsController(MVCProyecto10Context context)
        {
            _context = context;
        }

        // GET: api/PreSolicituds
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PreSolicitud>>> GetPreSolicitud()
        {
            return await _context.PreSolicitud.ToListAsync();
        }

        // GET: api/PreSolicituds/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PreSolicitud>> GetPreSolicitud(int id)
        {
            var preSolicitud = await _context.PreSolicitud.FindAsync(id);

            if (preSolicitud == null)
            {
                return NotFound();
            }

            return preSolicitud;
        }

        // PUT: api/PreSolicituds/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPreSolicitud(int id, PreSolicitud preSolicitud)
        {
            if (id != preSolicitud.SolSolicitud)
            {
                return BadRequest();
            }

            _context.Entry(preSolicitud).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PreSolicitudExists(id))
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

        // POST: api/PreSolicituds
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PreSolicitud>> PostPreSolicitud(PreSolicitud preSolicitud)
        {
            _context.PreSolicitud.Add(preSolicitud);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPreSolicitud", new { id = preSolicitud.SolSolicitud }, preSolicitud);
        }

        // DELETE: api/PreSolicituds/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PreSolicitud>> DeletePreSolicitud(int id)
        {
            var preSolicitud = await _context.PreSolicitud.FindAsync(id);
            if (preSolicitud == null)
            {
                return NotFound();
            }

            _context.PreSolicitud.Remove(preSolicitud);
            await _context.SaveChangesAsync();

            return preSolicitud;
        }

        private bool PreSolicitudExists(int id)
        {
            return _context.PreSolicitud.Any(e => e.SolSolicitud == id);
        }
    }
}
