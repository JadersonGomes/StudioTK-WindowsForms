namespace AcessoBancoDados.Models
{
    public class FuncionarioServico
    {
        public Funcionario Funcionario { get; set; }
        public int FuncionarioId { get; set; }
        public Servico Servico { get; set; }
        public int ServicoId { get; set; }

    }
}