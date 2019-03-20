using Negocio.Interfaces;
using System;
using System.Linq;
using Negocio.Generics;
using AcessoBancoDados.Models;

namespace Negocio.Implementation
{
    public class CaixaRepository : AcessoDadosEntityFramework<Caixa>, ICaixaRepository
    {
        public CaixaRepository(SalaoContext _contexto) : base(_contexto)
        {
        }


        public DateTime BuscarUltimoFechamento()
        {
            Caixa ultimoFechamento = entidade.ToList().LastOrDefault();
            return ultimoFechamento.dataFechamento;
        }
    }
}
