namespace Rockaway.WebApp.Data.Entities;

public class SupportSlot {
	public Show Show { get; set; } = default!;
	public int SlotNumber { get; set; }
	public Artist Artist { get; set; } = default!;
}