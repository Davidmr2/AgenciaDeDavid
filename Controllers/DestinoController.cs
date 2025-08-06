using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AgenciaDeDavid.Data;
using AgenciaDeDavid.Models;

namespace AgenciaDeDavid.Controllers
{
	public class DestinoController : Controller
	{
		private readonly ApplicationDbContext _context;

		public DestinoController(ApplicationDbContext context)
		{
			_context = context;
		}

		// GET: Destino
		public async Task<IActionResult> Index()
		{
			var destinosConPais = await _context.Destinos
				.Include(d => d.Pais)
				.ToListAsync();

			return View(destinosConPais);
		}

		// GET: Destino/Details/5
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null) return NotFound();

			var destino = await _context.Destinos
				.Include(d => d.Pais)
				.FirstOrDefaultAsync(m => m.DestinoID == id);

			if (destino == null) return NotFound();

			return View(destino);
		}

		// GET: Destino/Create
		public IActionResult Create()
		{
			ViewData["PaisID"] = new SelectList(_context.Paises, "PaisID", "Nombre");
			return View();
		}

		// POST: Destino/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(Destino destino)
		{
			if (!ModelState.IsValid)
			{
				_context.Add(destino);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}

			ViewData["PaisID"] = new SelectList(_context.Paises, "PaisID", "Nombre", destino.PaisID);
			return View(destino);
		}



		// GET: Destino/Edit/5
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null) return NotFound();

			var destino = await _context.Destinos.FindAsync(id);
			if (destino == null) return NotFound();

			ViewData["PaisID"] = new SelectList(_context.Paises, "PaisID", "Nombre", destino.PaisID);
			return View(destino);
		}

		// POST: Destino/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("DestinoID,Nombre,Ciudad,LugarTuristico,PaisID")] Destino destino)
		{
			if (id != destino.DestinoID) return NotFound();

			if (!ModelState.IsValid)
			{
				
				
					_context.Update(destino);
					await _context.SaveChangesAsync();
				
				
				return RedirectToAction(nameof(Index));
			}

			ViewData["PaisID"] = new SelectList(_context.Paises, "PaisID", "Nombre", destino.PaisID);
			return View(destino);
		}

		// GET: Destino/Delete/5
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null) return NotFound();

			var destino = await _context.Destinos
				.Include(d => d.Pais)
				.FirstOrDefaultAsync(m => m.DestinoID == id);

			if (destino == null) return NotFound();

			return View(destino);
		}

		// POST: Destino/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			var destino = await _context.Destinos.FindAsync(id);
			if (destino != null)
			{
				_context.Destinos.Remove(destino);
				await _context.SaveChangesAsync();
			}
			return RedirectToAction(nameof(Index));
		}

		// GET: Destino/ExportarCSV
		public async Task<IActionResult> ExportarCSV()
		{
			var destinos = await _context.Destinos.Include(d => d.Pais).ToListAsync();
			var builder = new StringBuilder();
			builder.AppendLine("ID,Nombre,Ciudad,LugarTuristico,Pais");

			foreach (var d in destinos)
			{
				builder.AppendLine($"{d.DestinoID},{d.Nombre},{d.GetCiudad()},{d.LugarTuristico},{d.Pais?.Nombre}");
			}

			return File(Encoding.UTF8.GetBytes(builder.ToString()), "text/csv", "Destinos.csv");
		}
	}

	}
