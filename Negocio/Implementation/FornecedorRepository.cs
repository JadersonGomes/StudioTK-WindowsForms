using AcessoBancoDados.Models;
using Negocio.Generics;
using Negocio.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Negocio.Implementation
{
    public class FornecedorRepository : AcessoDadosEntityFramework<Fornecedor>, IFornecedorRepository
    {
        
        public FornecedorRepository(SalaoContext _contexto) : base(_contexto)
        {
        }

        public IEnumerable<Fornecedor> ListarPorNome(string nomeFornecedor)
        {
            // Fazer o teste se o entity busca mesmo com diferença de upper/ lower case
            return entidade.Where(f => f.Nome.Equals(nomeFornecedor));
        }

        public IEnumerable<Fornecedor> ListarPorTelefone(string telefone)
        {
            // Verificar se essa expressão regular funciona
            telefone = telefone.Replace("[^0-9]", "");
            return entidade.Where(f => f.Telefone.Equals(telefone));
        }


        public List<Fornecedor> PopulaDataGrid()
        {
            List<Fornecedor> listaFornecedores = new List<Fornecedor>();

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

            listaFornecedores.Add(fornecedor);
            listaFornecedores.Add(fornecedor);
            listaFornecedores.Add(fornecedor);
            listaFornecedores.Add(fornecedor);
            listaFornecedores.Add(fornecedor);

            return listaFornecedores;

        }
    }
}
