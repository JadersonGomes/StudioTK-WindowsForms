using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace AcessoBancoDados.Models
{
    [Table("Faturamento")]
    public class Faturamento 
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }        

        [Required(ErrorMessage = "Campo 'Data' é obrigatório.")]
        public DateTime Data { get; set; }        

        public double ValorTotal { get; set; }

        public virtual Funcionario Funcionario { get; set; }

        public int FuncionarioId { get; set; }

    }
}
