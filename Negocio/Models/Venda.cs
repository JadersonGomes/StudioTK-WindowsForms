using Negocio.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcessoBancoDados;

namespace Negocio.Models
{
    public class Venda
    {       

        public int Id { get; set; }
        public string Funcionario { get; set; }
        public DateTime Data { get; set; }
        public string Hora { get; set; }
        public bool Desconto { get; set; } = false;
        public double ValorDesconto { get; set; } = 0;
        public double ValorTotal { get; set; }
        public List<Pagamento> Pagamentos { get; set; }
        public List<Produto> Produtos { get; set; }
        public List<Servico> Servicos { get; set; }


    }
}
