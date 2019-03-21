using AcessoBancoDados.Models;
using System.Collections.Generic;

namespace Negocio.Interfaces
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        IList<Produto> ListarPorNome(string nomeProduto);
        IList<Produto> PopulaGrid();
        
        //List<Produto> PopulaDataGrid();


    }
}
