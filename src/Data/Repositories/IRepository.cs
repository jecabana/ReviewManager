using Entity.Tools;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> Get(Func<T, bool> filter = null);
        IPagedList<T> Get(Pagination pagination, Func<T, bool> filter = null);
        IPagedList<T> Get(Pagination pagination, Ordering order, Func<T, bool> filter = null);
        IEnumerable<T> Get(Ordering order, Func<T, bool> filter = null);
        T Find(params object[] ids);
        void Remove(T element);
        void Update(T element);
        T Add(T element);
        int SaveChanges();
        IRepository<TK> Clone<TK>() where TK : class;
    }
}
