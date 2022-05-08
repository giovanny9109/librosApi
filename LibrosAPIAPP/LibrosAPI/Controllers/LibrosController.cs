using LibrosAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibrosAPI.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class LibrosController : Controller
    {
        private readonly DataContext _context;

        public LibrosController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Libros>>> GetLibros()
        {
            return await _context.Libros.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Libros>> GetLibros(int id)
        {
            var libro = await _context.Libros.FindAsync(id);
            if(libro == null)
            {
                return NotFound();
            }
            return libro;
        }

        // PUT api/Autores/1
        [HttpPut("{id}")]       
        public async Task<ActionResult> PutLibros(int id, Libros libro)
        {

            if (libro.Id != id)
            {
                return BadRequest();

            }
            _context.Entry(libro).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LibrosExists(id))
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
        public async Task<ActionResult<Libros>> PostLibros(Libros libro)
        {
            try
            {
                _context.Libros.Add(libro);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

            //_context.Libros.Add(libro);
            //await _context.SaveChangesAsync();
            //return CreatedAtAction("GetAutor", new { id = libro.Id }, libro);  
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteLibros(int id)
        {
            try
            {
                var libro = await _context.Libros.FindAsync(id);
                if (libro == null)
                {
                    
                    return NotFound();
                }
                _context.Libros.Remove(libro);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        private bool LibrosExists(int id)
        {
            return _context.Libros.Any(e => e.Id == id);
        }



        

        /*

        // GET: LibrosController
        public ActionResult Index()
        {
            return View();
        }

        // GET: LibrosController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: LibrosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LibrosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LibrosController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LibrosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LibrosController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LibrosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        */
    }
}
