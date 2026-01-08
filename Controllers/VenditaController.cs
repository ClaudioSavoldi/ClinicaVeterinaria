using ClinicaVeterinaria.Models.DTOs.Requests;
using ClinicaVeterinaria.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicaVeterinaria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin, Farmacista")]
    public class VenditaController : ControllerBase
    {
        private readonly VenditaService _venditaService;

        public VenditaController(VenditaService venditaService)
        {
            _venditaService = venditaService;
        }

        [HttpGet("GetAllVendite")]
        public async Task<IActionResult> GetAllVendite()
        {
            var vendite = await _venditaService.GetAllVendite();

            if (vendite == null)
            {
                return NotFound();
            }

            return Ok(vendite);
        }


        [HttpGet("GetVenditeByData")]
        public async Task<IActionResult> GetVenditeByData(DateOnly dataRicercata)
        {
            var vendite = await _venditaService.GetVenditePerData(dataRicercata);

            if (vendite == null)
            {
                return NotFound();
            }

            return Ok(vendite);
        }


        [HttpGet("GetVenditeByCodiceFiscale")]
        public async Task<IActionResult> GetVenditeByCodiceFiscale(string codiceFiscaleRicercato)
        {
            var vendite = await _venditaService.GetVenditePerCodiceFiscale(codiceFiscaleRicercato);

            if (vendite == null)
            {
                return NotFound();
            }

            return Ok(vendite);
        }



        [HttpPost("createVendita")]
        public async Task<IActionResult> CreateVendita(RequestVenditaDto vendita)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var IsCreated = await _venditaService.CreateVendita(vendita);

            if (IsCreated)
            {
                return Ok(new { Message = "Vendita registrata con successo" });
            }
            else
            {
                return BadRequest(new { Message = "Errore durante la registrazione" });
            }

        }



    }
}
