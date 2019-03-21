using AcessoBancoDados.Models;
using System.Collections.Generic;

namespace Negocio.Interfaces
{
    public interface IServicoRepository : IRepository<Servico>
    {
        IList<Servico> BuscarPorNome(string nome);
    }
}
