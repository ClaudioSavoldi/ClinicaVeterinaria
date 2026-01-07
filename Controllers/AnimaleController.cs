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
    public class AnimaleController : ControllerBase
    {

        private readonly AnimaliService _animaliService;

        public AnimaleController(AnimaliService animaliService)
        {
            _animaliService = animaliService;
        }

        [HttpGet("GetAllAnimali")]
        public async Task<IActionResult> GetAllAnimali()
        {
            var animali = await _animaliService.GetAllAnimals();

            if (animali == null)
            {
                return NotFound();
            }

            return Ok(animali);
        }


        [HttpGet("ListaVisiteByAnimaleId{id}")]
        public async Task<IActionResult> GetVisite(Guid id)
        {
            var animale = await _animaliService.GetAllVisiteByAnimaleId(id);

            if (animale == null)
            {
                return NotFound();
            }

            return Ok(animale);
        }

        [HttpPost("createAnimale")]
        public async Task<IActionResult> CreateAnimale(AnimaleRequestDto animale)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var IsCreated = await _animaliService.CreateAnimale(animale);

            if (IsCreated)
            {
                return Ok(new { Message = "Animale registrato con successo" });
            }
            else
            {
                return BadRequest(new { Message = "Errore durante la registrazione" });
            }

        }




    }
}
