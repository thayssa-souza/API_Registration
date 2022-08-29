using Microsoft.AspNetCore.Mvc;

namespace Controller_Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CadastroController : ControllerBase
    {
        public List<Cadastro> cadastros = new()
        {
            new Cadastro("95896994052", "Buzz", Convert.ToDateTime("2000/05/10"), 22),
            new Cadastro("85503201027", "Woody", Convert.ToDateTime("1996/06/04"), 26),
            new Cadastro("29062467008", "Jessie", Convert.ToDateTime("1999/12/10"), 22),
            new Cadastro("34659205037", "Rex", Convert.ToDateTime("2001/03/27"), 21),
            new Cadastro("44288043000", "Andy", Convert.ToDateTime("2010/02/04"), 12),
        };

        private readonly ILogger<CadastroController> _logger;
        public List<Cadastro> cadastroPessoa = new();

        public CadastroController(ILogger<CadastroController> logger)
        {
            _logger = logger;
            cadastros = cadastros.Select(cadastroPessoa => new Cadastro
            {
                Cpf = cadastroPessoa.Cpf,
                Nome = cadastroPessoa.Nome,
                DataNascimento = cadastroPessoa.DataNascimento,
                Idade = cadastroPessoa.Idade,
            })
            .ToList();
        }

        //https://localhost:7214/Cadastro
        [HttpGet]
        public ActionResult<Cadastro> Get()
        {
            return Created(nameof(Get), cadastros);
        }

        //https://localhost:7214/Cadastro
        [HttpPost]
        public ActionResult<Cadastro> Post(Cadastro novoCadastro)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(cadastros);
            }
            cadastros.Add(novoCadastro);
            return CreatedAtAction(nameof(Post), cadastros);
        }

        //https://localhost:7214/Cadastro?index=2
        [HttpPut]
        public ActionResult<Cadastro> Put(int index, Cadastro novoCadastro)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest((cadastros));
            }
            cadastros[index] = novoCadastro;
            return Accepted(cadastros);
        }

        //https://localhost:7214/Cadastro?index=1
        [HttpDelete]
        public ActionResult<Cadastro> Delete(int index)
        {
            if(!ModelState.IsValid)
            {
                return Unauthorized(cadastros);
            }
            cadastros.RemoveAt(index);
            return Ok(cadastros);
        }
    }
}