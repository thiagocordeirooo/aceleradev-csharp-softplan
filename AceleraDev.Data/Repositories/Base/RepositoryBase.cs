using AceleraDev.Data.Context;
using AceleraDev.Domain.Interfaces.Base;
using AceleraDev.Domain.Models;
using AceleraDev.Domain.Models.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AceleraDev.Data.Repositories.Base
{
    public class RepositoryBase<TModel> : IRepositoryBase<TModel> where TModel : ModelBase
    {
        protected readonly AceleraDevContext _context;

        public RepositoryBase(AceleraDevContext context)
        {
            _context = context;
        }

        public void Add(TModel obj)
        {
            _context.Set<TModel>().Add(obj);
            _context.SaveChanges();
        }

        public IList<TModel> Find(Func<TModel, bool> predicate)
        {
            return _context.Set<TModel>().Where(predicate).ToList();
        }

        public IList<TModel> GetAll()
        {
            return _context.Set<TModel>().ToList();
        }

        public TModel GetById(Guid id)
        {
            return _context.Set<TModel>().FirstOrDefault(p => p.Id == id);
        }

        public void Remove(Guid id)
        {
            _context.Set<TModel>().Remove(this.GetById(id));
            _context.SaveChanges();
        }

        public void Update(TModel obj)
        {
            this.Remove(obj.Id);
            this.Add(obj);
        }
    }
}
