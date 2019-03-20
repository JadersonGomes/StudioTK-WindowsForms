using AcessoBancoDados.Models;
using System.Collections.Generic;

namespace Negocio.Interfaces
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        IEnumerable<Produto> ListarPorNome(string nomeProduto);
        //IEnumerable<Produto> ListarPorFornecedor(string nomeFornecedor);
        List<Produto> PopulaDataGrid();
        

    }
}
