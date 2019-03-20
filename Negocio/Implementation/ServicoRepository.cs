using AcessoBancoDados.Models;
using Negocio.Generics;
using Negocio.Interfaces;

namespace Negocio.Implementation
{
    public class ServicoRepository : AcessoDadosEntityFramework<Servico>, IServicoRepository
    {
        public ServicoRepository(SalaoContext _contexto) : base(_contexto)
        {
        }
    }
}
