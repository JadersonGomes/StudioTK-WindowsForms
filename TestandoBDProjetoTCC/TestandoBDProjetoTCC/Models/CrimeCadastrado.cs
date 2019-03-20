using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestandoBDProjetoTCC.Models
{
    [Table("CrimeCadastrado")]
    public class CrimeCadastrado
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Insira uma descrição referente ao Crime.")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O campo 'Data' é obrigatório.")]
        public DateTime Data { get; set; }

        [StringLength(15)]
        public string Periodo { get; set; }

        public virtual IList<VitimaCrimeCadastrado> Vitimas { get; set; }
       
        public int TipoCrimeId { get; set; }

        [Required(ErrorMessage = "Escolha um Tipo de Crime.")]
        public virtual TipoCrime TipoCrime { get; set; }

        public int EnderecoId { get; set; }

        [Required(ErrorMessage = "O CEP é obrigatório.")]
        public virtual Endereco Endereco { get; set; }

    }
}