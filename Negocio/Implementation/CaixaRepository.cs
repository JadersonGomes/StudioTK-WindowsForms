using Negocio.Interfaces;
using System;
using System.Linq;
using Negocio.Generics;
using AcessoBancoDados.Models;
using System.Collections.Generic;

namespace Negocio.Implementation
{
    public class CaixaRepository : AcessoDadosEntityFramework<Caixa>, ICaixaRepository
    {
        public CaixaRepository(SalaoContext _contexto) : base(_contexto)
        {
        }

        public IList<Caixa> BuscarPorPeriodo(DateTime dataInicial, DateTime dataFinal)
        {
            var lista = ListarTodos().Where(c => c.dataFechamento >= dataInicial && c.dataFechamento <= dataFinal).OrderBy(c => c.dataFechamento).ToList();

            var listaPersonalizada = (from list in lista
                                      select new Caixa
                                      {
                                          Id = list.Id,
                                          Status = list.Status,
                                          dataAbertura = list.dataAbertura,
                                          dataFechamento = list.dataFechamento,
                                          Movimentacoes = list.Movimentacoes

                                      }).ToList();

            return listaPersonalizada;
        }

        public DateTime BuscarUltimoFechamento()
        {
            Caixa ultimoFechamento = entidade.ToList().LastOrDefault();
            return ultimoFechamento.dataFechamento;
        }

        public IList<Caixa> ListarTodosOrdenados()
        {
            var lista = ListarTodos().OrderBy(c => c.dataFechamento).ToList();

            var listaPersonalizada = (from list in lista
                                      select new Caixa
                                      {
                                          Id = list.Id,
                                          Status = list.Status,
                                          dataAbertura = list.dataAbertura,
                                          dataFechamento = list.dataFechamento,
                                          Movimentacoes = list.Movimentacoes

                                      }).ToList();

            return listaPersonalizada;                                    

        }
    }
}
