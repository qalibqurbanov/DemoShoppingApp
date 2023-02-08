using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DemoShoppingApp.DataAccess.Repositories.Abstract
{
    /// <summary>
    /// Generic ve eyni zamanda Base rolunu oynayan Repository-dir, hansiki diger Abstract/Interface Repositorylerin ortaq metodlarinin imzasini saxlayir.
    /// </summary>
    /// <typeparam name="T">Uzerinde iw goreceyimiz Entity.</typeparam>
    public interface IBaseRepository<T> where T : class
    {
        // _context.product.include("includeProperties").tolist();

        IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate = null!, List<string> includeProperties = null);
        T GetEntity(Expression<Func<T, bool>> predicate, List<string> includeProperties = null);
        void Add(T entity);
        void Delete(T entity);
        void DeleteRange(IEnumerable<T> entity);
    }
}
