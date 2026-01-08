using ClinicaVeterinaria.Models.DTOs.Requests;
using ClinicaVeterinaria.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicaVeterinaria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin, Veterinario")]
    public class RicoveroController : ControllerBase
    {

        private readonly RicoveroService _ricoveroService;

        public RicoveroController(RicoveroService rioveroService)
        {
            _ricoveroService = rioveroService;
        }

        [HttpGet("GetAllRicoveri")]
        public async Task<IActionResult> GetAllRicoveri()
        {
            var ricoveri = await _ricoveroService.GetAllRicoveri();

            if (ricoveri == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(ricoveri);
            }
        }

        [HttpGet("GetRicoveriAttivi")]
        public async Task<IActionResult> GetRicoveriAttivi()
        {
            var ricoveri = await _ricoveroService.GetAllRicoveriAttivi();

            if (ricoveri == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(ricoveri);
            }
        }

        [HttpGet("GetRicoveroById{id}")]
        public async Task<IActionResult> GetRicoveroById(Guid id)
        {
            var ricovero = await _ricoveroService.GetRicoveroById(id);

            if (ricovero == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(ricovero);
            }
        }


        [HttpGet("GetContabilizzazione")]
        public async Task<IActionResult> GetContabilizzazione()
        {
            var ricovero = await _ricoveroService.GetContabilizzazioneRicoveri();

            if (ricovero == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(ricovero);
            }
        }

        [AllowAnonymous]
        [HttpGet("GetAnimaleByChip")]
        public async Task<IActionResult> GetAnimaleByChip(int microChip)
        {
            var animaleChip = await _ricoveroService.GetAnimaleRicoveratoByChip(microChip);

            if (animaleChip == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(animaleChip);
            }
        }

        [HttpPost("CreateRicovero")]
        public async Task<IActionResult> CreateRicovero(RequestCreateRicoveroDto requestRicovero)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var isCreated = await _ricoveroService.CreateRicovero(requestRicovero);

            if (isCreated)
            {
                return Ok(new { Message = "Ricovero creato con successo" });
            }
            else
            {
                return BadRequest(new { Message = "Errore durante la registrazione" });
            }
        }


    }
}
