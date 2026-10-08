using DestekPaneli.Domain.Common;
using System.Linq.Expressions;

namespace DestekPaneli.Application.Interfaces.Repositories
{
    public interface IRepository
    {
        Task<T> Add<T>(T entity) where T : BaseEntity;
        T Update<T>(T entity) where T : BaseEntity;
        Task<T> Delete<T>(Guid id) where T : BaseEntity;
        Task<T> GetById<T>(Guid id) where T : BaseEntity;
        IQueryable<T> GetList<T>(Expression<Func<T, bool>> expression) where T : BaseEntity;
        IQueryable<T> GetNonDeleteAndActive<T>(Expression<Func<T, bool>> expression) where T : BaseEntity;
        IQueryable<T> GetQueryable<T>(Expression<Func<T, bool>> expression) where T : BaseEntity;
    }
}
