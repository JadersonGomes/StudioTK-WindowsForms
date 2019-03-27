using System;
using System.Collections.Generic;
using AcessoBancoDados.Models;
using Negocio.Generics;
using Negocio.Interfaces;
using System.Linq;

namespace Negocio.Implementation
{
    public class ServicoRepository : AcessoDadosEntityFramework<Servico>, IServicoRepository
    {       

        public ServicoRepository(SalaoContext _contexto) : base(_contexto)
        {            
        }

        public IList<Servico> BuscarPorNome(string nome)
        {
            var listaNome = entidade.ToList().Where(s => s.Nome.Equals(nome));

            var listaPersonalizada = (from lista in listaNome
                                      select new Servico
                                      {
                                          Id = lista.Id,
                                          Nome = lista.Nome,
                                          Valor = lista.Valor,
                                          Funcionarios = lista.Funcionarios

                                      }).ToList();

            return listaPersonalizada;
        }
    }
}
