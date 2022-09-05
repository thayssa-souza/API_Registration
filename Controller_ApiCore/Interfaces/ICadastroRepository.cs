using ApiBanco.Core.Services;

namespace ApiBanco.Core.Interfaces
{
    public interface ICadastroRepository
    {
        List<Cadastro> ConsultarCadastros();
    }
}
