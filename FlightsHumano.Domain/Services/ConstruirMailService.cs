using FlightsHumano.Domain.Entities;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace FlightsHumano.Domain.Services
{
    [DomainService]
    public class ConstruirMailService
    {
        private readonly IConfiguration _configuration;

        public ConstruirMailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<string> ConstruirCorreo(Outbox outbox)
        {

            var templatePath= _configuration["TemplateMail:Path"].ToString();
            var tipoMail = outbox.TipoOutbox + ".html";
            
            string filePath = Path.Combine(templatePath, tipoMail);
                        
            string htmlContent = File.ReadAllText(filePath);            

            
            htmlContent = htmlContent.Replace("{{NombreUsuario}}", outbox.Name); 
            htmlContent = htmlContent.Replace("{{IdReserva}}", outbox.IdReserva.ToString());
            htmlContent = htmlContent.Replace("{{FechaSalida}}", outbox.FechaSalida.ToString());
            htmlContent = htmlContent.Replace("{{Origen}}", outbox.Origen);
            htmlContent = htmlContent.Replace("{{Destino}}", outbox.Destino);
            htmlContent = htmlContent.Replace("{{NumeroAsiento}}", outbox.NumeroAsiento.ToString());

            return htmlContent;
        }
    }
}
