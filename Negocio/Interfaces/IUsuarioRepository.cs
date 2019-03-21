using AcessoBancoDados.Models;
using System.Collections.Generic;

namespace Negocio.Interfaces
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        IList<Usuario> PopulaGrid();
        IList<Usuario> BuscarPorNome(string nome);

    }

    
}
