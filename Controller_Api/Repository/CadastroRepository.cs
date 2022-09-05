using Dapper;
using Microsoft.Data.SqlClient;
using ApiBanco.Core.Services;

namespace ApiBanco.Repository
{
    public class CadastroRepository
    {
        private readonly IConfiguration _configuration;

        public CadastroRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<Cadastro> GetTodosCadastros()
        {
            var query = "SELECT * FROM clientes";

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            return conn.Query<Cadastro>(query).ToList();
        }

        public Cadastro GetCadastrosClientes(string cpf)
        {
            var query = "SELECT * FROM clientes WHERE cpf = @cpf";
            var parameters = new DynamicParameters(new
            {
                cpf
            });

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            return conn.QueryFirstOrDefault<Cadastro>(query, parameters);
        }

        public bool InsertCadastroCliente(Cadastro cadastro)
        {
            var query = "INSERT INTO clientes VALUES (@cpf, @nome, @dataNascimento, @idade)";

            var parameters = new DynamicParameters();
            parameters.Add("cpf", cadastro.Cpf);
            parameters.Add("nome", cadastro.Nome);
            parameters.Add("dataNascimento", cadastro.DataNascimento);
            parameters.Add("idade", cadastro.Idade);

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            return conn.Execute(query, parameters) == 1;
        }

        public bool UpdateCadastroCliente (long id, Cadastro cadastro)
        {
            var query = "UPDATE clientes SET cpf = @cpf, nome = @nome, dataNascimento = @dataNascimento, " +
                "idade = @idade WHERE id = @id";

            var parameters = new DynamicParameters();
            parameters.Add("id", cadastro.Id);
            parameters.Add("cpf", cadastro.Cpf);
            parameters.Add("nome", cadastro.Nome);
            parameters.Add("dataNascimento", cadastro.DataNascimento);
            parameters.Add("idade", cadastro.Idade);

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            return conn.Execute(query, parameters) == 1;
        }

        public bool DeleteCadastroCliente(long id)
        {
            var query = "DELETE FROM clientes WHERE id = @id";

            var parameters = new DynamicParameters();
            parameters.Add("id", id);

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            return conn.Execute(query, parameters) == 1;
        }
    }
}
