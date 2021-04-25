using Microsoft.EntityFrameworkCore;
using MovieRating.Data.ApiModels;
using MovieRating.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRating.Data.Repository
{
    public interface IRepository<TEntity>
    {
        TEntity Add(TEntity entity);
        TEntity Update(TEntity entity);
        void Remove(TEntity entity);
        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();

    }
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        readonly MovieRatingDbContext dbContext;
        readonly DbSet<TEntity> dbSet;

        public Repository(MovieRatingDbContext db)
        {
            dbContext = db;
            dbSet = dbContext.Set<TEntity>();
        }

        public TEntity Add(TEntity entity)
        {
            dbSet.Add(entity);
            dbContext.SaveChanges();
            return entity;
        }

        public TEntity Update(TEntity entity)
        {
            dbContext.Entry(entity).State = EntityState.Modified;
            dbContext.SaveChanges();
            return entity;
        }

        public void Remove(TEntity entity)
        {
            dbSet.Remove(entity);
            dbContext.SaveChanges();
        }

        public TEntity Get(int id)
        {
            return dbSet.Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return dbSet.ToList();
        }
    }
}
