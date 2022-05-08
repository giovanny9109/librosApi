using LibrosAPI.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibrosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EditorialesController : ControllerBase
    {
        private readonly DataContext _context;

        public EditorialesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Editoriales>>> GetEditoriales()
        {
            return await _context.Editoriales.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Editoriales>> GetEditoriales(int id)
        {
            var editorial = await _context.Editoriales.FindAsync(id);
            if (editorial == null)
            {
                return NotFound();
            }
            return editorial;
        }

        // PUT api/Autores/1
        [HttpPut("{id}")]
        public async Task<ActionResult> PutEditoriales(int id, Editoriales editorial)
        {

            if (editorial.Id != id)
            {
                return BadRequest();

            }
            _context.Entry(editorial).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EditorialesExists(id))
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
        public async Task<ActionResult<Editoriales>> PostEditoriales(Editoriales editorial)
        {
            try
            {
                _context.Editoriales.Add(editorial);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

            //_context.Editoriales.Add(editorial);
            //await _context.SaveChangesAsync();
            //return CreatedAtAction("GetEditorial", new { id = editorial.Id }, editorial);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEditoriales(int id)
        {
            try
            {
                var editorial = await _context.Editoriales.FindAsync(id);
                if (editorial == null)
                {

                    return NotFound();
                }
                _context.Editoriales.Remove(editorial);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        private bool EditorialesExists(int id)
        {
            return _context.Editoriales.Any(e => e.Id == id);
        }
    }
}
