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
    public class ClienteRepository : AcessoDadosEntityFramework<Cliente>, IClienteRepository
    {
        protected SalaoContext contexto = new SalaoContext();

        public ClienteRepository(SalaoContext _contexto) : base(_contexto)
        {
        }

        public IEnumerable<Cliente> ListarPorNome(string nomeCliente)
        {
            return entidade.Where(c => c.Nome.Equals(nomeCliente.ToLower()));
        }

        public IEnumerable<Cliente> ListarPorTelefone(string telefone)
        {
            // Verificar se essa expressão regular funciona
            telefone = telefone.Replace("[^0-9]", "");
            return entidade.Where(c => c.Telefone.Equals(telefone));
        }



        public List<Cliente> PopulaDataGrid()
        {
            List<Cliente> listaClientes = new List<Cliente>();            

            Cliente cliente = new Cliente(contexto);
            cliente.Id = 1;
            cliente.Nome = "Jaderson";
            cliente.Telefone = "011976645381";
            cliente.Email = "jaderson_goomes@hotmail.com";

            listaClientes.Add(cliente);
            listaClientes.Add(cliente);
            listaClientes.Add(cliente);
            listaClientes.Add(cliente);
            listaClientes.Add(cliente);

            return listaClientes;

        }
    }
}
