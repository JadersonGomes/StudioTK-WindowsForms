using AcessoBancoDados.Models;
using System.Collections.Generic;

namespace Negocio.Interfaces
{
    public interface IFornecedorRepository : IRepository<Fornecedor>
    {
        IEnumerable<Fornecedor> ListarPorNome(string nomeFornecedor);
        IEnumerable<Fornecedor> ListarPorTelefone(string telefone);
        List<Fornecedor> PopulaDataGrid();

    }
}
