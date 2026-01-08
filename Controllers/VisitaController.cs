using ClinicaVeterinaria.Models.DTOs.Requests;
using ClinicaVeterinaria.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicaVeterinaria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin, Veterinario, Farmacista")]
    public class VisitaController : ControllerBase
    {

        private readonly VisitaService _visitaService;

        public VisitaController(VisitaService visitaService)
        {
            _visitaService = visitaService;
        }

        [HttpGet("GetAllVisite")]
        public async Task<IActionResult> GetAllVisite()
        {
            var visite = await _visitaService.GetAllVisite();

            if (visite == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(visite);
            }
        }


        [HttpPost("CreateVisita")]
        public async Task<IActionResult> CreateVisita(RequestVisitaDto requestVisita)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var isCreated = await _visitaService.CreateVisita(requestVisita);

            if (isCreated)
            {
                return Ok(new { Message = "Visita creata con successo" });
            }
            else
            {
                return BadRequest(new { Message = "Errore durante la registrazione" });
            }
        }

    }
}
