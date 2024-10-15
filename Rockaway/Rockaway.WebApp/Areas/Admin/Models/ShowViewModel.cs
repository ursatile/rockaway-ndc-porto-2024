using Rockaway.WebApp.Data.Entities;

namespace Rockaway.WebApp.Areas.Admin.Models {
	public class ShowViewModel {

		public DateTime Date { get; set; }

		public string HeadlineArtistName { get; set; } = String.Empty;

		public List<string> SupportArtistNames { get; set; } = [];

		public bool DisplaySupportArtists => SupportArtistNames.Any();
		public string VenueName { get; set; } = String.Empty;
		public string VenueSlug { get; set; } = String.Empty;
		public ShowViewModel() { }

		public ShowViewModel(Show show) {
			VenueName = show.Venue.Name;
			VenueSlug = show.Venue.Slug;
			Date = show.Date.ToDateTimeUnspecified();
			HeadlineArtistName = show.HeadlineArtist?.Name ?? String.Empty;
			SupportArtistNames = show.SupportArtists?.Select(a => a.Name).ToList() ?? [];
		}
	}

	public class ShowPostModel : ShowViewModel {
		public ShowPostModel() { }

		public ShowPostModel(Show show) : base(show) {
			HeadlineArtistId = show.HeadlineArtist?.Id ?? Guid.Empty;
			InvalidDates = show.Venue.Shows.Select(s => s.Date).ToList();
		}
		public Guid HeadlineArtistId { get; set; }

		public List<LocalDate> InvalidDates = [];
	}
}
