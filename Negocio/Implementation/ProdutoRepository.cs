using AcessoBancoDados.Models;
using Negocio.Generics;
using Negocio.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Negocio.Implementation
{
    public class ProdutoRepository : AcessoDadosEntityFramework<Produto>, IProdutoRepository
    {        

        public ProdutoRepository(SalaoContext _contexto) : base(_contexto)
        {
        }

        public IList<Produto> ListarPorNome(string nomeProduto)
        {
            // Fazer o teste se o entity busca mesmo com diferença de upper/ lower case
            var listaNome = entidade.Where(c => c.Descricao.Equals(nomeProduto));

            var listaPersonalizada = (from lista in listaNome
                                      select new Produto
                                      {
                                          Id = lista.Id,
                                          Descricao = lista.Descricao,
                                          QntdEstoque = lista.QntdEstoque,
                                          Valor = lista.Valor

                                      }).ToList();

            return listaPersonalizada;
        }

        public IList<Produto> PopulaGrid()
        {

            var listaPersonalizada = (from lista in ListarTodos()
                                      select new Produto 
                                      {
                                          Id = lista.Id,
                                          Descricao = lista.Descricao,
                                          QntdEstoque = lista.QntdEstoque,
                                          Valor = lista.Valor

                                      }).ToList();

            return listaPersonalizada;

        }        


        /*public List<Produto> PopulaDataGrid()
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
            produto.Descricao = "Shampoo 300ml Desmaia Cabelo";
            produto.QntdEstoque = 10;
            produto.Valor = 30;
            produto.Fornecedor = fornecedor;

            //fornecedor.Endereco = endereco; Esse campo será excluído quando eu inserir os dados no DataGrid com o LINQ

            listaProdutos.Add(produto);
            listaProdutos.Add(produto);
            listaProdutos.Add(produto);
            listaProdutos.Add(produto);
            listaProdutos.Add(produto);

            return listaProdutos;

        }*/
    }
}
