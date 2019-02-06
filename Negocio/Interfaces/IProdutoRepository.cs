using AcessoBancoDados.Generics;
using Negocio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Interfaces
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        IEnumerable<Produto> ListarPorNome(string nomeProduto);
        //IEnumerable<Produto> ListarPorFornecedor(string nomeFornecedor);
        List<Produto> PopulaDataGrid();
        

    }
}
