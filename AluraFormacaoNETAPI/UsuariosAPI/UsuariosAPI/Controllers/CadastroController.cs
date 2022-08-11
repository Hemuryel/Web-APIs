using Microsoft.AspNetCore.Mvc;
using FluentResults;
using UsuariosAPI.Data.Dtos;
using UsuariosAPI.Services;
using UsuariosAPI.Interfaces;
using UsuariosAPI.Data.Requests;

namespace UsuariosAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CadastroController : ControllerBase
    {
        private ICadastroService _cadastroService;

        public CadastroController(ICadastroService cadastroService)
        {
            _cadastroService = cadastroService;
        }

        [HttpPost("/cadastrar")]
        public IActionResult CadastrarUsuario(CreateUsuarioDto createDto)
        {
            Result resultado = _cadastroService.CadastrarUsuario(createDto);
            if (resultado.IsFailed) return StatusCode(500);
            return Ok(resultado.Successes);
        }

        [HttpGet("/ativar")]
        public IActionResult AtivarContaUsuario([FromQuery] AtivarContaRequest request)
        //public IActionResult AtivarContaUsuario(AtivarContaRequest request)
        {
            Result resultado = _cadastroService.AtivarContaUsuario(request);
            if (resultado.IsFailed) return StatusCode(500);
            return Ok(resultado.Successes);
        }
    }
}
