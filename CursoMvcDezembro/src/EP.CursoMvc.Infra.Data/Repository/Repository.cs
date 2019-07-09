using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using EP.CursoMvc.Domain.Interfaces.Repository;
using EP.CursoMvc.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace EP.CursoMvc.Infra.Data.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected CursoMvcContext Db;
        protected DbSet<TEntity> DbSet;

        public Repository(CursoMvcContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }

        public virtual TEntity Adicionar(TEntity obj)
        {
            return DbSet.Add(obj).Entity;
        }

        public virtual TEntity Atualizar(TEntity obj)
        {
            return DbSet.Update(obj).Entity;
        }

        public virtual IEnumerable<TEntity> ObterTodos()
        {
            return DbSet.ToList();
        }

        public virtual TEntity ObterPorId(Guid id)
        {
            return DbSet.Find(id);
        }

        public IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }

        public virtual void Remover(Guid id)
        {
            DbSet.Remove(DbSet.Find(id));
        }

        public int SaveChanges()
        {
            return Db.SaveChanges();
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}