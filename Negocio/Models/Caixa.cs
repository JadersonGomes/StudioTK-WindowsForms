using Negocio.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcessoBancoDados;

namespace Negocio.Models
{
    public class Caixa 
    {        

        public int Id { get; set; }
        public string Status { get; set; }
        public DateTime dataAbertura { get; set; }
        public DateTime dataFechamento { get; set; }
        public List<Movimentacao> Movimentacoes { get; set; }


    }
}
