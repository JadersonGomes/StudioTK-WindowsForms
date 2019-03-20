using System.ComponentModel.DataAnnotations.Schema;

namespace TestandoBDProjetoTCC.Models
{
    [Table("VitimaCrimeCadastrado")]
    public class VitimaCrimeCadastrado
    {
        public int VitimaId { get; set; }
        public Vitima Vitima { get; set; }
        public int CrimeCadastradoId { get; set; }
        public CrimeCadastrado CrimeCadastrado { get; set; }

    }
}