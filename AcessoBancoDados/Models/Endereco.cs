using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcessoBancoDados.Models
{
    [Table("Endereco")]
    public class Endereco 
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo 'CEP' é obrigatório.")]
        public string Cep { get; set; }

        [MaxLength(30)]
        public string Estado { get; set; }

        [MaxLength(100)]
        public string Cidade { get; set; }

        [MaxLength(70)]
        public string Bairro { get; set; }

        [MaxLength(120)]
        public string Logradouro { get; set; }

        public int Numero { get; set; }

       

        
    }
}
