using AcessoBancoDados.Models;
using Negocio.Generics;
using Negocio.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Negocio.Implementation
{
    public class ClienteRepository : AcessoDadosEntityFramework<Cliente>, IClienteRepository
    {        
        
        public ClienteRepository(SalaoContext _contexto) : base(_contexto)
        {
        }

        public IList<Cliente> PopulaGrid()
        {
            var listaPersonalizada = (from lista in ListarTodos()
                                     select new Cliente
                                     {
                                         Id = lista.Id,
                                         Nome = lista.Nome,
                                         Email = lista.Email,
                                         Telefone = lista.Telefone

                                     }).ToList();

            return listaPersonalizada;

        }


        public IList<Cliente> ListarPorNome(string nomeCliente)
        {
            var listaNome = entidade.Where(c => c.Nome.Equals(nomeCliente.ToLower()));

            var listaPersonalizada = (from lista in listaNome
                                      select new Cliente
                                      {
                                          Id = lista.Id,
                                          Nome = lista.Nome,
                                          Email = lista.Email,
                                          Telefone = lista.Telefone

                                      }).ToList();

            return listaPersonalizada;
        }

        public IList<Cliente> ListarPorTelefone(string telefone)
        {
            // Verificar se essa expressão regular funciona
            telefone = telefone.Replace("[^0-9]", "");
            var listaTelefone = entidade.Where(c => c.Telefone.Equals(telefone));

            var listaPersonalizada = (from lista in listaTelefone
                                      select new Cliente
                                      {
                                          Id = lista.Id,
                                          Nome = lista.Nome,
                                          Email = lista.Email,
                                          Telefone = lista.Telefone

                                      }).ToList();

            return listaPersonalizada;
        }


        /*public List<Cliente> PopulaDataGrid()
        {
            List<Cliente> listaClientes = new List<Cliente>();            

            Cliente cliente = new Cliente();
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

        }*/
    }
}
