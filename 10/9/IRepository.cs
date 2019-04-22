using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9
{
    interface IRepository<TEntity> where TEntity: class
    {
        List<TEntity> GetAll();
        List<TEntity> Get(Func<TEntity, bool> where);
        void Add(TEntity entity);
        void Remove(TEntity entity);
    }
}
