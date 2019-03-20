using System.Data.Entity;

namespace AcessoBancoDados.Models
{
    public class SalaoContext: DbContext
    {
        public DbSet<Agenda> Agendamento { get; set; }
        public DbSet<Caixa> Caixa { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Endereco> Endereco { get; set; }
        public DbSet<Faturamento> Faturamento { get; set; }        
        public DbSet<Fornecedor> Fornecedor { get; set; }
        public DbSet<Funcionario> Funcionario { get; set; }
        public DbSet<FuncionarioServico> FuncionarioServico { get; set; }
        public DbSet<Movimentacao> Movimentacao { get; set; }
        public DbSet<Pagamento> Pagamento { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Servico> Servico { get; set; }
        public DbSet<TipoMovimentacao> TipoMovimentacao { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Venda> Venda { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {            
            modelBuilder.Entity<FuncionarioServico>().HasKey(fs => new { fs.FuncionarioId, fs.ServicoId });
           
        }

    }
}
