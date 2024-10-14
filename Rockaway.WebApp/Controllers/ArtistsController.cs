using Rockaway.WebApp.Data;
using Rockaway.WebApp.Data.Entities;

namespace Rockaway.WebApp.Controllers;
public class ArtistsController(RockawayDbContext context) : Controller {
	// GET: Artists
	public async Task<IActionResult> Index() => View(await context.Artists.ToListAsync());

	// GET: Artists/Details/5
	public async Task<IActionResult> Details(Guid? id) {
		if (id == null) return NotFound();
		var artist = await context.Artists.FirstOrDefaultAsync(m => m.Id == id);
		if (artist == null) return NotFound();
		return View(artist);
	}

	// GET: Artists/Create
	public IActionResult Create() => View();

	// POST: Artists/Create
	// To protect from overposting attacks, enable the specific properties you want to bind to.
	// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
	[HttpPost]
	[ValidateAntiForgeryToken]
	public async Task<IActionResult> Create([Bind("Id,Name,Description,Slug")] Artist artist) {
		if (!ModelState.IsValid) return View(artist);
		artist.Id = Guid.NewGuid();
		context.Add(artist);
		await context.SaveChangesAsync();
		return RedirectToAction(nameof(Index));
	}

	// GET: Artists/Edit/5
	public async Task<IActionResult> Edit(Guid? id) {
		if (id == null) return NotFound();
		var artist = await context.Artists.FindAsync(id);
		if (artist == null) return NotFound();
		return View(artist);
	}

	// POST: Artists/Edit/5
	// To protect from overposting attacks, enable the specific properties you want to bind to.
	// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
	[HttpPost]
	[ValidateAntiForgeryToken]
	public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,Description,Slug")] Artist artist) {
		if (id != artist.Id) return NotFound();
		if (!ModelState.IsValid) return View(artist);
		try {
			context.Update(artist);
			await context.SaveChangesAsync();
		}
		catch (DbUpdateConcurrencyException) {
			if (!ArtistExists(artist.Id)) return NotFound();
			throw;
		}
		return RedirectToAction(nameof(Index));
	}

	// GET: Artists/Delete/5
	public async Task<IActionResult> Delete(Guid? id) {
		if (id == null) return NotFound();
		var artist = await context.Artists.FirstOrDefaultAsync(m => m.Id == id);
		if (artist == null) return NotFound();
		return View(artist);
	}

	// POST: Artists/Delete/5
	[HttpPost, ActionName("Delete")]
	[ValidateAntiForgeryToken]
	public async Task<IActionResult> DeleteConfirmed(Guid id) {
		var artist = await context.Artists.FindAsync(id);
		if (artist != null) context.Artists.Remove(artist);
		await context.SaveChangesAsync();
		return RedirectToAction(nameof(Index));
	}

	private bool ArtistExists(Guid id) => context.Artists.Any(e => e.Id == id);
}