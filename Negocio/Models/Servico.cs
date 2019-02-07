using AcessoBancoDados;
using Negocio.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Models
{
    public class Servico : ServicoRepository
    {
        public Servico(SalaoContext _contexto) : base(_contexto)
        {
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public double Valor { get; set; }
        public Cliente Cliente { get; set; }        
        public string Hora { get; set; }
        public DateTime Data { get; set; }
        public Funcionario Funcionario { get; set; }

        public override string ToString()
        {
            return this.Nome;
        }

    }
}
