using AcessoBancoDados;
using Negocio.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Models
{
    public class Fornecedor : FornecedorRepository
    {
        public Fornecedor(SalaoContext _contexto) : base(_contexto)
        {
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Especialidade { get; set; }
        public Endereco Endereco { get; set; } 

    }
}
