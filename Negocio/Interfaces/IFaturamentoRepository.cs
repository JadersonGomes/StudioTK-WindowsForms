using AcessoBancoDados.Generics;
using Negocio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Interfaces
{
    public interface IFaturamentoRepository : IRepository<Faturamento>
    {
        double SomarValorTotalPorColaborador(string colaborador);
        List<Faturamento> ListarPorPeriodo(DateTime dataInicial, DateTime dataFinal);
        List<Faturamento> ListarPorColaboradorData(string colaborador, DateTime dataInicial, DateTime dataFinal);
        double SomaFaturamentoTotal(List<Faturamento> lista);

    }
}
