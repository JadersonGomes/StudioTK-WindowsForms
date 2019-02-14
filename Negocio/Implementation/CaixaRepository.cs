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
