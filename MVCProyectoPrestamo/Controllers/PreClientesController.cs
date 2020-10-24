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
    public class PreClientesController : ControllerBase
    {
        private readonly MVCProyecto10Context _context;

        public PreClientesController(MVCProyecto10Context context)
        {
            _context = context;
        }

        // GET: api/PreClientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PreCliente>>> GetPreCliente()
        {
            return await _context.PreCliente.ToListAsync();
        }

        // GET: api/PreClientes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PreCliente>> GetPreCliente(int id)
        {
            var preCliente = await _context.PreCliente.FindAsync(id);

            if (preCliente == null)
            {
                return NotFound();
            }

            return preCliente;
        }

        // PUT: api/PreClientes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPreCliente(int id, PreCliente preCliente)
        {
            if (id != preCliente.CliCliente)
            {
                return BadRequest();
            }

            _context.Entry(preCliente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PreClienteExists(id))
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

        // POST: api/PreClientes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PreCliente>> PostPreCliente(PreCliente preCliente)
        {
            _context.PreCliente.Add(preCliente);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPreCliente", new { id = preCliente.CliCliente }, preCliente);
        }

        // DELETE: api/PreClientes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PreCliente>> DeletePreCliente(int id)
        {
            var preCliente = await _context.PreCliente.FindAsync(id);
            if (preCliente == null)
            {
                return NotFound();
            }

            _context.PreCliente.Remove(preCliente);
            await _context.SaveChangesAsync();

            return preCliente;
        }

        private bool PreClienteExists(int id)
        {
            return _context.PreCliente.Any(e => e.CliCliente == id);
        }
    }
}
