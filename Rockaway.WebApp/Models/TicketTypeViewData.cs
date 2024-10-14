using Rockaway.WebApp.Data.Entities;

namespace Rockaway.WebApp.Models;

public class TicketTypeViewData {

	// Razor Components use System.Text.Json serialization
	// and so require a public parameterless constructor
	public TicketTypeViewData() { }

	public TicketTypeViewData(TicketType tt) {
		this.Id = tt.Id;
		this.Name = tt.Name;
		this.Price = tt.Price;
		this.FormattedPrice = tt.Show.Venue.FormatPrice(this.Price);
	}

	public Guid Id { get; set; }
	public string Name { get; set; } = "???";
	public decimal Price { get; set; }
	public string FormattedPrice { get; set; } = "???";
}
