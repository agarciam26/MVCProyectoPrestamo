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
    public class PreAbonoPrestamoesController : ControllerBase
    {
        private readonly MVCProyecto10Context _context;

        public PreAbonoPrestamoesController(MVCProyecto10Context context)
        {
            _context = context;
        }

        // GET: api/PreAbonoPrestamoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PreAbonoPrestamo>>> GetPreAbonoPrestamo()
        {
            return await _context.PreAbonoPrestamo.ToListAsync();
        }

        // GET: api/PreAbonoPrestamoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PreAbonoPrestamo>> GetPreAbonoPrestamo(int id)
        {
            var preAbonoPrestamo = await _context.PreAbonoPrestamo.FindAsync(id);

            if (preAbonoPrestamo == null)
            {
                return NotFound();
            }

            return preAbonoPrestamo;
        }

        // PUT: api/PreAbonoPrestamoes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPreAbonoPrestamo(int id, PreAbonoPrestamo preAbonoPrestamo)
        {
            if (id != preAbonoPrestamo.AbonAbonoPrestamo)
            {
                return BadRequest();
            }

            _context.Entry(preAbonoPrestamo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PreAbonoPrestamoExists(id))
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

        // POST: api/PreAbonoPrestamoes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PreAbonoPrestamo>> PostPreAbonoPrestamo(PreAbonoPrestamo preAbonoPrestamo)
        {
            _context.PreAbonoPrestamo.Add(preAbonoPrestamo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPreAbonoPrestamo", new { id = preAbonoPrestamo.AbonAbonoPrestamo }, preAbonoPrestamo);
        }

        // DELETE: api/PreAbonoPrestamoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PreAbonoPrestamo>> DeletePreAbonoPrestamo(int id)
        {
            var preAbonoPrestamo = await _context.PreAbonoPrestamo.FindAsync(id);
            if (preAbonoPrestamo == null)
            {
                return NotFound();
            }

            _context.PreAbonoPrestamo.Remove(preAbonoPrestamo);
            await _context.SaveChangesAsync();

            return preAbonoPrestamo;
        }

        private bool PreAbonoPrestamoExists(int id)
        {
            return _context.PreAbonoPrestamo.Any(e => e.AbonAbonoPrestamo == id);
        }
    }
}
