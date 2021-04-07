using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories.RepositoryViews
{
  public interface IRepository<TEntity> where TEntity: class
  {
     DbSet<TEntity> Entities { get; }
     IQueryable<TEntity> Table { get; }
     IQueryable<TEntity> TableNoTracking { get; }

     //add
     void Add(TEntity entity,bool saveNow = true);
     Task AddAsync(TEntity entity,CancellationToken cancellationToken, bool saveNow = true);
     void AddRange(IEnumerable<TEntity> entities, bool saveNow = true);
     Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken, bool saveNow = true);
     
     //update
     void Update(TEntity entity, bool saveNow = true);
     Task UpdateAsync(TEntity entity, CancellationToken cancellationToken, bool saveNow = true);
     void UpdateRange(IEnumerable<TEntity> entities, bool saveNow = true);
     Task UpdateRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken, bool saveNow = true);
     
     //delete
     void Delete(TEntity entity, bool saveNow = true);
     Task DeleteAsync(TEntity entity, CancellationToken cancellationToken, bool saveNow = true);
     void DeleteRange(IEnumerable<TEntity> entities, bool saveNow = true);
     Task DeleteRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken, bool saveNow = true);
     
     void Attach(TEntity entity);
     void Detach(TEntity entity);
     
     TEntity GetById(params object[] ids);
     Task<TEntity> GetByIdAsync(CancellationToken cancellationToken, params object[] ids);
    
  }
}