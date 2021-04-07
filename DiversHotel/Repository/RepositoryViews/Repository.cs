using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Data.Repositories.RepositoryViews;
using DiversHotel.Data;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
  public abstract class Repository<TEntity> : IRepository<TEntity>
    where TEntity : class
  {
    protected ApplicationDbContext DbContext { get; set; }
    public DbSet<TEntity> Entities { get; }
    public IQueryable<TEntity> Table => Entities;
    public IQueryable<TEntity> TableNoTracking => Entities.AsNoTracking();

    public Repository(ApplicationDbContext dbContext)
    {
      DbContext = dbContext;
      Entities = dbContext.Set<TEntity>();
    }

    public void Add(TEntity entity, bool saveNow = true)
    {
      DbContext.Add(entity);
      if (saveNow)
        DbContext.SaveChanges();
    }

    public async Task AddAsync(TEntity entity, CancellationToken cancellationToken, bool saveNow = true)
    {
      await DbContext.AddAsync(entity, cancellationToken);
      if (saveNow)
        await DbContext.SaveChangesAsync(cancellationToken);
    }

    public void AddRange(IEnumerable<TEntity> entities, bool saveNow = true)
    {
      DbContext.AddRange(entities);
      if (saveNow)
        DbContext.SaveChanges();
    }

    public async Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken,
      bool saveNow = true)
    {
      await DbContext.AddRangeAsync(entities, cancellationToken);
      if (saveNow)
        await DbContext.SaveChangesAsync(cancellationToken);
    }

    public void Update(TEntity entity, bool saveNow = true)
    {
      DbContext.Update(entity);
      if (saveNow)
        DbContext.SaveChanges();
    }

    public async Task UpdateAsync(TEntity entity, CancellationToken cancellationToken, bool saveNow = true)
    {
      Entities.Update(entity);
      if (saveNow)
        await DbContext.SaveChangesAsync(cancellationToken);
    }

    public void UpdateRange(IEnumerable<TEntity> entities, bool saveNow = true)
    {
      Entities.UpdateRange(entities);
      if (saveNow)
        DbContext.SaveChanges();
    }

    public async Task UpdateRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken,
      bool saveNow = true)
    {
      Entities.UpdateRange(entities);
      if (saveNow)
        await DbContext.SaveChangesAsync();
    }

    public void Delete(TEntity entity, bool saveNow = true)
    {
      Entities.Remove(entity);
      if (saveNow)
        DbContext.SaveChanges();
    }

    public async Task DeleteAsync(TEntity entity, CancellationToken cancellationToken, bool saveNow = true)
    {
      Entities.Remove(entity);
      if (saveNow)
        await DbContext.SaveChangesAsync(cancellationToken);
    }

    public void DeleteRange(IEnumerable<TEntity> entities, bool saveNow = true)
    {
      Entities.RemoveRange(entities);
      if (saveNow)
        DbContext.SaveChanges();
    }

    public async Task DeleteRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken,
      bool saveNow = true)
    {
      Entities.RemoveRange(entities);
      if (saveNow)
        await DbContext.SaveChangesAsync(cancellationToken);
    }

    public void Attach(TEntity entity)
    {
      throw new System.NotImplementedException();
    }

    public void Detach(TEntity entity)
    {
      throw new System.NotImplementedException();
    }

    public TEntity GetById(params object[] ids)
    {
      throw new System.NotImplementedException();
    }

    public async Task<TEntity> GetByIdAsync(CancellationToken cancellationToken, params object[] ids)
    {
      throw new System.NotImplementedException();
    }
  }
}