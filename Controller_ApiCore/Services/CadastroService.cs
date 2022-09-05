using ApiBanco.Core.Interfaces;

namespace ApiBanco.Core.Services
{
    public class CadastroService : ICadastroService
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

        public Cadastro ConsultarCadastroCliente(string cpf)
        {
            return _cadastroRepository.ConsultarCadastroCliente(cpf);
        }

        public bool InserirCadastroCliente(Cadastro cadastro)
        {
            return _cadastroRepository.InserirCadastroCliente(cadastro);
        }

        public bool AtualizarCadastroCliente(long id, Cadastro cadastro)
        {
            return _cadastroRepository.AtualizarCadastroCliente(id, cadastro);
        }

        public bool DeletarCadastroCliente(long id)
        {
            return _cadastroRepository.DeletarCadastroCliente(id);
        }
    }
}