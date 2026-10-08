using DestekPaneli.Application.Interfaces.Repositories;
using DestekPaneli.Domain.Common;
using DestekPaneli.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DestekPaneli.Persistence.Repositories
{
    public sealed class Repository : IRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public Repository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        private DbSet<T> GetTable<T>() where T : BaseEntity
        {
            return _dbContext.Set<T>();
        }
        public async Task<T> Add<T>(T entity) where T : BaseEntity
        {
            await GetTable<T>().AddAsync(entity);
            return entity;
        }

        public async Task<T> Delete<T>(Guid id) where T : BaseEntity
        {
            var obj = await Find<T>(x => x.Id == id);
            await Delete(obj);
            return obj;
        }
        public async Task<T> Delete<T>(T model) where T : BaseEntity
        {
            try
            {
                Update<T>(model);
                return model;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<T> Find<T>(Expression<Func<T, bool>> expression) where T : BaseEntity
        {
            try
            {
                return await GetTable<T>().FirstOrDefaultAsync(expression);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<T> GetById<T>(Guid id) where T : BaseEntity
        {
            return await Find<T>(t => t.Id == id);
        }

        public IQueryable<T> GetList<T>(Expression<Func<T, bool>> expression) where T : BaseEntity
        {
            return GetTable<T>().Where(expression);
        }

        public IQueryable<T> GetNonDeleteAndActive<T>(Expression<Func<T, bool>> expression) where T : BaseEntity
        {
            try
            {
                return GetQueryable<T>(t => t.IsDeleted == false).Where(expression);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public IQueryable<T> GetQueryable<T>(Expression<Func<T, bool>> expression) where T : BaseEntity
        {
            return GetTable<T>().Where(expression);
        }

        public T Update<T>(T entity) where T : BaseEntity
        {
            GetTable<T>().Update(entity);
            return entity;
        }
    }
}
