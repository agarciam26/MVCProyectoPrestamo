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
    public class PreDetalleAbonoPrestamoesController : ControllerBase
    {
        private readonly MVCProyecto10Context _context;

        public PreDetalleAbonoPrestamoesController(MVCProyecto10Context context)
        {
            _context = context;
        }

        // GET: api/PreDetalleAbonoPrestamoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PreDetalleAbonoPrestamo>>> GetPreDetalleAbonoPrestamo()
        {
            return await _context.PreDetalleAbonoPrestamo.ToListAsync();
        }

        // GET: api/PreDetalleAbonoPrestamoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PreDetalleAbonoPrestamo>> GetPreDetalleAbonoPrestamo(int id)
        {
            var preDetalleAbonoPrestamo = await _context.PreDetalleAbonoPrestamo.FindAsync(id);

            if (preDetalleAbonoPrestamo == null)
            {
                return NotFound();
            }

            return preDetalleAbonoPrestamo;
        }

        // PUT: api/PreDetalleAbonoPrestamoes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPreDetalleAbonoPrestamo(int id, PreDetalleAbonoPrestamo preDetalleAbonoPrestamo)
        {
            if (id != preDetalleAbonoPrestamo.DetabonoDetalleAbonoPrestamo)
            {
                return BadRequest();
            }

            _context.Entry(preDetalleAbonoPrestamo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PreDetalleAbonoPrestamoExists(id))
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

        // POST: api/PreDetalleAbonoPrestamoes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PreDetalleAbonoPrestamo>> PostPreDetalleAbonoPrestamo(PreDetalleAbonoPrestamo preDetalleAbonoPrestamo)
        {
            _context.PreDetalleAbonoPrestamo.Add(preDetalleAbonoPrestamo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPreDetalleAbonoPrestamo", new { id = preDetalleAbonoPrestamo.DetabonoDetalleAbonoPrestamo }, preDetalleAbonoPrestamo);
        }

        // DELETE: api/PreDetalleAbonoPrestamoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PreDetalleAbonoPrestamo>> DeletePreDetalleAbonoPrestamo(int id)
        {
            var preDetalleAbonoPrestamo = await _context.PreDetalleAbonoPrestamo.FindAsync(id);
            if (preDetalleAbonoPrestamo == null)
            {
                return NotFound();
            }

            _context.PreDetalleAbonoPrestamo.Remove(preDetalleAbonoPrestamo);
            await _context.SaveChangesAsync();

            return preDetalleAbonoPrestamo;
        }

        private bool PreDetalleAbonoPrestamoExists(int id)
        {
            return _context.PreDetalleAbonoPrestamo.Any(e => e.DetabonoDetalleAbonoPrestamo == id);
        }
    }
}
