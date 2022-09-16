using ApiBanco.Core.Interfaces;
using ApiBanco.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Controller_Api.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class TokenController : ControllerBase
    {
        public ICadastroService _cadastroService;
        public ITokenService _tokenService;
        public TokenController(ICadastroService cadastroService, ITokenService tokenService)
        {
            _cadastroService = cadastroService;
            _tokenService = tokenService;
        }

        [HttpGet]
        public IActionResult CreateToken(string cpf)
        {
            var cadastro = _cadastroService.ConsultarCadastroCliente(cpf);
            if (cadastro == null)
            {
                return BadRequest();
            }

            return Ok(_tokenService.GenerateTokenProdutos(cadastro.Nome, cadastro.Permissao));
        }
    }
}
