using Rockaway.WebApp.Data;
using Rockaway.WebApp.Data.Entities;

namespace Rockaway.WebApp.Pages;

public class VenuesModel(RockawayDbContext db) : PageModel {
	public IEnumerable<Venue> Venues = default!;

	public void OnGet() => Venues = db.Venues.OrderBy(a => a.Name);
}