using AcessoBancoDados.Generics;
using Negocio.Interfaces;
using Negocio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcessoBancoDados;

namespace Negocio.Implementation
{
    public class FaturamentoRepository : AcessoDadosEntityFramework<Faturamento>, IFaturamentoRepository
    {
        public FaturamentoRepository(SalaoContext _contexto) : base(_contexto)
        {
        }


        public double SomarValorTotalPorColaborador(string colaborador)
        {
            return entidade.Where(f => f.Colaborador.Nome.Equals(colaborador)).Sum(v => v.Servico.Valor);
        }

        public double SomaFaturamentoTotal(List<Faturamento> lista)
        {
            double valor = 0;

            foreach (var item in lista)
            {
                valor += item.Servico.Valor;
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
            return listaFaturamentoPordata.Where(f => f.Colaborador.Equals(colaborador)).ToList();
        }

        

    }
}
