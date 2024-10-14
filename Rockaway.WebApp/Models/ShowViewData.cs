using Rockaway.WebApp.Data.Entities;

namespace Rockaway.WebApp.Models;

public class ShowViewData(Show show) {

	public LocalDate ShowDate { get; } = show.Date;

	public string VenueName { get; } = show.Venue.Name;

	public string VenueAddress { get; } = show.Venue.FullAddress;

	public string HeadlineArtistName { get; } = show.HeadlineArtist.Name;

	public string CountryCode { get; } = show.Venue.CountryCode;

	public string CultureName { get; } = show.Venue.CultureName;

	public List<string> SupportActs { get; } = show.SupportSlots
			.OrderBy(s => s.SlotNumber)
			.Select(s => s.Artist.Name).ToList();

	public List<TicketTypeViewData> TicketTypes { get; }
		= show.TicketTypes.Select(tt => new TicketTypeViewData(tt)).ToList();

	public Dictionary<string, string> RouteData { get; } = show.RouteData;
}