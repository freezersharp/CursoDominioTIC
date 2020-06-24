using CursoDominioTIC.Common.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace CursoDominioTIC.API.Services
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        internal CursoDominioTICContext context;
        internal DbSet<TEntity> dbset;
        public BaseRepository(CursoDominioTICContext context)
        {
            this.context = context;
            this.dbset = context.Set<TEntity>();
        }
        public void Delete(TEntity entityToDelete)
        {
            if(context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbset.Attach(entityToDelete);
            }
            dbset.Remove(entityToDelete);
        }

        public void Delete(object id)
        {
            TEntity entityToDelete = dbset.Find(id);
            Delete(entityToDelete);
        }

        public IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {
            IQueryable<TEntity> query = dbset;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if(includeProperties != null)
            {
                foreach (var includeProperty in includeProperties.Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }
            if(orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public TEntity GetById(object id)
        {
           return dbset.Find(id);
        }

        public void Insert(TEntity entityToInsert)
        {
            dbset.Add(entityToInsert);
        }

        public void Update(TEntity entityToUpdate)
        {
            dbset.Attach(entityToUpdate);
            context.Entry(entityToUpdate).State = EntityState.Modified;
        }
    }
}
