using AcessoBancoDados;
using Negocio.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Models
{
    public class Funcionario 
    {
        
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }        
        public string Comissao { get; set; }
        public Endereco Endereco { get; set; }


        public override string ToString()
        {
            return this.Nome;
        }

    }
}
