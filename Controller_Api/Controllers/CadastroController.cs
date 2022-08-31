using Microsoft.AspNetCore.Mvc;
using Controller_Api;

namespace Controller_Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CadastroController : ControllerBase
    {
        public List<Cadastro> cadastros = new()
        {
            new Cadastro("95896994052", "Buzz", Convert.ToDateTime("2000/05/10")),
            new Cadastro("85503201027", "Woody", Convert.ToDateTime("1996/06/04")),
            new Cadastro("29062467008", "Jessie", Convert.ToDateTime("1999/12/10")),
            new Cadastro("34659205037", "Rex", Convert.ToDateTime("2001/03/27")),
            new Cadastro("44288043000", "Andy", Convert.ToDateTime("2010/02/04")),
        };

        private readonly ILogger<CadastroController> _logger;

        public CadastroController(ILogger<CadastroController> logger)
        {
            _logger = logger;
        }

        //https://localhost:7214/Cadastro/buscar-cadastro?Cpf=95896994052
        [HttpGet("buscar-cadastro")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<Cadastro> Get(string Cpf)
        {
            var pessoa = cadastros.Find(pessoa => pessoa.Cpf == Cpf);
            if (pessoa == null)
            {
                return NotFound("Lamento, CPF não cadastrado.");
            }
            return Ok(pessoa);
        }

        //https://localhost:7214/Cadastro/novo-cadastro
        [HttpPost("novo-cadastro")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult<Cadastro> Post(Cadastro novoCadastro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Cadastro não válido, confira as informações e tente novamente.");
            }
            cadastros.Add(novoCadastro);
            return CreatedAtAction(nameof(Post), cadastros);
        }

        //https://localhost:7214/Cadastro/alterar-cadastro/1
        [HttpPut("alterar-cadastro/{index}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        public ActionResult<Cadastro> Put(int index, Cadastro alteradoCadastro)
        {
            if(alteradoCadastro == null)
            {
                return BadRequest("Não foi possível alterar o cadastro.");
            }
            cadastros[index] = alteradoCadastro;
            return Accepted(cadastros);
        }

        //https://localhost:7214/Cadastro/deletar-cadastro/4
        [HttpDelete("deletar-cadastro/{index}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<Cadastro> Delete(int index)
        {
            if(!ModelState.IsValid)
            {
                return Unauthorized("Não foi possível deletar o cadastro.");
            }
            cadastros.RemoveAt(index);
            return Ok(cadastros);
        }
    }
}