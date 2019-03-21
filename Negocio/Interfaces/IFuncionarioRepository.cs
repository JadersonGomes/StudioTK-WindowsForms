using AcessoBancoDados.Models;
using System.Collections.Generic;

namespace Negocio.Interfaces
{
    public interface IFuncionarioRepository : IRepository<Funcionario>
    {
        IList<Funcionario> ListarPorNome(string nomeFuncionario);
        IList<Funcionario> ListarPorTelefone(string telefone);
        IList<Funcionario> PopulaGrid();
        //List<Funcionario> PopulaDataGrid();

    }
}
