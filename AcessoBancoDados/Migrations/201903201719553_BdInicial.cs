namespace AcessoBancoDados.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BdInicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Agendamento",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NomeCliente = c.String(nullable: false, maxLength: 50),
                        Data = c.DateTime(nullable: false),
                        Horario = c.String(nullable: false),
                        FuncionarioId = c.Int(nullable: false),
                        ServicoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Funcionario", t => t.FuncionarioId, cascadeDelete: true)
                .ForeignKey("dbo.Servico", t => t.ServicoId, cascadeDelete: true)
                .Index(t => t.FuncionarioId)
                .Index(t => t.ServicoId);
            
            CreateTable(
                "dbo.Funcionario",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(maxLength: 30),
                        Telefone = c.String(),
                        Comissao = c.Double(nullable: false),
                        EnderecoId = c.Int(nullable: false),
                        UsuarioId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Endereco", t => t.EnderecoId, cascadeDelete: true)
                .ForeignKey("dbo.Usuario", t => t.UsuarioId, cascadeDelete: true)
                .Index(t => t.EnderecoId)
                .Index(t => t.UsuarioId);
            
            CreateTable(
                "dbo.Caixa",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Status = c.String(maxLength: 15),
                        dataAbertura = c.DateTime(nullable: false),
                        dataFechamento = c.DateTime(nullable: false),
                        FuncionarioId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Funcionario", t => t.FuncionarioId, cascadeDelete: true)
                .Index(t => t.FuncionarioId);
            
            CreateTable(
                "dbo.Movimentacao",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Data = c.DateTime(nullable: false),
                        Valor = c.Double(nullable: false),
                        Descricao = c.String(maxLength: 240),
                        FormaPagMovimentacao = c.String(),
                        TipoMovimentacaoId = c.Int(nullable: false),
                        CaixaId = c.Int(nullable: false),
                        Funcionario_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Caixa", t => t.CaixaId, cascadeDelete: true)
                .ForeignKey("dbo.TipoMovimentacao", t => t.TipoMovimentacaoId, cascadeDelete: true)
                .ForeignKey("dbo.Funcionario", t => t.Funcionario_Id)
                .Index(t => t.TipoMovimentacaoId)
                .Index(t => t.CaixaId)
                .Index(t => t.Funcionario_Id);
            
            CreateTable(
                "dbo.TipoMovimentacao",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Endereco",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Cep = c.String(nullable: false),
                        Estado = c.String(maxLength: 30),
                        Cidade = c.String(maxLength: 100),
                        Bairro = c.String(maxLength: 70),
                        Logradouro = c.String(maxLength: 120),
                        Numero = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Faturamento",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Data = c.DateTime(nullable: false),
                        ValorTotal = c.Double(nullable: false),
                        FuncionarioId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Funcionario", t => t.FuncionarioId, cascadeDelete: true)
                .Index(t => t.FuncionarioId);
            
            CreateTable(
                "dbo.FuncionarioServicoes",
                c => new
                    {
                        FuncionarioId = c.Int(nullable: false),
                        ServicoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.FuncionarioId, t.ServicoId })
                .ForeignKey("dbo.Funcionario", t => t.FuncionarioId, cascadeDelete: true)
                .ForeignKey("dbo.Servico", t => t.ServicoId, cascadeDelete: true)
                .Index(t => t.FuncionarioId)
                .Index(t => t.ServicoId);
            
            CreateTable(
                "dbo.Servico",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        Valor = c.Double(nullable: false),
                        VendaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Venda", t => t.VendaId, cascadeDelete: true)
                .Index(t => t.VendaId);
            
            CreateTable(
                "dbo.Venda",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Data = c.DateTime(nullable: false),
                        Hora = c.String(),
                        Desconto = c.Boolean(nullable: false),
                        ValorDesconto = c.Double(nullable: false),
                        ValorTotal = c.Double(nullable: false),
                        FuncionarioId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Funcionario", t => t.FuncionarioId, cascadeDelete: true)
                .Index(t => t.FuncionarioId);
            
            CreateTable(
                "dbo.Pagamento",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NomeCliente = c.String(),
                        FormaPagamento = c.String(),
                        ValorTotal = c.Double(nullable: false),
                        ValorRecebido = c.Double(nullable: false),
                        DataPagamento = c.DateTime(nullable: false),
                        VendaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Venda", t => t.VendaId, cascadeDelete: true)
                .Index(t => t.VendaId);
            
            CreateTable(
                "dbo.Produto",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descricao = c.String(maxLength: 120),
                        QntdEstoque = c.Int(nullable: false),
                        Valor = c.Double(nullable: false),
                        VendaId = c.Int(nullable: false),
                        FornecedorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Fornecedor", t => t.FornecedorId, cascadeDelete: true)
                .ForeignKey("dbo.Venda", t => t.VendaId, cascadeDelete: true)
                .Index(t => t.VendaId)
                .Index(t => t.FornecedorId);
            
            CreateTable(
                "dbo.Fornecedor",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(maxLength: 50),
                        Telefone = c.String(),
                        Email = c.String(nullable: false),
                        Especialidade = c.String(),
                        EnderecoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Endereco", t => t.EnderecoId, cascadeDelete: true)
                .Index(t => t.EnderecoId);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        nomeUsuario = c.String(nullable: false),
                        Senha = c.String(nullable: false),
                        email = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Cliente",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Telefone = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Agendamento", "ServicoId", "dbo.Servico");
            DropForeignKey("dbo.Funcionario", "UsuarioId", "dbo.Usuario");
            DropForeignKey("dbo.Servico", "VendaId", "dbo.Venda");
            DropForeignKey("dbo.Produto", "VendaId", "dbo.Venda");
            DropForeignKey("dbo.Produto", "FornecedorId", "dbo.Fornecedor");
            DropForeignKey("dbo.Fornecedor", "EnderecoId", "dbo.Endereco");
            DropForeignKey("dbo.Pagamento", "VendaId", "dbo.Venda");
            DropForeignKey("dbo.Venda", "FuncionarioId", "dbo.Funcionario");
            DropForeignKey("dbo.FuncionarioServicoes", "ServicoId", "dbo.Servico");
            DropForeignKey("dbo.FuncionarioServicoes", "FuncionarioId", "dbo.Funcionario");
            DropForeignKey("dbo.Movimentacao", "Funcionario_Id", "dbo.Funcionario");
            DropForeignKey("dbo.Faturamento", "FuncionarioId", "dbo.Funcionario");
            DropForeignKey("dbo.Funcionario", "EnderecoId", "dbo.Endereco");
            DropForeignKey("dbo.Movimentacao", "TipoMovimentacaoId", "dbo.TipoMovimentacao");
            DropForeignKey("dbo.Movimentacao", "CaixaId", "dbo.Caixa");
            DropForeignKey("dbo.Caixa", "FuncionarioId", "dbo.Funcionario");
            DropForeignKey("dbo.Agendamento", "FuncionarioId", "dbo.Funcionario");
            DropIndex("dbo.Fornecedor", new[] { "EnderecoId" });
            DropIndex("dbo.Produto", new[] { "FornecedorId" });
            DropIndex("dbo.Produto", new[] { "VendaId" });
            DropIndex("dbo.Pagamento", new[] { "VendaId" });
            DropIndex("dbo.Venda", new[] { "FuncionarioId" });
            DropIndex("dbo.Servico", new[] { "VendaId" });
            DropIndex("dbo.FuncionarioServicoes", new[] { "ServicoId" });
            DropIndex("dbo.FuncionarioServicoes", new[] { "FuncionarioId" });
            DropIndex("dbo.Faturamento", new[] { "FuncionarioId" });
            DropIndex("dbo.Movimentacao", new[] { "Funcionario_Id" });
            DropIndex("dbo.Movimentacao", new[] { "CaixaId" });
            DropIndex("dbo.Movimentacao", new[] { "TipoMovimentacaoId" });
            DropIndex("dbo.Caixa", new[] { "FuncionarioId" });
            DropIndex("dbo.Funcionario", new[] { "UsuarioId" });
            DropIndex("dbo.Funcionario", new[] { "EnderecoId" });
            DropIndex("dbo.Agendamento", new[] { "ServicoId" });
            DropIndex("dbo.Agendamento", new[] { "FuncionarioId" });
            DropTable("dbo.Cliente");
            DropTable("dbo.Usuario");
            DropTable("dbo.Fornecedor");
            DropTable("dbo.Produto");
            DropTable("dbo.Pagamento");
            DropTable("dbo.Venda");
            DropTable("dbo.Servico");
            DropTable("dbo.FuncionarioServicoes");
            DropTable("dbo.Faturamento");
            DropTable("dbo.Endereco");
            DropTable("dbo.TipoMovimentacao");
            DropTable("dbo.Movimentacao");
            DropTable("dbo.Caixa");
            DropTable("dbo.Funcionario");
            DropTable("dbo.Agendamento");
        }
    }
}
