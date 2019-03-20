using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcessoBancoDados.Models
{
    [Table("TipoMovimentacao")]
    public class TipoMovimentacao
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "O tipo de movimentação é obrigatório.")]
        public string Nome { get; set; }

        public virtual List<Movimentacao> Movimentacoes { get; set; }


    }
}
