using AcessoBancoDados.Models;
using System;
using System.Collections.Generic;

namespace Negocio.Interfaces
{
    public interface ICaixaRepository : IRepository<Caixa>
    {
        DateTime BuscarUltimoFechamento();
        IList<Caixa> BuscarPorPeriodo(DateTime value1, DateTime value2);
        IList<Caixa> ListarTodosOrdenados();
    }
}
