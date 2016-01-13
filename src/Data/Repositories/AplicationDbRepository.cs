using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Linq.Dynamic;
using System.Reflection;
using System.Text;
using Entity.Tools;
using PagedList;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity.Migrations;

namespace Data.Repositories
{
    public class ApplicationDbRepository<T> : IRepository<T> where T : class
    {
        protected ApplicationDbContext Context { get; set; }

        public ApplicationDbRepository(ApplicationDbContext context)
        {
            Context = context;
        }
        public IEnumerable<T> Get(Func<T, bool> filter = null)
        {
            return filter == null ? Context.Set<T>() : Context.Set<T>().Where(filter);
        }

        public IPagedList<T> Get(Pagination pagination, Func<T, bool> filter = null)
        {
            return Get(filter).ToPagedList(pagination.Page, pagination.ItemsPerPage);
        }

        public IEnumerable<T> Get(Ordering order, Func<T, bool> filter = null)
        {
            var set = filter == null ? Context.Set<T>() : Context.Set<T>().Where(filter);
            var elements = set.OrderBy(order.Property + (order.Descending ? " descending" : ""));
            return elements;
        }
        public IPagedList<T> Get(Pagination pagination, Ordering order, Func<T, bool> filter = null)
        {
            var set = filter == null ? Context.Set<T>() : Context.Set<T>().Where(filter);
            var elements = set.OrderBy(order.Property + (order.Descending ? " descending" : ""));
            return elements.ToPagedList(pagination.Page, pagination.ItemsPerPage);
        }

        public T Find(params object[] ids)
        {
            return Context.Set<T>().Find(ids);
        }

        public void Remove(T element)
        {
            Context.Entry(element).State = EntityState.Deleted;
        }

        public void Update(T element)
        {
            Context.Entry(element).State = EntityState.Modified;                        
        }

        public T Add(T element)
        {
            Context.Entry(element).State = EntityState.Added;
            return element;
        }

        public int SaveChanges()
        {
            return Context.SaveChanges();
        }

        public IRepository<TK> Clone<TK>() where TK : class
        {
            return new ApplicationDbRepository<TK>(Context);
        }
    }

}