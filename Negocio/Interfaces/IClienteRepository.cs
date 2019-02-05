using AcessoBancoDados.Generics;
using Negocio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Interfaces
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        IEnumerable<Cliente> ListarPorNome(string nomeCliente);
        IEnumerable<Cliente> ListarPorTelefone(string telefone);
        List<Cliente> PopulaDataGrid();

    }
}
