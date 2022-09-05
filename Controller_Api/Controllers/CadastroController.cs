using Microsoft.AspNetCore.Mvc;
using ApiBanco.Repository;
using ApiBanco.Core.Services;

namespace ApiBanco.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CadastroController : ControllerBase
    {
        public List<Cadastro> CadastrosLista { get; set; }

        public CadastroRepository _repositoryCadastro;

        public CadastroController(IConfiguration configuration)
        {
            CadastrosLista = new List<Cadastro>();
            _repositoryCadastro = new CadastroRepository(configuration);
        }

        //https://localhost:7214/Cadastro/buscar-todos-cadastros
        [HttpGet("buscar-todos-cadastros")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<Cadastro> GetTodosCadastros()
        {
            var clientes = _repositoryCadastro.GetTodosCadastros();
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
        public ActionResult<Cadastro> GetCadastrosClientes(string cpf)
        {
            var cliente = _repositoryCadastro.GetCadastrosClientes(cpf);
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
        public ActionResult<Cadastro> InsertCadastroCliente(Cadastro cliente)
        {
            var clientes = _repositoryCadastro.InsertCadastroCliente(cliente);
            if (clientes == null)
            {
                return BadRequest("Cadastro não válido, confira as informações e tente novamente.");
            }
            CadastrosLista.Add(cliente);
            return CreatedAtAction(nameof(InsertCadastroCliente), cliente);
        }

        //https://localhost:7214/Cadastro/alterar-cadastro/1
        [HttpPut("alterar-cadastro/{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        public ActionResult<Cadastro> UpdateCadastroCliente(long id, Cadastro cliente)
        {
            if(_repositoryCadastro.UpdateCadastroCliente(id, cliente))
            {
                return Accepted(cliente);
            }
            return BadRequest("Não foi possível alterar o cadastro.");

        }

        //https://localhost:7214/Cadastro/deletar-cadastro/4
        [HttpDelete("deletar-cadastro/{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<Cadastro> DeleteCadastroCliente(int id)
        {
            if(_repositoryCadastro.DeleteCadastroCliente(id))
            {
                return Ok();
            }
            return Unauthorized("Não foi possível deletar o cadastro.");
        }
    }
}