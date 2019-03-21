using AcessoBancoDados.Models;
using System.Collections.Generic;

namespace Negocio.Interfaces
{
    public interface IFornecedorRepository : IRepository<Fornecedor>
    {
        IList<Fornecedor> ListarPorTelefone(string telefone);
        IList<Fornecedor> ListarPorNome(string nomeFornecedor);
        IList<Fornecedor> PopulaGrid();

        //List<Fornecedor> PopulaDataGrid();

    }
}
