using Core.Entities;
using EFCore.BulkExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        List<T> GetAll(Expression<Func<T, bool>> filter = null, params Expression<Func<T, object>>[] includes);
        T Get(Expression<Func<T, bool>> filter);
        T Get(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] includes);



        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);

        void BulkAdd(List<T> entityList);
        void BulkDelete(List<T> entityList);
        void BulkUpdate(List<T> entityList);
        void BulkInsertOrUpdate(List<T> entityList);
        void BulkMerge(List<T> entityList, BulkConfig bulkConfig);




    }
}
