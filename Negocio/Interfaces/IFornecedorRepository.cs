using AcessoBancoDados.Generics;
using Negocio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Interfaces
{
    public interface IFornecedorRepository : IRepository<Fornecedor>
    {
        IEnumerable<Fornecedor> ListarPorNome(string nomeFornecedor);
        IEnumerable<Fornecedor> ListarPorTelefone(string telefone);
        List<Fornecedor> PopulaDataGrid();

    }
}
