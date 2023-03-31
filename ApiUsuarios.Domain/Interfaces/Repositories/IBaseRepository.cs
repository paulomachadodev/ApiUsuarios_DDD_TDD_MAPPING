using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiUsuarios.Domain.Interfaces.Repositories
{
    /// <summary>
    /// Interface de repositório genérico
    /// </summary>
    public interface IBaseRepository<TEntity, TKey>
        where TEntity : class
    {
        void Add(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);

        List<TEntity> GetAll();

        List<TEntity> GetAll(Func<TEntity, bool> where);

        TEntity GetById(TKey id);

        TEntity Get(Func<TEntity, bool> where);
    }
}



