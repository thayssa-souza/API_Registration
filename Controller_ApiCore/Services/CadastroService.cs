using ApiBanco.Core.Interfaces;

namespace ApiBanco.Core.Services
{
    public class CadastroService
    {
        public ICadastroRepository _cadastroRepository;
        public CadastroService(ICadastroRepository cadastroRepository)
        {//toda vez que criarmos o cadastro service for iniciado, vai inicializar a nossa interface
         //para isso, falamos receba a interface e a alimente sempre que for inicializar \/
            _cadastroRepository = cadastroRepository;
        }

        public List<Cadastro> ConsultarCadastros()
        {
            return _cadastroRepository.ConsultarCadastros();
        }
    }
}