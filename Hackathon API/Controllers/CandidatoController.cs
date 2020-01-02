using System;
using Hackathon_API.Models;
using Hackathon_API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Hackathon_API.Controllers
{
    [ApiController]
    [Route("candidatos")]
    public class CandidatosController : ControllerBase
    {
        private readonly ICandidatoService _candidatoService;

        public CandidatosController(ICandidatoService candidatoService)
        {
            _candidatoService = candidatoService;
        }

        [HttpGet]
        public IActionResult GetCandidatos()
        {
            try
            {
                return Ok(_candidatoService.GetCandidatos());
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpGet("{idCandidato}")]
        public IActionResult GetCandidato(int idCandidato)
        {
            try
            {
                return Ok(_candidatoService.GetCandidato(idCandidato));
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPost]
        public IActionResult PostCandidato([FromBody]Candidato candidato)
        {
            try
            {
                return Created("/candidatos", _candidatoService.PostCandidato(candidato));
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPut]
        public IActionResult PutCandidato()
        {
            try
            {
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpDelete("{idCandidato}")]
        public IActionResult DeleteCandidato(int idCandidato)
        {
            try
            {
                _candidatoService.DeleteCandidato(idCandidato);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}