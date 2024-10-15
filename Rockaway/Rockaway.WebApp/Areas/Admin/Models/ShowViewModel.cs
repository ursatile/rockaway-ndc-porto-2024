using Rockaway.WebApp.Data.Entities;

namespace Rockaway.WebApp.Areas.Admin.Models {
	public class ShowViewModel {
		// public string VenueName { get; set; }
		public LocalDate Date { get; set; }

		public string HeadlineArtistName { get; set; } = String.Empty;

		public List<string> SupportArtistNames { get; set; } = [];

		public bool DisplaySupportArtists
			=> SupportArtistNames.Any();

		public ShowViewModel(Show show) {
			Date = show.Date;
			HeadlineArtistName = show.HeadlineArtist.Name;
			SupportArtistNames = show.SupportArtists.Select(a => a.Name).ToList();
		}
	}
}
