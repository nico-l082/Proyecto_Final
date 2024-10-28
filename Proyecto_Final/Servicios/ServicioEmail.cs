using System.Configuration;
using System.Net;
using System.Net.Mail;

namespace Proyecto_Final.Servicios
{
    public interface IServicioEmail
    {
        Task EnviarEmail(string emailReceptor, string tema, string cuerpo);
    }



    public class ServicioEmail : IServicioEmail
    {
        private readonly IConfiguration _configuration;

        public ServicioEmail(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        public async Task EnviarEmail(string emailReceptor, string tema, string cuerpo)
        {
           
            var emailEmisor = _configuration.GetValue <string>("CONFIGURACIONES_EMAIL:EMAIL");
            var password = _configuration.GetValue <string>("CONFIGURACIONES_EMAIL:PASSWORD");
            var host = _configuration.GetValue <string>("CONFIGURACIONES_EMAIL:HOST");
            var puerto = _configuration.GetValue <int>("CONFIGURACIONES_EMAIL:PUERTO");

            
            if (string.IsNullOrWhiteSpace(emailEmisor))
            {
                throw new ArgumentNullException(nameof(emailEmisor), "El email del emisor no puede ser nulo o vacío.");
            }

            if (string.IsNullOrWhiteSpace(emailReceptor))
            {
                throw new ArgumentNullException(nameof(emailReceptor), "El email del receptor no puede ser nulo o vacío.");
            }

            if (string.IsNullOrWhiteSpace(tema))
            {
                throw new ArgumentNullException(nameof(tema), "El tema no puede ser nulo o vacío.");
            }

            if (string.IsNullOrWhiteSpace(cuerpo))
            {
                throw new ArgumentNullException(nameof(cuerpo), "El cuerpo del mensaje no puede ser nulo o vacío.");
            }

           
            var smtpCliente = new SmtpClient(host, puerto)
            {
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(emailEmisor, password)
            };

            var mensaje = new MailMessage(emailEmisor, emailReceptor, tema, cuerpo)
            {
                IsBodyHtml = true
            };

          
            await smtpCliente.SendMailAsync(mensaje);
        }
    }
}
