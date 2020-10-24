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
    public class PrePresolicitudsController : ControllerBase
    {
        private readonly MVCProyecto10Context _context;

        public PrePresolicitudsController(MVCProyecto10Context context)
        {
            _context = context;
        }

        // GET: api/PrePresolicituds
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PrePresolicitud>>> GetPrePresolicitud()
        {
            return await _context.PrePresolicitud.ToListAsync();
        }

        // GET: api/PrePresolicituds/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PrePresolicitud>> GetPrePresolicitud(int id)
        {
            var prePresolicitud = await _context.PrePresolicitud.FindAsync(id);

            if (prePresolicitud == null)
            {
                return NotFound();
            }

            return prePresolicitud;
        }

        // PUT: api/PrePresolicituds/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPrePresolicitud(int id, PrePresolicitud prePresolicitud)
        {
            if (id != prePresolicitud.PrePresolicitud1)
            {
                return BadRequest();
            }

            _context.Entry(prePresolicitud).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PrePresolicitudExists(id))
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

        // POST: api/PrePresolicituds
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PrePresolicitud>> PostPrePresolicitud(PrePresolicitud prePresolicitud)
        {
            _context.PrePresolicitud.Add(prePresolicitud);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPrePresolicitud", new { id = prePresolicitud.PrePresolicitud1 }, prePresolicitud);
        }

        // DELETE: api/PrePresolicituds/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PrePresolicitud>> DeletePrePresolicitud(int id)
        {
            var prePresolicitud = await _context.PrePresolicitud.FindAsync(id);
            if (prePresolicitud == null)
            {
                return NotFound();
            }

            _context.PrePresolicitud.Remove(prePresolicitud);
            await _context.SaveChangesAsync();

            return prePresolicitud;
        }

        private bool PrePresolicitudExists(int id)
        {
            return _context.PrePresolicitud.Any(e => e.PrePresolicitud1 == id);
        }
    }
}
