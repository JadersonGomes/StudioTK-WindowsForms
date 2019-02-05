using AcessoBancoDados;
using AcessoBancoDados.Generics;
using Negocio.Interfaces;
using Negocio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Implementation
{
    public class ServicoRepository : AcessoDadosEntityFramework<Servico>, IServicoRepository
    {
        public ServicoRepository(SalaoContext _contexto) : base(_contexto)
        {
        }
    }
}
