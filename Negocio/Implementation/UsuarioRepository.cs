using AcessoBancoDados.Models;
using Negocio.Generics;
using Negocio.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Negocio.Implementation
{
    public class UsuarioRepository : AcessoDadosEntityFramework<Usuario>, IUsuarioRepository
    {        

        public UsuarioRepository(SalaoContext _contexto) : base(_contexto)
        {
        }

        public IList<Usuario> BuscarPorNome(string nome)
        {
            var listaNome = entidade.ToList().Where(u => u.nomeUsuario.Equals(nome));

            var listaPersonalizada = (from lista in listaNome
                                      select new Usuario
                                      {
                                          Id = lista.Id,
                                          nomeUsuario = lista.nomeUsuario,
                                          Email = lista.Email

                                      }).ToList();

            return listaPersonalizada;
        }


        public IList<Usuario> PopulaGrid()
        {

            var listaPersonalizada = (from lista in ListarTodos()
                                      select new Usuario
                                      {
                                          Id = lista.Id,
                                          nomeUsuario = lista.nomeUsuario,
                                          Email = lista.Email

                                      }).ToList();

            return listaPersonalizada;

        }


        /*public List<Usuario> PopulaDataGrid()
        {
            List<Usuario> listaUsuarios = new List<Usuario>();            

            Usuario usuario = new Usuario();
            usuario.Id = 1;
            usuario.nomeUsuario = "Jaderson";
            usuario.Senha = "123";
            usuario.email = "jaderson_goomes@hotmail.com";

            listaUsuarios.Add(usuario);
            listaUsuarios.Add(usuario);
            listaUsuarios.Add(usuario);
            listaUsuarios.Add(usuario);
            listaUsuarios.Add(usuario);

            return listaUsuarios;

        }*/

    }
}
