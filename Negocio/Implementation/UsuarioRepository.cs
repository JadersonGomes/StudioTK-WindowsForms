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
    public class UsuarioRepository : AcessoDadosEntityFramework<Usuario>, IUsuarioRepository
    {

        protected SalaoContext contexto = new SalaoContext();

        public UsuarioRepository(SalaoContext _contexto) : base(_contexto)
        {
        }


        public List<Usuario> PopulaDataGrid()
        {
            List<Usuario> listaUsuarios = new List<Usuario>();            

            Usuario usuario = new Usuario(contexto);
            usuario.Id = 1;
            usuario.nomeUsuario = "Jaderson";
            //usuario.Senha = "123";
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
