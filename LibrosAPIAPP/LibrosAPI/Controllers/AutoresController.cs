using LibrosAPI.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibrosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutoresController : ControllerBase
    {
        private readonly DataContext _context;

        public AutoresController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Autores>>> GetAutores()
        {
            return await _context.Autores.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Autores>> GetAutores(int id)
        {
            var autor = await _context.Autores.FindAsync(id);
            if (autor == null)
            {
                return NotFound();
            }
            return autor;
        }

        // PUT api/Autores/1
        [HttpPut("{id}")]
        public async Task<ActionResult> PutAutores(int id, Autores autor)
        {

            if (autor.Id != id)
            {
                return BadRequest();

            }
            _context.Entry(autor).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AutoresExists(id))
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

        [HttpPost]
        public async Task<ActionResult<Autores>> PostAutores(Autores autor)
        {
            try
            {
                _context.Autores.Add(autor);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

            //_context.Autores.Add(autor);
            //await _context.SaveChangesAsync();
            //return CreatedAtAction("GetAutor", new { id = autor.Id }, autor);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAutores(int id)
        {
            try
            {
                var autor = await _context.Autores.FindAsync(id);
                if (autor == null)
                {

                    return NotFound();
                }
                _context.Autores.Remove(autor);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        private bool AutoresExists(int id)
        {
            return _context.Autores.Any(e => e.Id == id);
        }
    }
}
