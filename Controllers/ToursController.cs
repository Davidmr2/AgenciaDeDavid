using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AgenciaDeDavid.Data;
using AgenciaDeDavid.Models;
using System.Threading.Tasks;
using System.Linq;

namespace AgenciaDeDavid.Controllers
{
    public class ToursController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ToursController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Tours
        public async Task<IActionResult> Index()
        {
            var tours = _context.Tours.Include(t => t.Pais).Include(t => t.Destino);
            return View(await tours.ToListAsync());
        }

        // GET: Tours/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var tour = await _context.Tours
                .Include(t => t.Pais)
                .Include(t => t.Destino)
                .FirstOrDefaultAsync(t => t.ID == id);

            if (tour == null) return NotFound();

            return View(tour);
        }

        // GET: Tours/Create
        public IActionResult Create()
        {
            ViewData["PaisID"] = new SelectList(_context.Paises, "PaisID", "Nombre");
            ViewData["DestinoID"] = new SelectList(_context.Destinos, "DestinoID", "Nombre");
            return View();
        }

        // POST: Tours/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Nombre,Precio,FechaInicio,FechaFin,PaisID,DestinoID")] Tour tour)
        {
            if (!ModelState.IsValid)
            {
                _context.Add(tour);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PaisID"] = new SelectList(_context.Paises, "PaisID", "Nombre", tour.PaisID);
            ViewData["DestinoID"] = new SelectList(_context.Destinos, "DestinoID", "Nombre", tour.DestinoID);
            return View(tour);
        }

        // GET: Tours/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var tour = await _context.Tours.FindAsync(id);
            if (tour == null) return NotFound();

            ViewData["PaisID"] = new SelectList(_context.Paises, "PaisID", "Nombre", tour.PaisID);
            ViewData["DestinoID"] = new SelectList(_context.Destinos, "DestinoID", "Nombre", tour.DestinoID);
            return View(tour);
        }

        // POST: Tours/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Nombre,Precio,FechaInicio,FechaFin,PaisID,DestinoID")] Tour tour)
        {
            if (id != tour.ID) return NotFound();

            if (!ModelState.IsValid)
            {
                
                    _context.Update(tour);
                    await _context.SaveChangesAsync();
                
                return RedirectToAction(nameof(Index));
            }
            ViewData["PaisID"] = new SelectList(_context.Paises, "PaisID", "Nombre", tour.PaisID);
            ViewData["DestinoID"] = new SelectList(_context.Destinos, "DestinoID", "Nombre", tour.DestinoID);
            return View(tour);
        }

        // GET: Tours/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var tour = await _context.Tours
                .Include(t => t.Pais)
                .Include(t => t.Destino)
                .FirstOrDefaultAsync(t => t.ID == id);

            if (tour == null) return NotFound();

            return View(tour);
        }

        // POST: Tours/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tour = await _context.Tours.FindAsync(id);
            if (tour != null)
            {
                _context.Tours.Remove(tour);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool TourExists(int id)
        {
            return _context.Tours.Any(t => t.ID == id);
        }
		// GET: Tours/ExportarCSV
		public async Task<IActionResult> ExportarCSV()
		{
			var tours = await _context.Tours
				.Include(t => t.Pais)
				.Include(t => t.Destino)
				.ToListAsync();

			var builder = new StringBuilder();
			builder.AppendLine("ID,Nombre,Precio,FechaInicio,FechaFin,Pais,Destino");

			foreach (var tour in tours)
			{
				builder.AppendLine($"{tour.ID},{tour.Nombre},{tour.Precio},{tour.FechaInicio:yyyy-MM-dd},{tour.FechaFin:yyyy-MM-dd},{tour.Pais?.Nombre},{tour.Destino?.Nombre}");
			}

			return File(Encoding.UTF8.GetBytes(builder.ToString()), "text/csv", "tours.csv");
		}

	}
}
