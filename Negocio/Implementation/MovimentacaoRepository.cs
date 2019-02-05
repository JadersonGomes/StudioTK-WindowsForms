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
    public class MovimentacaoRepository : AcessoDadosEntityFramework<Movimentacao>, IMovimentacaoRepository
    {
        public MovimentacaoRepository(SalaoContext _contexto) : base(_contexto)
        {
        }
    }
}
