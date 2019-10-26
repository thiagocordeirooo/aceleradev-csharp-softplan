using AceleraDev.Domain.Interfaces.Base;
using AceleraDev.Domain.Models.Base;
using System;
using System.Collections.Generic;

namespace AceleraDev.Domain.Services.Base
{
    public class ServiceBase<TModel> : IServiceBase<TModel> where TModel : ModelBase
    {
        protected IRepositoryBase<TModel> _repositoryBase;

        public ServiceBase(IRepositoryBase<TModel> repositoryBase)
        {
            _repositoryBase = repositoryBase;
        }

        public void Add(TModel obj)
        {
            _repositoryBase.Add(obj);
        }

        public IList<TModel> Find(Func<TModel, bool> predicate)
        {
            return _repositoryBase.Find(predicate);
        }

        public IList<TModel> GetAll()
        {
            return _repositoryBase.GetAll();
        }

        public TModel GetById(Guid id)
        {
            return _repositoryBase.GetById(id);
        }

        public void Remove(Guid id)
        {
            _repositoryBase.Remove(id);
        }

        public void Update(TModel obj)
        {
            _repositoryBase.Update(obj);
        }
    }
}