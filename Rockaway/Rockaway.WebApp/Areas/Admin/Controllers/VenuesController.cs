using Rockaway.WebApp.Data;
using Rockaway.WebApp.Data.Entities;

namespace Rockaway.WebApp.Areas.Admin.Controllers;

[Area("admin")]
public class VenuesController(RockawayDbContext context) : Controller {
	// GET: Venues
	public async Task<IActionResult> Index() => View(await context.Venues.ToListAsync());

	// GET: Venues/Details/5
	public async Task<IActionResult> Details(Guid? id) {
		if (id == null) return NotFound();
		var venue = await context.Venues.FirstOrDefaultAsync(m => m.Id == id);
		if (venue == null) return NotFound();
		return View(venue);
	}

	// GET: Venues/Create
	public IActionResult Create() => View();

	// POST: Venues/Create
	// To protect from overposting attacks, enable the specific properties you want to bind to.
	// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
	[HttpPost]
	[ValidateAntiForgeryToken]
	public async Task<IActionResult> Create([Bind("Id,Name,Slug,Address,City,CountryCode,PostalCode,Telephone,WebsiteUrl")] Venue venue) {
		if (!ModelState.IsValid) return View(venue);
		venue.Id = Guid.NewGuid();
		context.Add(venue);
		await context.SaveChangesAsync();
		return RedirectToAction(nameof(Index));
	}

	// GET: Venues/Edit/5
	public async Task<IActionResult> Edit(Guid? id) {
		if (id == null) return NotFound();

		var venue = await context.Venues.FindAsync(id);
		if (venue == null) return NotFound();
		return View(venue);
	}

	// POST: Venues/Edit/5
	// To protect from overposting attacks, enable the specific properties you want to bind to.
	// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
	[HttpPost]
	[ValidateAntiForgeryToken]
	public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,Slug,Address,City,CountryCode,PostalCode,Telephone,WebsiteUrl")] Venue venue) {
		if (id != venue.Id) return NotFound();
		if (!ModelState.IsValid) return View(venue);
		try {
			context.Update(venue);
			await context.SaveChangesAsync();
		}
		catch (DbUpdateConcurrencyException) {
			if (!VenueExists(venue.Id)) return NotFound();
			throw;
		}
		return RedirectToAction(nameof(Index));
	}

	// GET: Venues/Delete/5
	public async Task<IActionResult> Delete(Guid? id) {
		if (id == null) return NotFound();

		var venue = await context.Venues.FirstOrDefaultAsync(m => m.Id == id);
		if (venue == null) return NotFound();
		return View(venue);
	}

	// POST: Venues/Delete/5
	[HttpPost, ActionName("Delete")]
	[ValidateAntiForgeryToken]
	public async Task<IActionResult> DeleteConfirmed(Guid id) {
		var venue = await context.Venues.FindAsync(id);
		if (venue != null) context.Venues.Remove(venue);
		await context.SaveChangesAsync();
		return RedirectToAction(nameof(Index));
	}

	private bool VenueExists(Guid id) => context.Venues.Any(e => e.Id == id);
}