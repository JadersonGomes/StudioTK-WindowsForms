using Negocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using Negocio.Generics;
using AcessoBancoDados.Models;

namespace Negocio.Implementation
{
    public class MovimentacaoRepository : AcessoDadosEntityFramework<Movimentacao>, IMovimentacaoRepository
    {
        public MovimentacaoRepository(SalaoContext _contexto) : base(_contexto)
        {
        }

        public List<Movimentacao> ListarPorPeriodo(DateTime dataInicial, DateTime dataFinal)
        {
            return entidade.Where(m => m.Data >= dataInicial && m.Data <= dataFinal).ToList();
        }
    }
}
