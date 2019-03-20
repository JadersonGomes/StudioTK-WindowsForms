using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AcessoBancoDados.Models
{
    [Table("Movimentacao")]
    public class Movimentacao 
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo 'Data' é obrigatório.")]
        public DateTime Data { get; set; }

        public double Valor { get; set; }

        [MaxLength(240)]
        public string Descricao { get; set; }

        public string FormaPagMovimentacao { get; set; }        

        public virtual TipoMovimentacao TipoMovimentacao { get; set; }

        public int TipoMovimentacaoId { get; set; }       

        public virtual Caixa Caixa { get; set; }

        public int CaixaId { get; set; }

    }
}
