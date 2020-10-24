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
    public class PreEmpleadoesController : ControllerBase
    {
        private readonly MVCProyecto10Context _context;

        public PreEmpleadoesController(MVCProyecto10Context context)
        {
            _context = context;
        }

        // GET: api/PreEmpleadoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PreEmpleado>>> GetPreEmpleado()
        {
            return await _context.PreEmpleado.ToListAsync();
        }

        // GET: api/PreEmpleadoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PreEmpleado>> GetPreEmpleado(int id)
        {
            var preEmpleado = await _context.PreEmpleado.FindAsync(id);

            if (preEmpleado == null)
            {
                return NotFound();
            }

            return preEmpleado;
        }

        // PUT: api/PreEmpleadoes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPreEmpleado(int id, PreEmpleado preEmpleado)
        {
            if (id != preEmpleado.EmpEmpleado)
            {
                return BadRequest();
            }

            _context.Entry(preEmpleado).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PreEmpleadoExists(id))
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

        // POST: api/PreEmpleadoes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PreEmpleado>> PostPreEmpleado(PreEmpleado preEmpleado)
        {
            _context.PreEmpleado.Add(preEmpleado);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPreEmpleado", new { id = preEmpleado.EmpEmpleado }, preEmpleado);
        }

        // DELETE: api/PreEmpleadoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PreEmpleado>> DeletePreEmpleado(int id)
        {
            var preEmpleado = await _context.PreEmpleado.FindAsync(id);
            if (preEmpleado == null)
            {
                return NotFound();
            }

            _context.PreEmpleado.Remove(preEmpleado);
            await _context.SaveChangesAsync();

            return preEmpleado;
        }

        private bool PreEmpleadoExists(int id)
        {
            return _context.PreEmpleado.Any(e => e.EmpEmpleado == id);
        }
    }
}
