using Rockaway.WebApp.Data.Entities;

namespace Rockaway.WebApp.Models;

public class ArtistViewData(Artist artist) {

	private const string CLOUDINARY_URL_TEMPLATE =
		"https://res.cloudinary.com/ursatile/image/upload/c_fill,g_auto:face,w_{0},h_{1}/rockaway/{2}.jpg";

	public string Name { get; } = artist.Name;

	public string Slug { get; } = artist.Slug;

	public string Description { get; } = artist.Description;

	public string GetImageUrl(int width, int height)
		=> String.Format(CLOUDINARY_URL_TEMPLATE, width, height, Slug);

	public string CssClass => Name.Length > 20 ? "long-name" : "";

	public IEnumerable<ShowViewData> Shows => artist.HeadlineShows
		.OrderBy(show => show.Date).Select(show => new ShowViewData(show));
}