using AcessoBancoDados.Models;
using Negocio.Generics;
using Negocio.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Negocio.Implementation
{
    public class FuncionarioRepository : AcessoDadosEntityFramework<Funcionario>, IFuncionarioRepository
    {        

        public FuncionarioRepository(SalaoContext _contexto) : base(_contexto)
        {
        }

        public IList<Funcionario> ListarPorNome(string nomeFuncionario)
        {
            // Fazer o teste se o entity busca mesmo com diferença de upper/ lower case
            var listaNome = entidade.Where(f => f.Nome.Equals(nomeFuncionario));

            var listaPersonalizada = (from lista in listaNome
                                      select new Funcionario
                                      {
                                          Id = lista.Id,
                                          Nome = lista.Nome,
                                          Telefone = lista.Telefone

                                      }).ToList();


            return listaPersonalizada;
        }

        public IList<Funcionario> ListarPorTelefone(string telefone)
        {
            // Verificar se essa expressão regular funciona
            telefone = telefone.Replace("[^0-9]", "");
            var listaTelefone = entidade.Where(f => f.Telefone.Equals(telefone));

            var listaPersonalizada = (from lista in listaTelefone
                                      select new Funcionario
                                      {
                                          Id = lista.Id,
                                          Nome = lista.Nome,
                                          Telefone = lista.Telefone

                                      }).ToList();


            return listaPersonalizada;
        }

        public IList<Funcionario> PopulaGrid()
        {

            var listaPersonalizada = (from lista in ListarTodos()
                                      select new Funcionario
                                      {
                                          Id = lista.Id,
                                          Nome = lista.Nome,
                                          Telefone = lista.Telefone

                                      }).ToList();


            return listaPersonalizada;


        }

        /*public List<Funcionario> PopulaDataGrid()
        {
            List<Funcionario> listaFuncionarios = new List<Funcionario>();

            Endereco endereco = new Endereco();
            endereco.Id = 1;
            endereco.Cep = "02991040";
            endereco.Estado = "SP";
            endereco.Cidade = "São Paulo";
            endereco.Bairro = "Jardim 1";
            endereco.Logradouro = "Rua Primeiro de Abril";
            endereco.Numero = 512;

            Funcionario funcionario = new Funcionario();
            funcionario.Id = 1;
            funcionario.Nome = "Karol";
            funcionario.Telefone = "011941474409";
            funcionario.Comissao = 60;
            funcionario.Endereco = endereco; 

            listaFuncionarios.Add(funcionario);
            listaFuncionarios.Add(funcionario);
            listaFuncionarios.Add(funcionario);
            listaFuncionarios.Add(funcionario);
            listaFuncionarios.Add(funcionario);

            return listaFuncionarios;

        }*/
    }
}
