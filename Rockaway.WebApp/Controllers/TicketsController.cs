using Rockaway.WebApp.Data;
using Rockaway.WebApp.Data.Entities;
using Rockaway.WebApp.Models;

namespace Rockaway.WebApp.Controllers;

[Route("[action]/{venue}/{date}")]
public class TicketsController(RockawayDbContext db, IClock clock) : Controller {

	private Task<Show?> FindShow(string venue, LocalDate date) => db.Shows
		.Include(s => s.TicketTypes)
		.Include(s => s.Venue)
		.Include(s => s.HeadlineArtist)
		.Include(s => s.SupportSlots).ThenInclude(slot => slot.Artist)
		.FirstOrDefaultAsync(s => s.Venue.Slug == venue && s.Date == date);

	[HttpGet]
	public async Task<IActionResult> Show(string venue, LocalDate date) {
		var show = await FindShow(venue, date);
		if (show == default) return NotFound();
		var model = new ShowViewData(show);
		return View(model);
	}

	[HttpPost]
	public async Task<IActionResult> Show(string venue, LocalDate date, Dictionary<Guid, int> tickets) {
		var show = await FindShow(venue, date);
		if (show == default) return NotFound();
		var ticketOrder = show.CreateOrder(tickets, clock.GetCurrentInstant());
		db.TicketOrders.Add(ticketOrder);
		await db.SaveChangesAsync();
		return RedirectToAction("Confirm", "Checkout", new { id = ticketOrder.Id });
	}
}