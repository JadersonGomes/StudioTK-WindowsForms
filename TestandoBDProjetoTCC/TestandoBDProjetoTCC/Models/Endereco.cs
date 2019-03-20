using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestandoBDProjetoTCC.Models
{
    [Table("Endereco")]
    public class Endereco
    {
        [Key]
        public string Cep { get; set; }

        [MaxLength(3)]
        public char Estado { get; set; }

        [MaxLength(50)]
        public string CidadeBO { get; set; }

        public string Bairro { get; set; }

        public string Logradouro { get; set; }

        public int Numero { get; set; }

        public virtual IList<CrimeCadastrado> CrimesCadastrados { get; set; }

        public virtual IList<CrimeSSP> CrimesSSP { get; set; }
    }
}