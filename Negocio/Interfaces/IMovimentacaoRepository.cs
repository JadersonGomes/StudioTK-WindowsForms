using AcessoBancoDados.Models;
using System;
using System.Collections.Generic;

namespace Negocio.Interfaces
{
    public interface IMovimentacaoRepository : IRepository<Movimentacao>
    {
        List<Movimentacao> ListarPorPeriodo(DateTime dataInicial, DateTime dataFinal);
    }

    
}
