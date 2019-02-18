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
    }
}
