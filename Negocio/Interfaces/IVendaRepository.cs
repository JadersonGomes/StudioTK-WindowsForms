using AcessoBancoDados.Models;
using System;
using System.Collections.Generic;

namespace Negocio.Interfaces
{
    public interface IVendaRepository: IRepository<Venda>
    {

        IList<Venda> ListarPorData(string data);
        IEnumerable<Venda> ListarPorIntervaloPeriodo(string dataInicial, string dataFinal);
        IEnumerable<Venda> ListarPorFuncionario(string funcionario);
        IEnumerable<Venda> ListAllVendas();
        dynamic RecuperaProdutosVendidosPorData(DateTime dataInicial, DateTime dataFinal);
    }
}
