using Rockaway.WebApp.Models;

namespace Rockaway.WebApp.Services.Mail;

public interface IMailSender {
	Task<string> SendOrderConfirmationAsync(TicketOrderMailData data);
}