namespace Rockaway.WebApp.Data.Entities;

public class TicketType(Guid id, Show show, string name, decimal price, int? limit = null) {

	public Guid Id { get; set; } = id;
	public Show Show { get; set; } = show;
	public string Name { get; set; } = name;
	public decimal Price { get; set; } = price;
	public int? Limit { get; set; } = limit;

	public string FormattedPrice
		=> this.Show.Venue.FormatPrice(this.Price);

	public string FormatPrice(int quantity)
		=> this.Show.Venue.FormatPrice(this.Price * quantity);

	// Private constructor required by EF Core
	private TicketType() : this(Guid.Empty, default!, default!, default) { }
}