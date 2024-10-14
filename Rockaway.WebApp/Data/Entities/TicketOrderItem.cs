namespace Rockaway.WebApp.Data.Entities;

public class TicketOrderItem {

	public TicketOrder TicketOrder { get; set; } = default!;

	public TicketType TicketType { get; set; } = default!;

	public int Quantity { get; set; }
}
