using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiBanco.Core.Interfaces
{
    public interface ITokenService
    {
        string GenerateTokenProdutos(string nome, string permissao);

    }
}
