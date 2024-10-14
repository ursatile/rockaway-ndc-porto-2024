using Rockaway.WebApp.Data.Entities;
// ReSharper disable InconsistentNaming

namespace Rockaway.WebApp.Data.Sample;

public static partial class SampleData {

	public static Show WithTicketType(this Show show, Guid id, string name, decimal price, int? limit = null) {
		show.TicketTypes.Add(new(id, show, name, price, limit));
		return show;
	}

	public static Show WithSupportActs(this Show show, params Artist[] artists) {
		show.SupportSlots.AddRange(artists.Select(artist => new SupportSlot() {
			Show = show,
			Artist = artist,
			SlotNumber = show.NextSupportSlotNumber
		}));
		return show;
	}

	public static class Shows {

		private static int seed = 1;
		private static Guid NextId => TestGuid(seed++, 'C');

		private static IEnumerable<Show> GenerateTour(Artist artist, LocalDate firstDate, params Artist[] supportActs) {
			yield return Venues.Barracuda
				.BookShow(artist, firstDate)
				.WithTicketType(NextId, "Upstairs unallocated seating", price: 25, limit: 100)
				.WithTicketType(NextId, "Downstairs standing", price: 25, limit: 120)
				.WithTicketType(NextId, "Cabaret table (4 people)", price: 120, limit: 10)
				.WithSupportActs(supportActs);

			yield return Venues.Columbia.BookShow(artist, firstDate.PlusDays(2))
				.WithTicketType(NextId, "General Admission", price: 35)
				.WithTicketType(NextId, "VIP Meet & Greet", price: 75, limit: 20)
				.WithSupportActs(supportActs);

			yield return Venues.Bataclan.BookShow(artist, firstDate.PlusDays(3))
				.WithTicketType(NextId, "General Admission", price: 35)
				.WithTicketType(NextId, "VIP Meet & Greet", price: 75)
				.WithSupportActs(supportActs);

			yield return Venues.NewCrossInn.BookShow(artist, firstDate.PlusDays(4))
				.WithTicketType(NextId, "General Admission", price: 25)
				.WithTicketType(NextId, "VIP Meet & Greet", price: 55, limit: 20)
				.WithSupportActs(supportActs);

			yield return Venues.JohnDee.BookShow(artist, firstDate.PlusDays(5))
				.WithTicketType(NextId, "General Admission", price: 350)
				.WithTicketType(NextId, "VIP Meet & Greet", price: 750, limit: 25)
				.WithSupportActs(supportActs);

			yield return Venues.PubAnchor.BookShow(artist, firstDate.PlusDays(7))
				.WithTicketType(NextId, "General Admission", price: 300)
				.WithTicketType(NextId, "VIP Meet & Greet", price: 720, limit: 10)
				.WithSupportActs(supportActs);

			yield return Venues.Gagarin.BookShow(artist, firstDate.PlusDays(9))
				.WithTicketType(NextId, "General Admission", 25)
				.WithSupportActs(supportActs);
		}

		public static IEnumerable<Show> GenerateShows(LocalDate seedDate) {
			var artists = Artists.AllArtists.ToList();
			for (var i = 0; i < (artists.Count - 3); i += 3) {
				foreach (var show in GenerateTour(artists[i], seedDate.PlusWeeks(4 * i),
							 artists[i + 1], artists[i + 2]
						 )) yield return show;
				foreach (var show in GenerateTour(artists[i + 1], seedDate.PlusWeeks(4 * i + 1))) yield return show;
				foreach (var show in GenerateTour(artists[i + 2], seedDate.PlusWeeks(4 * i + 2))) yield return show;
			}
		}

		public static Show[] AllShows = GenerateShows(new(2024, 10, 14)).ToArray();

		public static IEnumerable<TicketType> AllTicketTypes => AllShows.SelectMany(show => show.TicketTypes);

		public static IEnumerable<SupportSlot> AllSupportSlots => AllShows.SelectMany(show => show.SupportSlots);
	}
}
