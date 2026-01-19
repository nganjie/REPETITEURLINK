using Microsoft.EntityFrameworkCore;
using REPETITEURLINK;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace REPETITEURLINK.Entities.Repositories;

public class Repository : IDisposable, IRepository
{
    private RepetitionLinkDataContext _context;

    public RepetitionLinkDataContext Context
    {
        get
        {
            return _context;
        }
    }

    public Repository(RepetitionLinkDataContext context)
    {
        _context = context;
        _context.ChangeTracker.AutoDetectChangesEnabled = false;

    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    public async Task<int> InsertAsync(object entity)
    {
        try
        {
            _context.Add(entity);
            var result = await _context.SaveChangesAsync();
            return result;
        }
        catch
        {
            throw;
        }
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    public async Task<int> UpdateAsync(object entity)
    {
        try
        {

            var dbEntity = _context.Entry(entity);
            dbEntity.State = EntityState.Modified;
            var result = await _context.SaveChangesAsync();
            return result;
        }
        catch (DBConcurrencyException)
        {
            return 0;
        }

        catch (DbUpdateException)
        {
            //log the error to the db
            throw;
        }
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    public async Task<int> DeleteAsync(object entity)
    {
        try
        {
            var dbEntity = _context.Entry(entity);
            dbEntity.State = EntityState.Deleted;
            return await _context.SaveChangesAsync();
        }
        catch (DBConcurrencyException)
        {

            return 0;
        }
        catch (DbUpdateException)
        {
            //log the error to the db
            throw;
        }
    }

    public async Task<int> InsertManyAsync(IEnumerable<object> entities)
    {
        try
        {
            foreach (var entity in entities)
            {
                var dbEntity = _context.Entry(entity);
                dbEntity.State = EntityState.Modified;
            }

            return await _context.SaveChangesAsync();
        }
        catch (DBConcurrencyException)
        {
            return 0;
        }
        catch (DbUpdateException)
        {
            //log the error to the db
            throw;
        }
    }

    public async Task<int> DeleteManyAsync(IEnumerable<object> entities)
    {
        foreach (var entity in entities)
        {
            await this.DeleteAsync(entity);

        }
        return 1;
    }

    /// <summary>
    ///
    /// </summary>
    /// <returns></returns>
    public IQueryable<T> GetAll<T>() where T : class
    {
        return _context.Set<T>();
    }

    public virtual IQueryable<T> GetPage<T>(int index, int pageSize)
    {
        throw new NotSupportedException("This method is not supported iin the base class");
    }

    /// <summary>
    ///
    /// </summary>
    public void Dispose()
    {
        GC.Collect();
    }

}

