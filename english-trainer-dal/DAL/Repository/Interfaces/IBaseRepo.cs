using Microsoft.EntityFrameworkCore;

namespace english_trainer_dal.DAL.Repository.Interfaces;

public interface IBaseRepo <T> where T : class
{
     Task<int> AddAsync(T entity, bool persist = true);

    Task<int> AddRangeAsync(IEnumerable<T> entities, bool persist = true);
    Task<int> UpdateAsync(T entity, bool persist = true);
    Task<int> ExecuteQueryAsync(string query, object[] parameters);
    Task<T> FindAsync(int id);
    Task<int> DeleteAsync(T entity, bool persist = true);
    Task<int> DeleteRangeAsync(IEnumerable<T> entity, bool persist = true);
    Task<int> SaveChangesAsync();
}