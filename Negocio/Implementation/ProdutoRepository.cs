using AcessoBancoDados;
using AcessoBancoDados.Generics;
using Negocio.Interfaces;
using Negocio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Implementation
{
    public class ProdutoRepository : AcessoDadosEntityFramework<Produto>, IProdutoRepository
    {
        protected SalaoContext contexto = new SalaoContext();

        public ProdutoRepository(SalaoContext _contexto) : base(_contexto)
        {
        }

        public IEnumerable<Produto> ListarPorNome(string nomeProduto)
        {
            // Fazer o teste se o entity busca mesmo com diferença de upper/ lower case
            return entidade.Where(c => c.Descricao.Equals(nomeProduto));
        }

        /*public IEnumerable<Produto> ListarPorFornecedor(string nomeFornecedor)
        {
            return entidade.Where(c => c.Fornecedor.Nome.Equals(nomeFornecedor));
        }*/


        public List<Produto> PopulaDataGrid()
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
            produto.Descricao = "Shampoo 300ml Desmaia Cabelo";
            produto.Quantidade = 10;
            produto.Valor = 30;
            produto.Fornecedor = fornecedor;

            //fornecedor.Endereco = endereco; Esse campo será excluído quando eu inserir os dados no DataGrid com o LINQ

            listaProdutos.Add(produto);
            listaProdutos.Add(produto);
            listaProdutos.Add(produto);
            listaProdutos.Add(produto);
            listaProdutos.Add(produto);

            return listaProdutos;

        }
    }
}
