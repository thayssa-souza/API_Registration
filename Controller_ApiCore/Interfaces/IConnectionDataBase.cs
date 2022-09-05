using System.Data;

namespace ApiBanco.Core.Interfaces
{
    public interface IConnectionDataBase
    {
        IDbConnection CreateConnection();
    }
}
