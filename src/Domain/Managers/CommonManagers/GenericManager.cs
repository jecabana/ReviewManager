using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Repositories;
using Domain.Operations;
using Entity.Tools;
using Entity.Validations;
using PagedList;
using Data;

namespace Domain.Managers
{
    public class GenericManager<T> where T : class
    {
        protected IRepository<T> Repository { get; set; }
        public Manager Manager { get; set; }

        public GenericManager(IRepository<T> repository,Manager manager)
        {
            Repository = repository;
            Manager = manager;
        }

        public IPagedList<T> Get(Pagination pagination, Ordering order, Func<T, bool> filter = null)
        {
            return Repository.Get(pagination, order, filter);
        }
        public IEnumerable<T> Get(Func<T, bool> filter = null)
        {
            return Repository.Get(filter);
        }

        public IPagedList<T> Get(Pagination pagination, Func<T, bool> filter = null)
        {
            return Repository.Get(pagination, filter);
        }

        public T Find(params object[] keys)
        {
            return Repository.Find(keys);
        }
        public virtual OperationResult<T> Add(T element)
        {
            var validation = Validate(element);
            if (validation.Count != 0)
                return new OperationResult<T>()
                {
                    Success = false,
                    Element = element,
                    Errors = validation
                };
            Repository.Add(element);
            return new OperationResult<T>()
            {
                Success = true,
                Element = element
            };
        }
        public virtual OperationResult<T> Update(T element)
        {
            var validation = Validate(element);
            if (validation.Count != 0)
                return new OperationResult<T>()
                {
                    Success = false,
                    Element = element,
                    Errors = validation
                };
            Repository.Update(element);

            return new OperationResult<T>()
            {
                Success = true,
                Element = element
            };
        }
        public virtual OperationResult<T> Remove(T element)
        {
            var validation = ValidateOnRemove(element);
            if (validation.Count != 0)
                return new OperationResult<T>()
                {
                    Success = false,
                    Element = element,
                    Errors = validation
                };
            Repository.Remove(element);
            return new OperationResult<T>()
            {
                Success = true,
                Element = element
            };
        }

        public int SaveChanges()
        {
            return Repository.SaveChanges();
        }

        public virtual Dictionary<string, List<string>> Validate(T element)
        {
            var dic = BaseAttribute.ValidateType(element);
            return dic;
        }
        public virtual Dictionary<string, List<string>> ValidateOnRemove(T element)
        {
            var dic = new Dictionary<string, List<string>>();
            return dic;
        }
    }
}
