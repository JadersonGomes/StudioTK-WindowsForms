using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AcessoBancoDados.Models
{
    [Table("Caixa")]
    public class Caixa 
    {        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(15)]
        public string Status { get; set; } = "Aberto";

        [Required(ErrorMessage = "Insira a data de abertura.")]
        public DateTime dataAbertura { get; set; }

        [Required(ErrorMessage = "Insira a data de fechamento.")]
        public DateTime dataFechamento { get; set; }

        public virtual Funcionario Funcionario { get; set; }

        public int FuncionarioId { get; set; }

        public List<Movimentacao> Movimentacoes { get; set; }


    }
}
