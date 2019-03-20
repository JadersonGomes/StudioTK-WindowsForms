using AcessoBancoDados.Models;
using System;

namespace Negocio.Interfaces
{
    public interface ICaixaRepository : IRepository<Caixa>
    {
        DateTime BuscarUltimoFechamento();
    }
}
