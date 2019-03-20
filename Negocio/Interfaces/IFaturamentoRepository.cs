using AcessoBancoDados.Models;
using System;
using System.Collections.Generic;

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
