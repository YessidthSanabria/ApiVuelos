using FlightsHumano.Domain.Ports;
using Mailjet.Client;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Threading.Tasks;
using Mailjet.Client.Resources;

namespace FlightsHumano.Domain.Services
{
    public class SendGridEmailService : IEmailService
    {
        private readonly IConfiguration _configuration;

        public SendGridEmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<MailjetResponse> SendEmailJetAsync(string toEmail, string subject, string message)
        {
            var apiKey = _configuration["MailJet:ApiKey"];
            var secretKey = _configuration["MailJet:SecretKey"];

  
            MailjetClient client = new MailjetClient(apiKey, secretKey);
              
            MailjetRequest request = new MailjetRequest
            {
                Resource = Send.Resource,
            }
            .Property(Send.FromEmail, "yessidth.sanabria@ceiba.com")
            .Property(Send.FromName, "Prueba Vuelos")
            .Property(Send.Subject, subject)
            .Property(Send.TextPart, "")
            .Property(Send.HtmlPart, message)
            .Property(Send.Recipients, new JArray {
                new JObject {
                    {"Email", toEmail}
                }
            });

            
            MailjetResponse response = await client.PostAsync(request);          

            return response;
        }


        public async Task SendEmailAsync(string toEmail, string subject, string message)
        {
            var apiKey = _configuration["SendGrid:ApiKey"];
            var client = new SendGridClient(apiKey);
            var fromEmail = new EmailAddress(_configuration["SendGrid:FromEmail"]);
            var to = new EmailAddress(toEmail);
            var msg = MailHelper.CreateSingleEmail(fromEmail, to, subject, message, message);
            var response = await client.SendEmailAsync(msg);

        }
    }
}
