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
    public class Pagamento: PagamentoRepository
    {
        public Pagamento(SalaoContext _contexto) : base(_contexto)
        {
        }

        public int Id { get; set; }
        public string NomeCliente { get; set; }
        public string NomeFuncionario { get; set; }
        public Servico ServicoRealizado { get; set; }
        public string FormaPagamento { get; set; }
        public double Valor { get; set; }        
        public DateTime DataPagamento { get; set; }
        public Produto Produto { get; set; }




    }
}
