using AcessoBancoDados.Models;
using System.Collections.Generic;

namespace Negocio.Interfaces
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {

        List<Usuario> PopulaDataGrid();

    }

    
}
