namespace Rockaway.WebApp.Data.Entities;

public class Artist {
	public Guid Id { get; set; }
	[MaxLength(100)]
	public string Name { get; set; } = String.Empty;
	[MaxLength(500)]
	public string Description { get; set; } = String.Empty;

	[MaxLength(100)]
	[Unicode(false)]
	public string Slug { get; set; } = String.Empty;

	public Artist() { }

	public Artist(Guid id, string name, string description, string slug) {
		this.Id = id;
		this.Name = name;
		this.Description = description;
		this.Slug = slug;
	}

	public List<Show> HeadlineShows { get; set; } = [];
}