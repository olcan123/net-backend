using Core.Entities;
using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public void Add(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using TContext context = new TContext();
            var deletedEntity = context.Entry(entity);
            deletedEntity.State = EntityState.Deleted;
            context.SaveChanges();
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().FirstOrDefault(filter);
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter, params Expression<Func<TEntity, object>>[] includes)
        {
            using var context = new TContext();
            IQueryable<TEntity> query = context.Set<TEntity>();

            foreach (var include in includes)
                query = query.Include(include);


            return query.FirstOrDefault(filter);
        }


        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return filter == null
                    ? context.Set<TEntity>().ToList()
                    : context.Set<TEntity>().Where(filter).AsNoTracking().ToList();
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includes)
        {
            using TContext context = new TContext();
            IQueryable<TEntity> query = context.Set<TEntity>();

            foreach (var include in includes)
                query = query.Include(include);


            return filter == null
                ? query.ToList()
                : query.Where(filter).ToList();
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void BulkAdd(List<TEntity> entityList)
        {
            using TContext context = new TContext();
            context.BulkInsert(entityList);

        }

        public void BulkDelete(List<TEntity> entityList)
        {
            using TContext context = new TContext();
            context.BulkDelete(entityList);
        }

        public void BulkInsertOrUpdate(List<TEntity> entityList)
        {
            using TContext context = new TContext();
            var bulkConfig = new BulkConfig
            {
                UseTempDB = false,
                PreserveInsertOrder = true,
                SetOutputIdentity = true,
            };
            context.BulkInsertOrUpdate(entityList, bulkConfig);
        }

        public void BulkUpdate(List<TEntity> entityList)
        {
            using TContext context = new TContext();
            context.BulkUpdate(entityList);
        }

        public void BulkMerge(List<TEntity> entityList, BulkConfig bulkConfig)
        {
            using TContext context = new TContext();
            context.BulkInsertOrUpdateOrDelete(entityList, bulkConfig);
        }
    }
}
