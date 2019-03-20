using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcessoBancoDados.Models
{
    [Table("Fornecedor")]
    public class Fornecedor 
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(50)]
        public string Nome { get; set; }

        public string Telefone { get; set; }

        [Required(ErrorMessage = "Campo 'E-mail' é obrigatório.")]
        [EmailAddress(ErrorMessage = "E-mail inválido.")]
        public string Email { get; set; }

        public string Especialidade { get; set; }

        public virtual Endereco Endereco { get; set; }
        public int EnderecoId { get; set; }

    }
}
