using AcessoBancoDados.Models;
using Negocio.Generics;
using Negocio.Interfaces;
using System.Collections.Generic;

namespace Negocio.Implementation
{
    public class UsuarioRepository : AcessoDadosEntityFramework<Usuario>, IUsuarioRepository
    {        

        public UsuarioRepository(SalaoContext _contexto) : base(_contexto)
        {
        }


        public List<Usuario> PopulaDataGrid()
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

        }

    }
}
