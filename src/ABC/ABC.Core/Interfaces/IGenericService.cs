using Entities.POCOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ABC.Core.Interfaces
{
    public interface IGenericService<TEntity> where TEntity : BaseEntity
    {
        IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "");
        TEntity GetById(int id);
        void Insert(IEnumerable<TEntity> peojects);
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(IEnumerable<TEntity> entites);
        void Delete(TEntity entity);
    }
}
