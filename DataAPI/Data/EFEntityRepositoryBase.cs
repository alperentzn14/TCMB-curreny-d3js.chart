using Microsoft.EntityFrameworkCore;
using Provision.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Provision.Data
{
    public class EFEntityRepositoryBase<TEntity,TContext> : IEntityRepository<TEntity>
        where TEntity :class,IEntity,new ()
        where TContext:DbContext,new()

        
    {
        public TEntity Get(Expression<Func<TEntity,bool>>filter)
        {
            using (var context=new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }
        public List<TEntity> GetList(Expression<Func<TEntity,bool>>filter=null)
        {
            using(var context=new TContext())
            {
                return filter == null
                    ? context.Set<TEntity>().ToList()
                    : context.Set<TEntity>().Where(filter).ToList();
            }
        }
        public void Add(TEntity entity)
        {
            using (var context = new TContext())
            {
                context.Add(entity);
                context.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        //public TEntity Get(Expression<Func<TEntity,bool>>filter)
        //{
        //    using (var context=new TContext())
        //    {
        //        return context.Set<TEntity>().SingleOrDefault(filter);
        //    }
        //}

        //public List<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null)
        //{
        //    throw new NotImplementedException();
        //}


        public void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
    
    }

