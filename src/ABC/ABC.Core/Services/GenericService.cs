using ABC.Core.Interfaces;
using Entities.POCOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ABC.Core.Services
{
    public class GenericService<TEntity> : IGenericService<TEntity> where TEntity : BaseEntity
    {
        private readonly IRepository<TEntity> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public GenericService(IRepository<TEntity> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public TEntity GetById(int id)
        {
            if (id == 0)
                return null;
            return _repository.GetById(id);
        }

        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {
            return _repository.Get(filter, orderBy, includeProperties);
        }

        public void Insert(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            _repository.Insert(entity);
            _unitOfWork.Complete();
        }


        public void Insert(IEnumerable<TEntity> peojects)
        {
            if (peojects == null || peojects.Count() == 0)
                throw new ArgumentNullException(nameof(peojects), "list of entity cannot be null or empty");
            _repository.Insert(peojects);
            _unitOfWork.Complete();
        }

        public void Update(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            _unitOfWork.Complete();
        }

        public void Delete(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            _repository.Delete(entity);
            _unitOfWork.Complete();
        }

        public void Delete(IEnumerable<TEntity> entites)
        {
            if (entites == null || entites.Count() == 0)
                throw new ArgumentNullException(nameof(entites), "list of entity cannot be null or empty");

            _repository.Delete(entites);
            _unitOfWork.Complete();
        }
    }
}
