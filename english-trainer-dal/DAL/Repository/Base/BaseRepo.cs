
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using english_trainer_dal.DAL.Contexts;
using english_trainer_dal.DAL.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace english_trainer_dal.DAL.Repository.Base;

public abstract class BaseRepo <T>:IBaseRepo<T> where T: Models.Base
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
    
    public virtual async Task<T?> GetOneAsync(int id) => await _dbset.FindAsync(id);

    public virtual async Task<IEnumerable<T?>> GetAllAsync() => await Task.Run(() => _dbset.ToList());

    public async Task Update(T entity)
    {
       await Task.Run(() => _context.Update(entity));
       await SaveChangesAsync();
    }

    public async Task<int> SaveChangesAsync()
    {

        try
        {
            return await _context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public virtual async Task<bool> CheckExistence(int id)
    {
        return await Task.Run(() => _dbset.Any(item => item.Id == id));
    }

    public virtual async Task DeleteAsync(T entity, bool persist = true)
    {
         await Task.Run(() => _dbset.Remove(entity));
    }

    public virtual async Task DeleteRangeAsync(IEnumerable<T> entities, bool persist = true)
    {
        await Task.Run(() => _dbset.RemoveRange(entities));
    }

}
