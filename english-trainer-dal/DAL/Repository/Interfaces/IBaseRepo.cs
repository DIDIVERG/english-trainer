using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace english_trainer_dal.DAL.Repository.Interfaces;

public interface IBaseRepo <T> where T : class
{
     Task AddAsync(T entity, bool persist = true);
     Task AddRangeAsync(IEnumerable<T> entities, bool persist = true);
     Task ExecuteQueryAsync(string query, object[] parameters);
     Task<T> GetOneAsync(int id);
     Task<IEnumerable<T>> GetAllAsync();
     Task DeleteAsync(T entity, bool persist = true);
     Task DeleteRangeAsync(IEnumerable<T> entity, bool persist = true);
     Task<T> FindAsync(Expression<Func<bool, T>> predicate);

}