using AcessoBancoDados.Generics;
using Negocio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Interfaces
{
    public interface IFuncionarioRepository : IRepository<Funcionario>
    {
        IEnumerable<Funcionario> ListarPorNome(string nomeFuncionario);
        IEnumerable<Funcionario> ListarPorTelefone(string telefone);
        List<Funcionario> PopulaDataGrid();

    }
}
