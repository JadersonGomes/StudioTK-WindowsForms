using AcessoBancoDados.Models;
using Negocio.Generics;
using Negocio.Interfaces;

namespace Negocio.Implementation
{
    public class FuncionarioServicoRepository : AcessoDadosEntityFramework<FuncionarioServico>, IFuncionarioServicoRepository
    {
        public FuncionarioServicoRepository(SalaoContext _contexto) : base(_contexto)
        {
        }

        
    }
}
