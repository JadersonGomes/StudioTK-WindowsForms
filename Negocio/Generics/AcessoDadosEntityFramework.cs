using AcessoBancoDados.Models;
using Negocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Negocio.Generics
{
    public class AcessoDadosEntityFramework<T> : IRepository<T> where T : class
    {
        SalaoContext contexto = null;
        protected DbSet<T> entidade { get; } = null;
        // CONECTOR 6.10

        public AcessoDadosEntityFramework(SalaoContext _contexto)
        {
            contexto = _contexto;
            entidade = contexto.Set<T>();
        }

        public void Adicionar(T model)
        {
            entidade.Add(model);
        }

        public void Atualizar(T model)
        {
            contexto.Entry(model).State = EntityState.Modified;
        }

        public T BuscarPorId(int id)
        {
            T model = entidade.Find(id);
            return model;
        }

        public void Excluir(T model)
        {
            entidade.Remove(model);
        }

        public void ExcluirPorId(int id)
        {
            T model = entidade.Find(id);
            entidade.Remove(model);
        }

        public List<T> ListarTodos()
        {
            return entidade.ToList();
        }

        public void Salvar()
        {
            contexto.SaveChanges();
        }


        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    contexto.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }

}
