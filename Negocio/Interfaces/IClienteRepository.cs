using AcessoBancoDados.Models;
using System.Collections.Generic;

namespace Negocio.Interfaces
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        IList<Cliente> ListarPorNome(string nomeCliente);
        IList<Cliente> ListarPorTelefone(string telefone);
        IList<Cliente> PopulaGrid();



    }
}
