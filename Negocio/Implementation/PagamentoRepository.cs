using Negocio.Interfaces;
using System;
using System.Collections.Generic;
using Negocio.Generics;
using AcessoBancoDados.Models;

namespace Negocio.Implementation
{
    public class PagamentoRepository : AcessoDadosEntityFramework<Pagamento>, IPagamentoRepository
    {        

        public PagamentoRepository(SalaoContext _contexto) : base(_contexto)
        {
        }


        public List<Servico> PopulaServico()
        {
            List<Servico> listaServicos = new List<Servico>();

            Cliente cliente = new Cliente();
            cliente.Id = 1;
            cliente.Nome = "Jaderson";
            cliente.Telefone = "011976645381";
            cliente.Email = "jaderson_goomes@hotmail.com";

            Funcionario funcionario = new Funcionario();
            funcionario.Id = 1;
            funcionario.Nome = "Karol";
            funcionario.Telefone = "011941474409";
            funcionario.Comissao = 60;

            Servico servico = new Servico();
            servico.Nome = "Corte Masculino";
            servico.Id = 1;
            servico.Valor = 30;

            Servico servico2 = new Servico();            
            servico2.Nome = "Unha simples";
            servico2.Id = 2;           
            servico2.Valor = 25;
            

            Servico servico3 = new Servico();
            servico3.Nome = "Venda";
            servico3.Id = 3;            
            servico3.Valor = 30; // Voltar para essa linha depois
            
            listaServicos.Add(servico);
            listaServicos.Add(servico2);
            listaServicos.Add(servico3);

            return listaServicos;
        }

        public List<Produto> PopulaProduto()
        {
            List<Produto> listaProdutos = new List<Produto>();

            Endereco endereco = new Endereco();
            endereco.Id = 1;
            endereco.Cep = "02991040";
            endereco.Estado = "São Paulo";
            endereco.Cidade = "SP";
            endereco.Bairro = "Jardim 1";
            endereco.Logradouro = "Rua Primeiro de Abril";
            endereco.Numero = 512;

            Fornecedor fornecedor = new Fornecedor();
            fornecedor.Id = 1;
            fornecedor.Nome = "Josiel";
            fornecedor.Telefone = "011978785454";
            fornecedor.Email = "josiel.joel1@gmail.com";
            fornecedor.Especialidade = "Produtos de cabelo";
            fornecedor.Endereco = endereco;

            Produto produto = new Produto();
            produto.Id = 1;
            produto.Descricao = "Shampoo Desmaia Cabelo 300ml";
            produto.QntdEstoque = 10;
            produto.Valor = 25;
            produto.Fornecedor = fornecedor;

            Produto produto2 = new Produto();
            produto2.Id = 2;
            produto2.Descricao = "Condicionador Desmaia Cabelo 300ml";
            produto2.QntdEstoque = 10;
            produto2.Valor = 20;
            produto2.Fornecedor = fornecedor;

            Produto produto3 = new Produto();
            produto3.Id = 3;
            produto3.Descricao = "Kit Desmaia Cabelo";
            produto3.QntdEstoque = 10;
            produto3.Valor = 80;
            produto3.Fornecedor = fornecedor;


            listaProdutos.Add(produto);
            listaProdutos.Add(produto2);
            listaProdutos.Add(produto3);

            return listaProdutos;
        }
        

        public double SomarValorTotal(IEnumerable<Pagamento> lista)
        {
            double valorTotal = 0;

            foreach (var item in lista)
            {
                valorTotal += item.ValorTotal;
            }

            return valorTotal;
        }

        public double calculaDesconto(double auxValor, double valor, double porcentagem)
        {
            double desconto = auxValor * porcentagem;
            valor = auxValor - desconto;
            return valor;
        }

    }
}
