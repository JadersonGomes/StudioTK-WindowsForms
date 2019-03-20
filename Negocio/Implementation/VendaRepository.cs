using System;
using System.Collections.Generic;
using System.Linq;
using Negocio.Interfaces;
using Negocio.Generics;
using AcessoBancoDados.Models;

namespace Negocio.Implementation
{
    public class VendaRepository : AcessoDadosEntityFramework<Venda>, IVendaRepository
    {
        public VendaRepository(SalaoContext _contexto) : base(_contexto)
        {
        }

        // Métodos da tela de Resumo
        public IEnumerable<Venda> ListAllVendas()
        {
            return entidade.ToList().OrderBy(v => v.Data);
        }

        public IEnumerable<Venda> ListarPorIntervaloPeriodo(string dataInicial, string dataFinal)
        {
            return entidade.Where(p => p.Data >= Convert.ToDateTime(dataInicial) && p.Data <= Convert.ToDateTime(dataFinal)).ToList();
        }

        public IEnumerable<Venda> ListarPorFuncionario(string funcionario)
        {
            return entidade.Where(v => v.Funcionario.Equals(funcionario)).OrderBy(v => v.Data);
        }
        public IEnumerable<Venda> ListarPorData(string data)
        {
            return entidade.Where(p => p.Data == Convert.ToDateTime(data));
        }

        public dynamic RecuperaProdutosVendidosPorData(DateTime dataInicial, DateTime dataFinal)
        {
            var query = (from listaProdutos in entidade.Where(v => v.Produtos.Count > 0) select new {
                produtos = listaProdutos.Produtos.FirstOrDefault().Descricao
                
            }).OrderBy(p => p.produtos);

            return query;
        } 


    }
}
