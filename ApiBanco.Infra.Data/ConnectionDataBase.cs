using ApiBanco.Core.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace ApiBanco.Infra.Data
{
        public class ConnectionDataBase : IConnectionDataBase
        {
            private readonly IConfiguration _configuration;

            public ConnectionDataBase(IConfiguration configuration)
            {
                _configuration = configuration;
            }

            public IDbConnection CreateConnection()
            {
                return new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            }

        }
}