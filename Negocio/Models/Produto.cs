using AcessoBancoDados;
using Negocio.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Models
{
    public class Produto 
    {
        
        public int Id { get; set; }
        public string Descricao { get; set; }
        public int Quantidade { get; set; }
        public Fornecedor Fornecedor { get; set; }
        public double Valor { get; set; }

        public override string ToString()
        {
            return this.Descricao;
        }
    }
}
