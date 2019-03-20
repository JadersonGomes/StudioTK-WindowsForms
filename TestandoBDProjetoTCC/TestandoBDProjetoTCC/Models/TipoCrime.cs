using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestandoBDProjetoTCC.Models
{
    [Table("TipoCrime")]
    public class TipoCrime
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        public virtual IList<CrimeSSP> CrimesSSP { get; set; }

        public virtual IList<CrimeCadastrado> CrimesCadastrados { get; set; }

    }
}