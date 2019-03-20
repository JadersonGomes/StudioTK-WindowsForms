using AcessoBancoDados.Models;
using Negocio.Generics;
using Negocio.Interfaces;
using System.Linq;

namespace Negocio.Implementation
{
    public class EnderecoRepository : AcessoDadosEntityFramework<Endereco>, IEnderecoRepository
    {
        public EnderecoRepository(SalaoContext _contexto) : base(_contexto)
        {
        }


        public Endereco BuscarPorCep(string cep)
        {
            return entidade.FirstOrDefault(e => e.Cep.Equals(cep));
        }
    }
}
