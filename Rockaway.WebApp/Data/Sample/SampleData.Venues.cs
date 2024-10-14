using Rockaway.WebApp.Data.Entities;

namespace Rockaway.WebApp.Data.Sample;

public static partial class SampleData {

	public static class Venues {
		private static int seed = 1;
		private static Guid NextId => TestGuid(seed++, 'b');

		public static Venue Electric = new(NextId, "Electric Brixton", "electric-brixton", "Town Hall Parade", "London", "en-GB", "SW2 1RJ",
			"020 7274 2290", "https://www.electricbrixton.uk.com/");

		public static Venue Bataclan = new(NextId, "Bataclan", "bataclan-paris", "50 Boulevard Voltaire", "Paris", "fr-FR", "75011",
			"+33 1 43 14 00 30", "https://www.bataclan.fr/");

		public static Venue Columbia = new(NextId, "Columbia Theatre", "columbia-berlin", "Columbiadamm 9 - 11", "Berlin", "de-DE", "10965",
			"+49 30 69817584", "https://columbia-theater.de/");

		public static Venue Gagarin = new(NextId, "Gagarin 205", "gagarin-athens", "Liosion 205", "Athens", "el-GR", "104 45",
			"+45 35 35 50 69", "");

		public static Venue JohnDee = new(NextId, "John Dee Live Club & Pub", "john-dee-oslo", "Torggata 16", "Oslo", "nn-NO", "0181",
			"+47 22 20 32 32", "https://www.rockefeller.no/");

		public static Venue Stengade = new(NextId, "Stengade", "stengade-copenhagen", "Stengade 18", "Copenhagen", "da-DK", "2200",
			"+45 35355069", "https://www.stengade.dk");

		public static Venue Barracuda = new(NextId, "Barracuda", "barracuda-porto", "R da Madeira 186", "Porto", "pt-PT", "4000-433", null,
			"https://www.instagram.com/barracuda_clube_de_roque");

		public static Venue PubAnchor = new(NextId, "Pub Anchor", "pub-anchor-stockholm", "Sveavägen 90", "Stockholm", "sv-SE", "113 59",
			"+46 8 15 20 00", "https://www.instagram.com/pubanchor/?hl=en");

		public static Venue NewCrossInn = new(NextId, "New Cross Inn", "new-cross-inn-london", "323 New Cross Road", "London", "en-GB", "SE14 6AS",
			"+44 20 8469 4382", "https://www.newcrossinn.com/");

		public static Venue[] AllVenues => [
			Electric,
			Bataclan,
			Columbia,
			Gagarin,
			JohnDee,
			Stengade,
			Barracuda,
			PubAnchor,
			NewCrossInn
		];
	}
}