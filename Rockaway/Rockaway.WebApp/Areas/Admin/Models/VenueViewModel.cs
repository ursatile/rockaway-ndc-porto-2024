using Rockaway.WebApp.Data;
using Rockaway.WebApp.Data.Entities;

namespace Rockaway.WebApp.Areas.Admin.Models;

public class VenueViewModel {
	public Guid Id { get; set; }

	[MaxLength(100)]
	public string Name { get; set; } = String.Empty;

	[MaxLength(100)]
	[Unicode(false)]
	[RegularExpression("^[a-z0-9-]{2,100}$",
		ErrorMessage = "Slug must be 2-100 characters and can only contain a-z, 0-9 and the hyphen - character")]
	public string Slug { get; set; } = String.Empty;

	[MaxLength(500)]
	public string Address { get; set; } = String.Empty;

	public string City { get; set; } = String.Empty;

	public string CountryName { get; set; }

	public string? PostalCode { get; set; }

	[Phone]
	public string? Telephone { get; set; }

	[Url]
	public string? WebsiteUrl { get; set; }

	public List<ShowViewModel> Shows { get; set; } = [];

	public VenueViewModel(Venue venue) {
		Id = venue.Id;
		Name = venue.Name;
		Slug = venue.Slug;
		Address = venue.Address;
		City = venue.City;
		PostalCode = venue.PostalCode;
		Telephone = venue.Telephone;
		WebsiteUrl = venue.WebsiteUrl;
		CountryName = Country.FromCode(venue.CountryCode)?.Name ?? "(unknown)";
		Shows = venue.Shows.Select(s => new ShowViewModel(s)).ToList();
	}
}
