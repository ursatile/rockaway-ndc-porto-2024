using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Rockaway.WebApp.Data;
using Rockaway.WebApp.Data.Entities;

namespace Rockaway.WebApp.Areas.Admin.Controllers {
	[Area("Admin")]
	public class VenuesController : Controller {
		private readonly RockawayDbContext _context;

		public VenuesController(RockawayDbContext context) {
			_context = context;
		}

		// GET: Admin/Venues
		public async Task<IActionResult> Index() {
			return View(await _context.Venues.ToListAsync());
		}

		// GET: Admin/Venues/Details/5
		public async Task<IActionResult> Details(Guid? id) {
			if (id == null) {
				return NotFound();
			}

			var venue = await _context.Venues
				.FirstOrDefaultAsync(m => m.Id == id);
			if (venue == null) {
				return NotFound();
			}

			return View(venue);
		}

		// GET: Admin/Venues/Create
		public IActionResult Create() {
			return View();
		}

		// POST: Admin/Venues/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("Id,Name,Slug,Address,City,CultureName,PostalCode,Telephone,WebsiteUrl")] Venue venue) {
			if (ModelState.IsValid) {
				venue.Id = Guid.NewGuid();
				_context.Add(venue);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			return View(venue);
		}

		// GET: Admin/Venues/Edit/5
		public async Task<IActionResult> Edit(Guid? id) {
			if (id == null) {
				return NotFound();
			}

			var venue = await _context.Venues.FindAsync(id);
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

			if (ModelState.IsValid) {
				try {
					_context.Update(venue);
					await _context.SaveChangesAsync();
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

			var venue = await _context.Venues
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
			var venue = await _context.Venues.FindAsync(id);
			if (venue != null) {
				_context.Venues.Remove(venue);
			}

			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		private bool VenueExists(Guid id) {
			return _context.Venues.Any(e => e.Id == id);
		}
	}
}
