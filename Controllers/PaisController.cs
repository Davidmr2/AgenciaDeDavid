using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AgenciaDeDavid.Data;
using AgenciaDeDavid.Models;

namespace AgenciaDeDavid.Controllers
{
	public class PaisController : Controller
	{
		private readonly ApplicationDbContext _context;

		public PaisController(ApplicationDbContext context)
		{
			_context = context;
		}

		// GET: Pais
		public async Task<IActionResult> Index()
		{
			return View(await _context.Paises.ToListAsync());
		}

		// GET: Pais/Create
		public IActionResult Create()
		{
			return View();
		}

		// POST: Pais/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(Pais pais)
		{
			if (ModelState.IsValid)
			{
				_context.Add(pais);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			return View(pais);
		}

		// GET: Pais/Edit/5
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null || _context.Paises == null)
				return NotFound();

			var pais = await _context.Paises.FindAsync(id);
			if (pais == null)
				return NotFound();

			return View(pais);
		}

		// POST: Pais/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, Pais pais)
		{
			if (id != pais.PaisID)
				return NotFound();

			if (ModelState.IsValid)
			{
				try
				{
					_context.Update(pais);
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!PaisExists(pais.PaisID))
						return NotFound();
					else
						throw;
				}
				return RedirectToAction(nameof(Index));
			}
			return View(pais);
		}

		// GET: Pais/Delete/5
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null || _context.Paises == null)
				return NotFound();

			var pais = await _context.Paises
				.FirstOrDefaultAsync(m => m.PaisID == id);
			if (pais == null)
				return NotFound();

			return View(pais);
		}

		// POST: Pais/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			var pais = await _context.Paises.FindAsync(id);
			if (pais != null)
			{
				_context.Paises.Remove(pais);
				await _context.SaveChangesAsync();
			}

			return RedirectToAction(nameof(Index));
		}

		// GET: Pais/Details/5
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null || _context.Paises == null)
				return NotFound();

			var pais = await _context.Paises
				.FirstOrDefaultAsync(m => m.PaisID == id);
			if (pais == null)
				return NotFound();

			return View(pais);
		}

		private bool PaisExists(int id)
		{
			return _context.Paises.Any(e => e.PaisID == id);
		}

		public async Task<IActionResult> ExportarCSV()
		{
			var paises = await _context.Paises.ToListAsync();
			var builder = new StringBuilder();
			builder.AppendLine("ID,Nombre");

			foreach (var p in paises)
			{
				builder.AppendLine($"{p.ID},{p.Nombre}");
			}

			return File(Encoding.UTF8.GetBytes(builder.ToString()), "text/csv", "Paises.csv");
		}
	}
}
	

