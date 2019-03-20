using AcessoBancoDados.Models;

namespace Negocio.Interfaces
{
    public interface IEnderecoRepository : IRepository<Endereco>
    {
        Endereco BuscarPorCep(string cep);
    }
}
