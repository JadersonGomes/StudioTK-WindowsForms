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
    public class FuncionarioRepository : AcessoDadosEntityFramework<Funcionario>, IFuncionarioRepository
    {        

        public FuncionarioRepository(SalaoContext _contexto) : base(_contexto)
        {
        }

        public IEnumerable<Funcionario> ListarPorNome(string nomeFuncionario)
        {
            // Fazer o teste se o entity busca mesmo com diferença de upper/ lower case
            return entidade.Where(f => f.Nome.Equals(nomeFuncionario));
        }

        public IEnumerable<Funcionario> ListarPorTelefone(string telefone)
        {
            // Verificar se essa expressão regular funciona
            telefone = telefone.Replace("[^0-9]", "");
            return entidade.Where(f => f.Telefone.Equals(telefone));
        }


        public List<Funcionario> PopulaDataGrid()
        {
            List<Funcionario> listaFuncionarios = new List<Funcionario>();

            Endereco endereco = new Endereco();
            endereco.Id = 1;
            endereco.Cep = "02991040";
            endereco.Estado = "SP";
            endereco.Cidade = "São Paulo";
            endereco.Bairro = "Jardim 1";
            endereco.Rua = "Rua Primeiro de Abril";
            endereco.Numero = "512";

            Funcionario funcionario = new Funcionario();
            funcionario.Id = 1;
            funcionario.Nome = "Karol";
            funcionario.Telefone = "011941474409";
            funcionario.Comissao = "60%";
            funcionario.Endereco = endereco; 

            listaFuncionarios.Add(funcionario);
            listaFuncionarios.Add(funcionario);
            listaFuncionarios.Add(funcionario);
            listaFuncionarios.Add(funcionario);
            listaFuncionarios.Add(funcionario);

            return listaFuncionarios;

        }
    }
}
