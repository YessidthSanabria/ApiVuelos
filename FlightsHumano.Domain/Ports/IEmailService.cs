using Mailjet.Client;

namespace FlightsHumano.Domain.Ports
{
    public interface IEmailService
    {
        public Task<MailjetResponse> SendEmailJetAsync(string toEmail, string subject, string message);
        public Task SendEmailAsync(string toEmail, string subject, string message);
    }
}
