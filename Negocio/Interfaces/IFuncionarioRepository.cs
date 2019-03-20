using AcessoBancoDados.Models;
using System.Collections.Generic;

namespace Negocio.Interfaces
{
    public interface IFuncionarioRepository : IRepository<Funcionario>
    {
        IEnumerable<Funcionario> ListarPorNome(string nomeFuncionario);
        IEnumerable<Funcionario> ListarPorTelefone(string telefone);
        List<Funcionario> PopulaDataGrid();

    }
}
