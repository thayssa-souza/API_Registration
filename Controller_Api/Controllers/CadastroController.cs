using Microsoft.AspNetCore.Mvc;
using ApiBanco.Core.Services;
using ApiBanco.Core.Interfaces;
using Controller_Api.Filters;

namespace ApiBanco.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [TypeFilter(typeof(GeneralExceptionFilters))]
    public class CadastroController : ControllerBase
    {
        public ICadastroService _cadastroService;

        public CadastroController(ICadastroService cadastroService)
        {
            _cadastroService = cadastroService;
        }

        //https://localhost:7214/Cadastro/buscar-todos-cadastros
        [HttpGet("buscar-todos-cadastros")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<Cadastro> ConsultarCadastros()
        {
            var clientes = _cadastroService.ConsultarCadastros();
            if (clientes == null)
            {
                return NotFound("Não há clientes cadastrados.");
            }
            return Ok(clientes);
        }

        //https://localhost:7214/Cadastro/buscar-cadastro?Cpf=95896994052
        [HttpGet("buscar-cadastro-cpf")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<Cadastro> ConsultarCadastroCliente(string cpf)
        {
            var cliente = _cadastroService.ConsultarCadastroCliente(cpf);
            if (cliente == null)
            {
                return NotFound("Lamento, CPF não cadastrado.");
            }
            return Ok(cliente);
        }

        //https://localhost:7214/Cadastro/novo-cadastro
        [HttpPost("novo-cadastro")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ServiceFilter(typeof(ValidateActionFilterByCpf))]
        public ActionResult<Cadastro> InserirCadastroCliente(Cadastro cliente, string cpf)
        {
            var clientes = _cadastroService.InserirCadastroCliente(cliente);
            if (!_cadastroService.InserirCadastroCliente(cliente))
            {
                return BadRequest("Cadastro não válido, confira as informações e tente novamente.");
            }
            return CreatedAtAction(nameof(InserirCadastroCliente), cliente);
        }

        //https://localhost:7214/Cadastro/alterar-cadastro/1
        [HttpPut("alterar-cadastro/{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ServiceFilter(typeof(ValidateActionFilterUpdate))]
        public ActionResult<Cadastro> AtualizarCadastroCliente(long id, Cadastro cliente)
        {
            if(_cadastroService.AtualizarCadastroCliente(id, cliente))
            {
                return Accepted(cliente);
            }
            return BadRequest("Não foi possível alterar o cadastro.");

        }

        //https://localhost:7214/Cadastro/deletar-cadastro/4
        [HttpDelete("deletar-cadastro/{id}")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ServiceFilter(typeof(ValidateActionFilterByCpf))]
        public ActionResult<Cadastro> DeletarCadastroCliente(int id)
        {
            if(_cadastroService.DeletarCadastroCliente(id))
            {
                return Ok();
            }
            return new StatusCodeResult(StatusCodes.Status500InternalServerError);
        }
    }
}