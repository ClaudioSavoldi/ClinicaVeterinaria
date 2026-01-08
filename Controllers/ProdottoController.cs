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
    public class ProdottoController : ControllerBase
    {
        private readonly ProdottoService _prodottoService;

        public ProdottoController(ProdottoService prodottoService)
        {
            _prodottoService = prodottoService;
        }

        [HttpGet("GetAllProdotti")]
        public async Task<IActionResult> GetAllProdotti()
        {
            var prodotti = await _prodottoService.GetAllProdotti();

            if (prodotti == null)
            {
                return NotFound();
            }

            return Ok(prodotti);
        }


        [HttpGet("GetPosizioneProdotto")]
        public async Task<IActionResult> GetPosizioneProdotto(string prodottoRicercato)
        {
            var prodotto = await _prodottoService.GetPosizioneProdotto(prodottoRicercato);

            if (prodotto == null)
            {
                return NotFound();
            }

            return Ok(prodotto);
        }

        [HttpPost("createProdotto")]
        public async Task<IActionResult> CreateProdotto(RequestProdottoDto prodotto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var IsCreated = await _prodottoService.CreateProdotto(prodotto);

            if (IsCreated)
            {
                return Ok(new { Message = "Prodotto registrato con successo" });
            }
            else
            {
                return BadRequest(new { Message = "Errore durante la registrazione" });
            }

        }

    }
}
