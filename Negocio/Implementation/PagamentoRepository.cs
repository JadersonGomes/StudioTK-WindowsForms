using AcessoBancoDados.Generics;
using Negocio.Interfaces;
using Negocio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcessoBancoDados;
using System.Collections;
using System.Globalization;

namespace Negocio.Implementation
{
    public class PagamentoRepository : AcessoDadosEntityFramework<Pagamento>, IPagamentoRepository
    {
        SalaoContext contexto = new SalaoContext();

        public PagamentoRepository(SalaoContext _contexto) : base(_contexto)
        {
        }

        



        public List<Servico> PopulaServico()
        {
            List<Servico> listaServicos = new List<Servico>();

            Cliente cliente = new Cliente(contexto);
            cliente.Id = 1;
            cliente.Nome = "Jaderson";
            cliente.Telefone = "011976645381";
            cliente.Email = "jaderson_goomes@hotmail.com";

            Funcionario funcionario = new Funcionario(contexto);
            funcionario.Id = 1;
            funcionario.Nome = "Karol";
            funcionario.Telefone = "011941474409";
            funcionario.Comissao = "60%";

            Servico servico = new Servico(contexto);
            servico.Nome = "Corte Masculino";
            servico.Id = 1;
            servico.Data = Convert.ToDateTime(DateTime.Today.ToShortDateString());
            servico.Hora = DateTime.Now.ToShortTimeString();
            servico.Valor = 30;
            servico.Cliente = cliente;
            servico.Funcionario = funcionario;

            Servico servico2 = new Servico(contexto);            
            servico2.Nome = "Unha simples";
            servico2.Id = 2;
            servico2.Data = Convert.ToDateTime(DateTime.Today.ToShortDateString());
            servico2.Hora = DateTime.Now.ToShortTimeString();
            servico2.Valor = 25;
            servico2.Cliente = cliente;
            servico2.Funcionario = funcionario;

            Servico servico3 = new Servico(contexto);
            servico3.Nome = "Venda";
            servico3.Id = 3;
            servico3.Data = Convert.ToDateTime(DateTime.Today.ToShortDateString());
            servico3.Hora = DateTime.Now.ToShortTimeString();
            servico3.Valor = 30; // Voltar para essa linha depois
            servico3.Cliente = cliente;
            servico3.Funcionario = funcionario;

            listaServicos.Add(servico);
            listaServicos.Add(servico2);
            listaServicos.Add(servico3);

            return listaServicos;
        }

        public List<Produto> PopulaProduto()
        {
            List<Produto> listaProdutos = new List<Produto>();

            Endereco endereco = new Endereco(contexto);
            endereco.Id = 1;
            endereco.Cep = "02991040";
            endereco.Estado = "São Paulo";
            endereco.Cidade = "SP";
            endereco.Bairro = "Jardim 1";
            endereco.Rua = "Rua Primeiro de Abril";
            endereco.Numero = "512";

            Fornecedor fornecedor = new Fornecedor(contexto);
            fornecedor.Id = 1;
            fornecedor.Nome = "Josiel";
            fornecedor.Telefone = "011978785454";
            fornecedor.Email = "josiel.joel1@gmail.com";
            fornecedor.Especialidade = "Produtos de cabelo";
            fornecedor.Endereco = endereco;

            Produto produto = new Produto(contexto);
            produto.Id = 1;
            produto.Descricao = "Shampoo Desmaia Cabelo 300ml";
            produto.Quantidade = 10;
            produto.Valor = 25;
            produto.Fornecedor = fornecedor;

            Produto produto2 = new Produto(contexto);
            produto2.Id = 2;
            produto2.Descricao = "Condicionador Desmaia Cabelo 300ml";
            produto2.Quantidade = 10;
            produto2.Valor = 20;
            produto2.Fornecedor = fornecedor;

            Produto produto3 = new Produto(contexto);
            produto3.Id = 3;
            produto3.Descricao = "Kit Desmaia Cabelo";
            produto3.Quantidade = 10;
            produto3.Valor = 80;
            produto3.Fornecedor = fornecedor;


            listaProdutos.Add(produto);
            listaProdutos.Add(produto2);
            listaProdutos.Add(produto3);

            return listaProdutos;
        }


        // Métodos da tela de listar/ consultar/ filtrar Serviço.


        public IEnumerable<Pagamento> ListarPorPeriodo(string data)
        {            
            return entidade.Where(p => p.DataPagamento == Convert.ToDateTime(data));
        }

        public IEnumerable<Pagamento> ListarPorColaborador(string colaborador)
        {
            return entidade.Where(p => p.NomeFuncionario.Equals(colaborador));
        }

        public IEnumerable<Pagamento> ListarPorServico(string servico)
        {
            return entidade.Where(p => p.ServicoRealizado.Equals(servico));
        }       

        public IEnumerable<Pagamento> ListarPorPeriodoServico(string servico, string data)
        {            
            return entidade.Where(p => p.DataPagamento == Convert.ToDateTime(data) && p.ServicoRealizado.Equals(servico));
        }

        public IEnumerable<Pagamento> ListarPorPeriodoColaborador(string data, string colaborador)
        {            
            return entidade.Where(p => p.DataPagamento == Convert.ToDateTime(data) && p.NomeFuncionario.Equals(colaborador));
        }       

        public IEnumerable<Pagamento> ListarPorColaboradorServico(string servico, string colaborador)
        {
            return entidade.Where(p => p.NomeFuncionario.Equals(colaborador) && p.ServicoRealizado.Equals(servico));
        }

        public IEnumerable<Pagamento> ListarPorPeriodoColaboradorServico(string data, string colaborador, string servico)
        {            
            return entidade.Where(p => p.DataPagamento == Convert.ToDateTime(data) && p.NomeFuncionario.Equals(colaborador) && p.ServicoRealizado.Equals(servico));
        }




        // Métodos da tela de fechamento de caixa. 
        public IList<Pagamento> ListarFechamentoDiario(string funcionario, string dataInicial)
        {
            return entidade.Where(p => p.NomeFuncionario.Contains(funcionario) && p.DataPagamento == Convert.ToDateTime(dataInicial)).ToList();
        }

        public IList<Pagamento> ListarFechamentoPeriodo(string funcionario, string dataInicial, string dataFinal)
        {
            return entidade.Where(p => p.NomeFuncionario.Contains(funcionario) && p.DataPagamento >= Convert.ToDateTime(dataInicial) && p.DataPagamento  <= Convert.ToDateTime(dataFinal)).ToList();
        }

        

        public double SomarValorTotal(IEnumerable<Pagamento> lista)
        {
            double valorTotal = 0;

            foreach (var item in lista)
            {
                valorTotal += item.Valor;
            }

            return valorTotal;
        }


        // Métodos da tela de Resumo

        public IList<Pagamento> ListarPorIntervaloPeriodo(string dataInicial, string dataFinal)
        {
            return entidade.Where(p => p.DataPagamento >= Convert.ToDateTime(dataInicial) && p.DataPagamento <= Convert.ToDateTime(dataFinal)).ToList();
        }


        public string calculaDesconto(double auxValor, double valor, double porcentagem)
        {
            double desconto = auxValor * porcentagem;
            valor = auxValor - desconto;
            return String.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:C}", valor);
        }



    }
}
