using Rockaway.WebApp.Data;
using Rockaway.WebApp.Models;

namespace Rockaway.WebApp.Pages;

public class ArtistsModel(RockawayDbContext db) : PageModel {
	public IEnumerable<ArtistViewData> Artists = default!;

	public void OnGet() => Artists = db.Artists
		.Select(a => new ArtistViewData(a))
		.ToList();
}