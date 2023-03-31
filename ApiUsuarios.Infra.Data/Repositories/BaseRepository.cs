using ApiUsuarios.Domain.Interfaces.Repositories;
using ApiUsuarios.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiUsuarios.Infra.Data.Repositories
{
    /// <summary>
    /// Classe para implementar o repositório genérico
    /// </summary>
    public abstract class BaseRepository<TEntity, TKey> : IBaseRepository<TEntity, TKey>
        where TEntity : class
    {
        public virtual void Add(TEntity entity)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Add(entity);
                dataContext.SaveChanges();
            }
        }

        public virtual void Update(TEntity entity)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Entry(entity).State = EntityState.Modified;
                dataContext.SaveChanges();
            }
        }

        public virtual void Delete(TEntity entity)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Remove(entity);
                dataContext.SaveChanges();
            }
        }

        public virtual List<TEntity> GetAll()
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Set<TEntity>().ToList();
            }
        }

        public virtual List<TEntity> GetAll(Func<TEntity, bool> where)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Set<TEntity>()
                    .Where(where)
                    .ToList();
            }
        }

        public virtual TEntity GetById(TKey id)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Set<TEntity>()
                    .Find(id);
            }
        }

        public virtual TEntity Get(Func<TEntity, bool> where)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Set<TEntity>()
                    .Where(where)
                    .FirstOrDefault();
            }
        }
    }
}



