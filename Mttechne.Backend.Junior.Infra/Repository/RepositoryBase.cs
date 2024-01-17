using Microsoft.EntityFrameworkCore;
using Mttechne.Backend.Junior.Domain.Entidades;
using Mttechne.Backend.Junior.Domain.Interfaces;
using Mttechne.Backend.Junior.Infra.Context;
using System.Linq.Expressions;

namespace Mttechne.Backend.Junior.Infra.Repository
{
    public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : Entity, new()
    {
        protected readonly MttechneDbContext Db;
        protected readonly DbSet<TEntity> DbSet;
        private readonly string cn = "Server=(localDb)\\MSSQLLocalDB;Database=Mttechne.Backend.Junior;Trusted_Connection=True;MultipleActiveResultSets=true";

        protected RepositoryBase(MttechneDbContext db)
        {
            Db = db;
            DbSet = db.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public virtual async Task<TEntity> ObterPorId(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual async Task<List<TEntity>> ObterTodos()
        {
            return await DbSet.ToListAsync();
        }

        public virtual async Task Adicionar(TEntity entity)
        {
            DbSet.Add(entity);
            await SaveChanges();
        }

        public virtual async Task Atualizar(TEntity entity)
        {
            DbSet.Update(entity);
            await SaveChanges();
        }

        public virtual async Task Remover(Guid id)
        {
            DbSet.Remove(new TEntity { Id = id });
            await SaveChanges();
        }

        public async Task<int> SaveChanges()
        {
            return await Db.SaveChangesAsync();
        }

        public void Dispose()
        {
            Db?.Dispose();
        }
    }
}
