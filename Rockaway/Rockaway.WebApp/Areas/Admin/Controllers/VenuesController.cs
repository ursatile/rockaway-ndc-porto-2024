using Rockaway.WebApp.Data;
using Rockaway.WebApp.Data.Entities;

namespace Rockaway.WebApp.Areas.Admin.Controllers {
	[Area("Admin")]
	public class VenuesController(RockawayDbContext context) : Controller {
		public async Task<IActionResult> Index()
			=> View(await context.Venues.ToListAsync());

		public async Task<IActionResult> Details(Guid? id) {
			if (id == null) return NotFound();
			var venue = await context.Venues.FirstOrDefaultAsync(m => m.Id == id);
			if (venue == null) return NotFound();
			return View(venue);
		}

		// GET: Admin/Venues/Create
		public IActionResult Create() => View();

		// POST: Admin/Venues/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("Id,Name,Slug,Address,City,CultureName,PostalCode,Telephone,WebsiteUrl")] Venue venue) {
			if (Country.FromCode(venue.CountryCode) == null) {
				ModelState.AddModelError("CultureName", $"Sorry, we couldn't match '{venue.CultureName}' with a country in our database.");
			}

			if (!ModelState.IsValid) return View(venue);

			venue.Id = Guid.NewGuid();
			context.Add(venue);
			await context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		// GET: Admin/Venues/Edit/5
		public async Task<IActionResult> Edit(Guid? id) {
			if (id == null) {
				return NotFound();
			}

			var venue = await context.Venues.FindAsync(id);
			if (venue == null) {
				return NotFound();
			}
			return View(venue);
		}

		// POST: Admin/Venues/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,Slug,Address,City,CultureName,PostalCode,Telephone,WebsiteUrl")] Venue venue) {

			if (id != venue.Id) {
				return NotFound();
			}

			if (Country.FromCode(venue.CountryCode) == null) {
				ModelState.AddModelError("CultureName", $"Sorry, we couldn't match '{venue.CultureName}' with a country in our database.");
			}

			if (ModelState.IsValid) {
				try {
					context.Update(venue);
					await context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException) {
					if (!VenueExists(venue.Id)) {
						return NotFound();
					} else {
						throw;
					}
				}
				return RedirectToAction(nameof(Index));
			}
			return View(venue);
		}

		// GET: Admin/Venues/Delete/5
		public async Task<IActionResult> Delete(Guid? id) {
			if (id == null) {
				return NotFound();
			}

			var venue = await context.Venues
				.FirstOrDefaultAsync(m => m.Id == id);
			if (venue == null) {
				return NotFound();
			}

			return View(venue);
		}

		// POST: Admin/Venues/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(Guid id) {
			var venue = await context.Venues.FindAsync(id);
			if (venue != null) {
				context.Venues.Remove(venue);
			}

			await context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		private bool VenueExists(Guid id) {
			return context.Venues.Any(e => e.Id == id);
		}
	}
}
