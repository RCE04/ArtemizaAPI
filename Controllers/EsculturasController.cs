using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API2.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EsculturasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EsculturasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Esculturas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Escultura>>> GetEsculturas()
        {
            return await _context.Esculturas.ToListAsync();
        }

        // GET: api/Esculturas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Escultura>> GetEscultura(int id)
        {
            var escultura = await _context.Esculturas.FindAsync(id);
            if (escultura == null)
            {
                return NotFound();
            }
            return escultura;
        }

        // POST: api/Esculturas
        [HttpPost]
        public async Task<ActionResult<Escultura>> PostEscultura(Escultura escultura)
        {
            _context.Esculturas.Add(escultura);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEscultura), new { id = escultura.Id }, escultura);
        }

        // PUT: api/Esculturas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEscultura(int id, Escultura escultura)
        {
            if (id != escultura.Id)
            {
                return BadRequest();
            }

            _context.Entry(escultura).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Esculturas.Any(e => e.Id == id))
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

        // DELETE: api/Esculturas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEscultura(int id)
        {
            var escultura = await _context.Esculturas.FindAsync(id);
            if (escultura == null)
            {
                return NotFound();
            }

            _context.Esculturas.Remove(escultura);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}