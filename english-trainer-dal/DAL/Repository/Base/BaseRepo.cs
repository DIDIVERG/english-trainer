
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using english_trainer_dal.DAL.Contexts;
using english_trainer_dal.DAL.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace english_trainer_dal.DAL.Repository.Base;

public abstract class BaseRepo <T> : IDisposable, IBaseRepo<T> where T: Models.Base
{
    private DbSet<T> _dbset;
    private EnglishTrainerContext _context;
    private bool _disposed;
    public BaseRepo(EnglishTrainerContext context)
    {
        this._context = context;
        _dbset = context.Set<T>();
    }

    public void Dispose()
    {
        Dispose(true); 
        GC.SuppressFinalize(this);
    }
    protected virtual void Dispose(bool disposing)
    {
        if (_disposed)
        {
            return;
        }

        if (disposing)
        {
            // place to releasing managed resources with dispose method 
            _context.Dispose();
        }
        // place to releasing unmanaged resources
        _disposed = true;
    }

    ~BaseRepo() => Dispose(false);


    public virtual async Task<int> AddAsync(T entity, bool persist = true)
    {
        await _dbset.AddAsync(entity);
        return persist ? await SaveChangesAsync() : 0;
    }

    public virtual async Task<int> AddRangeAsync(IEnumerable<T> entities, bool persist = true)
    {
        await _dbset.AddRangeAsync(entities);
        return persist ? await SaveChangesAsync() : 0;
    }

    public virtual async Task<int> UpdateAsync(T entity, bool persist = true)
    {
        await Task.Run(() => _dbset.Update(entity));
        return persist ? await SaveChangesAsync() : 0;

    }

    public virtual async Task<int> ExecuteQueryAsync(string query, object[] parameters)
    {
       return await _context.Database.ExecuteSqlRawAsync(query, parameters);
    }

    public virtual async Task<T> FindAsync(int id) => await _dbset.FindAsync(id);
    
    public virtual async Task<int> DeleteAsync(T entity, bool persist = true)
    {
         await Task.Run(() => _dbset.Remove(entity));
         return persist ? await SaveChangesAsync() : 0;
    }

    public virtual async Task<int> DeleteRangeAsync(IEnumerable<T> entities, bool persist = true)
    {
        await Task.Run(() => _dbset.RemoveRange(entities));
        return persist ? await SaveChangesAsync() : 0;
    }
    public async Task<int> SaveChangesAsync()
    {
        try
        {
            return await _context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            throw new Exception("An error occured while updating database");
        }
    }
}