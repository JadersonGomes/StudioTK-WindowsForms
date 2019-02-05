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
