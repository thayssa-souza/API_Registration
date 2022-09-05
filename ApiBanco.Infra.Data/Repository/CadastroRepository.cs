using Dapper;
using ApiBanco.Core.Services;
using ApiBanco.Core.Interfaces;

namespace ApiBanco.Infra.Data.Repository
{
    public class CadastroRepository : ICadastroRepository
    {
        private readonly IConnectionDataBase _dataBase;

        public CadastroRepository(IConnectionDataBase dataBase)
        {
            _dataBase = dataBase;
        }

        public List<Cadastro> ConsultarCadastros()
        {
            var query = "SELECT * FROM clientes";

            using var conn = _dataBase.CreateConnection();
            return conn.Query<Cadastro>(query).ToList();
        }

        public Cadastro ConsultarCadastroCliente(string cpf)
        {
            var query = "SELECT * FROM clientes WHERE cpf = @cpf";
            var parameters = new DynamicParameters(new
            {
                cpf
            });

            using var conn = _dataBase.CreateConnection();
            return conn.QueryFirstOrDefault<Cadastro>(query, parameters);
        }

        public bool InserirCadastroCliente(Cadastro cadastro)
        {
            var query = "INSERT INTO clientes VALUES (@cpf, @nome, @dataNascimento, @idade)";

            var parameters = new DynamicParameters();
            parameters.Add("cpf", cadastro.Cpf);
            parameters.Add("nome", cadastro.Nome);
            parameters.Add("dataNascimento", cadastro.DataNascimento);
            parameters.Add("idade", cadastro.Idade);

            using var conn = _dataBase.CreateConnection();
            return conn.Execute(query, parameters) == 1;
        }

        public bool AtualizarCadastroCliente(long id, Cadastro cadastro)
        {
            var query = "UPDATE clientes SET cpf = @cpf, nome = @nome, dataNascimento = @dataNascimento, " +
                "idade = @idade WHERE id = @id";

            var parameters = new DynamicParameters();
            parameters.Add("id", cadastro.Id);
            parameters.Add("cpf", cadastro.Cpf);
            parameters.Add("nome", cadastro.Nome);
            parameters.Add("dataNascimento", cadastro.DataNascimento);
            parameters.Add("idade", cadastro.Idade);

            using var conn = _dataBase.CreateConnection();
            return conn.Execute(query, parameters) == 1;
        }

        public bool DeletarCadastroCliente(long id)
        {
            var query = "DELETE FROM clientes WHERE id = @id";

            var parameters = new DynamicParameters();
            parameters.Add("id", id);

            using var conn = _dataBase.CreateConnection();
            return conn.Execute(query, parameters) == 1;
        }
    }
}
