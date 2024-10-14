using System.ComponentModel;

namespace Rockaway.WebApp.Models;

public class OrderConfirmationPostData {

	public TicketOrderViewData TicketOrder { get; set; } = default!;

	[Required(ErrorMessage = "Please provide your full name")]
	[MaxLength(100, ErrorMessage = "Sorry - our database can't handle names that long. :( Max 100 characters, please.")]
	[DisplayName("Full Name")]
	[Description("Your full name")]
	public string CustomerName { get; set; } = String.Empty;

	[Required(ErrorMessage = "Please provide the email address where we'll send your tickets")]
	[EmailAddress]
	[DisplayName("Email Address")]
	[Description("Your email address")]
	public string CustomerEmail { get; set; } = String.Empty;

	public bool AgreeToPayment { get; set; }

	public Guid TicketOrderId { get; set; }
}
