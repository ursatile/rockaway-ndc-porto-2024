using Rockaway.WebApp.Data.Entities;

namespace Rockaway.WebApp.Models;

public class TicketOrderItemViewData(TicketOrderItem item) {
	public string Description { get; } = $"{item.Quantity} x {item.TicketType.Name}";
	public string UnitPrice { get; } = item.TicketType.FormattedPrice;
	public string TotalPrice { get; } = $"{item.TicketType.FormatPrice(item.Quantity)}";
}
