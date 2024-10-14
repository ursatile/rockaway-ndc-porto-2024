using Rockaway.WebApp.Data.Entities;

namespace Rockaway.WebApp.Models;

public class TicketOrderViewData(TicketOrder ticketOrder) {
	public string Headliner { get; } = ticketOrder.Show.HeadlineArtist.Name;
	public string VenueSummary { get; } = ticketOrder.Show.Venue.Summary;
	public string VenueName { get; } = ticketOrder.Show.Venue.Name;
	public LocalDate Date { get; } = ticketOrder.Show.Date;
	public bool HasSupport { get; } = ticketOrder.Show.SupportSlots.Count > 0;
	public string CustomerName { get; } = ticketOrder.CustomerName;
	public string CustomerEmail { get; } = ticketOrder.CustomerEmail;
	public Instant? OrderCompletedAt { get; } = ticketOrder.CompletedAt;
	public ArtistViewData Artist { get; } = new(ticketOrder.Show.HeadlineArtist);
	public string Reference { get; } = ticketOrder.Reference;

	public string SupportArtistsText { get; }
		= String.Join(" + ", ticketOrder.Show.SupportArtists.Select(a => a.Name));

	public IEnumerable<TicketOrderItemViewData> Contents { get; }
		= ticketOrder.Contents.Select(item => new TicketOrderItemViewData(item));

	public string FormattedTotalPrice { get; } = ticketOrder.FormattedTotalPrice;
}