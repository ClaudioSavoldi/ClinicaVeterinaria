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
    public class ProprietarioController : ControllerBase
    {

        private readonly ProprietarioService _proprietarioService;

        public ProprietarioController(ProprietarioService proprietarioService)
        {
            _proprietarioService = proprietarioService;
        }

        [HttpGet("getProprietari")]
        public async Task<IActionResult> GetAllProprietari()
        {
            var proprietari = await _proprietarioService.GetAllProprietari();

            if (proprietari == null)
            {
                return NotFound();
            }

            return Ok(proprietari);
        }

        [HttpPost("createProprietario")]
        public async Task<IActionResult> CreateProprietario(RequestProprietarioDto proprietario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var IsCreated = await _proprietarioService.CreateProprietario(proprietario);

            if (IsCreated)
            {
                return Ok(new { Message = "Proprietario registrato con successo" });
            }
            else
            {
                return BadRequest(new { Message = "Errore durante la registrazione" });
            }

        }

    }
}
