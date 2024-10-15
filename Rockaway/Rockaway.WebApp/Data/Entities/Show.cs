using System.ComponentModel.DataAnnotations.Schema;

namespace Rockaway.WebApp.Data.Entities;

public class Show {

	public Venue Venue { get; set; } = default!;

	public LocalDate Date { get; set; }

	public Artist HeadlineArtist { get; set; } = default!;

	public List<SupportSlot> SupportSlots { get; set; } = [];

	public List<TicketType> TicketTypes { get; set; } = [];

	public List<TicketOrder> TicketOrders { get; set; } = [];

	public int NextSupportSlotNumber
		=> (this.SupportSlots.Count > 0 ? this.SupportSlots.Max(s => s.SlotNumber) : 0) + 1;

	public Dictionary<string, string> RouteData => new() {
		{ "venue", this.Venue.Slug },
		{ "date", this.Date.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture) }
	};

	[NotMapped]
	public IEnumerable<Artist> SupportArtists
		=> this.SupportSlots.Select(s => s.Artist);

	public TicketOrder CreateOrder(Dictionary<Guid, int> contents, Instant now) {
		var order = new TicketOrder {
			Show = this,
			CreatedAt = now
		};
		foreach (var (id, quantity) in contents) {
			var ticketType = this.TicketTypes.FirstOrDefault(tt => tt.Id == id);
			if (ticketType == default) continue;
			order.UpdateQuantity(ticketType, quantity);
		}

		this.TicketOrders.Add(order);
		return order;
	}
}