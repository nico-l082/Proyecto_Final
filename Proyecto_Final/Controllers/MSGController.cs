using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Proyecto_Final.Models;
using Proyecto_Final.Servicios;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
[Route("api/emails")]
[ApiController]
public class MSGController : Controller
{
    private readonly IServicioEmail servicioEmail;

    public MSGController(IServicioEmail servicioEmail)
    {
        this.servicioEmail = servicioEmail;
    }

    [HttpPost]
    public async Task<ActionResult> Enviar(string email, string tema, string cuerpo)
    {
        await servicioEmail.EnviarEmail(email, tema, cuerpo);
        return Ok();
    }
}
