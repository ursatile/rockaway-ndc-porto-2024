namespace Rockaway.WebApp.Data.Entities;

public class TicketOrder {
	public Guid Id { get; set; }
	public Show Show { get; set; } = default!;
	public List<TicketOrderItem> Contents { get; set; } = [];
	public string CustomerName { get; set; } = String.Empty;
	public string CustomerEmail { get; set; } = String.Empty;
	public Instant CreatedAt { get; set; }
	public Instant? CompletedAt { get; set; }

	public string FormattedTotalPrice
		=> Show.Venue.FormatPrice(Contents.Sum(item => item.TicketType.Price * item.Quantity));

	public string Reference => Id.ToString("D")[..8].ToUpperInvariant();

	public TicketOrderItem UpdateQuantity(TicketType ticketType, int quantity) {
		var item = this.Contents.FirstOrDefault(toi => toi.TicketType == ticketType);
		if (item == default) {
			item = new() { TicketOrder = this, TicketType = ticketType };
			this.Contents.Add(item);
		}
		item.Quantity = quantity;
		return item;
	}
}