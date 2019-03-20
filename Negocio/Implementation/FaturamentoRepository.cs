using AcessoBancoDados.Models;
using Negocio.Generics;
using Negocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Negocio.Implementation
{
    public class FaturamentoRepository : AcessoDadosEntityFramework<Faturamento>, IFaturamentoRepository
    {
        public FaturamentoRepository(SalaoContext _contexto) : base(_contexto)
        {
        }


        public double SomarValorTotalPorColaborador(string colaborador)
        {
            return entidade.Where(f => f.Funcionario.Nome.Equals(colaborador)).Sum(v => v.ValorTotal);
        }

        public double SomaFaturamentoTotal(List<Faturamento> lista)
        {
            double valor = 0;

            foreach (var item in lista)
            {
                valor += item.ValorTotal;
            }

            return valor;
        }

        public List<Faturamento> ListarPorPeriodo(DateTime dataInicial, DateTime dataFinal)
        {
            return entidade.Where(f => f.Data >= dataInicial && f.Data <= dataFinal).ToList();
        }

        public List<Faturamento> ListarPorColaboradorData(string colaborador, DateTime dataInicial, DateTime dataFinal)
        {
            var listaFaturamentoPordata = ListarPorPeriodo(dataInicial, dataFinal).ToList();
            return listaFaturamentoPordata.Where(f => f.Funcionario.Equals(colaborador)).ToList();
        }

        

    }
}
