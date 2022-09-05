using ApiBanco.Core.Services;

namespace ApiBanco.Core.Interfaces
{
    public interface ICadastroService
    {
        List<Cadastro> ConsultarCadastros();
        Cadastro ConsultarCadastroCliente(string cpf);
        bool InserirCadastroCliente(Cadastro cadastro);
        bool AtualizarCadastroCliente(long id, Cadastro cadastro);
        bool DeletarCadastroCliente(long id);
    }
}
