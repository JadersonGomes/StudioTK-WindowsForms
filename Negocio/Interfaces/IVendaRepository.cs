using AcessoBancoDados.Generics;
using Negocio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Interfaces
{
    public interface IVendaRepository: IRepository<Venda>
    {

        IEnumerable<Venda> ListarPorData(string data);
        IEnumerable<Venda> ListarPorIntervaloPeriodo(string dataInicial, string dataFinal);
        IEnumerable<Venda> ListarPorFuncionario(string funcionario);
        IEnumerable<Venda> ListAllVendas();
    }
}
