using AcessoBancoDados.Generics;
using Negocio.Implementation;
using Negocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcessoBancoDados;

namespace Negocio.Models
{
    public class Pagamento
    {        

        public int Id { get; set; }
        public string NomeCliente { get; set; }
        public string NomeFuncionario { get; set; }        
        public string FormaPagamento { get; set; }
        public double ValorTotal { get; set; }
        public double ValorRecebido { get; set; }
        public DateTime DataPagamento { get; set; }
        public virtual Venda Venda { get; set; }





    }
}
