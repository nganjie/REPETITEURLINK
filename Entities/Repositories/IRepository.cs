using REPETITEURLINK;
using System;
using System.Collections.Generic;
using System.Text;

namespace REPETITEURLINK.Entities.Repositories;

public interface IRepository
{
    Task<int> InsertAsync(object entity);
    Task<int> UpdateAsync(object entity);
    Task<int> DeleteAsync(object entity);
    Task<int> InsertManyAsync(IEnumerable<object> entities);
    Task<int> DeleteManyAsync(IEnumerable<object> entities);
    IQueryable<T> GetAll<T>() where T : class;
    RepetitionLinkDataContext Context { get; }
}
