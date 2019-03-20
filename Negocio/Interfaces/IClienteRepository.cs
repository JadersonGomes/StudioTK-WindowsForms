using AcessoBancoDados.Models;
using System.Collections.Generic;

namespace Negocio.Interfaces
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        IEnumerable<Cliente> ListarPorNome(string nomeCliente);
        IEnumerable<Cliente> ListarPorTelefone(string telefone);
        List<Cliente> PopulaDataGrid();

    }
}
