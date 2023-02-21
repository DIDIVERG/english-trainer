
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using english_trainer_dal.DAL.Contexts;
using english_trainer_dal.DAL.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace english_trainer_dal.DAL.Repository.Base;

public abstract class BaseRepo <T>:IBaseRepo<T> where T: class
{
    private DbSet<T> _dbset;
    protected DbContext _context;
    public BaseRepo(DbContext context)
    {
        this._context = context;
        _dbset = context.Set<T>();
    }
    
    public virtual async Task AddAsync(T entity, bool persist = true)
    {
        await _dbset.AddAsync(entity);
    }

    public virtual async Task AddRangeAsync(IEnumerable<T> entities, bool persist = true)
    {
        await _dbset.AddRangeAsync(entities);
    }
    
    public virtual async Task ExecuteQueryAsync(string query, object[] parameters)
    {
        await _context.Database.ExecuteSqlRawAsync(query, parameters);
    }
    
    public virtual async Task<T> GetOneAsync(int id) => await _dbset.FindAsync(id);

    public virtual async Task<IEnumerable<T>> GetAllAsync() => await Task.Run(() => _dbset.ToList());

    public virtual async Task<T> FindAsync(Expression<Func<bool,T>> predicate) => await _dbset.FindAsync(predicate);
    
    public virtual async Task DeleteAsync(T entity, bool persist = true)
    {
         await Task.Run(() => _dbset.Remove(entity));
    }

    public virtual async Task DeleteRangeAsync(IEnumerable<T> entities, bool persist = true)
    {
        await Task.Run(() => _dbset.RemoveRange(entities));
    }

}
