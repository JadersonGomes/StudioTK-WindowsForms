using Negocio.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcessoBancoDados;

namespace Negocio.Models
{
    public class Movimentacao : MovimentacaoRepository
    {
        public Movimentacao(SalaoContext _contexto) : base(_contexto)
        {
        }

        public int Id { get; set; }
        public DateTime Data { get; set; }
        public double Valor { get; set; }
        public string Forma { get; set; }
        public string Descricao { get; set; }
        public virtual TipoMovimentacao TipoMovimentacao { get; set; }
        public int IdTipoMovimentacao { get; set; }
        public string nomeColaborador { get; set; }
        
    }
}
