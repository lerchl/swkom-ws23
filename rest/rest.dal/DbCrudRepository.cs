using Microsoft.EntityFrameworkCore;
using Rest.Model;
using rest.Logging;

namespace Rest.Dal {

    /// <summary>
    ///     <see cref="Singleton{T}"/> <see cref="ICrudRepository{E}"/> implementation for <see cref="DbContext"/>s.
    /// </summary>
    /// <typeparam name="E">the <see cref="Entity"/> type</typeparam>
    /// <typeparam name="C">the <see cref="DbContext"/> type</typeparam>
    public abstract class DbCrudRepository<E, C> : ICrudRepository<E>
            where E : Entity
            where C : DbContext, new() {

        /// <summary>
        ///     Get the <see cref="DbSet{E}"/> for <typeparamref name="E"/> from the <see cref="DbContext"/>.
        /// </summary>
        protected abstract DbSet<E> GetDbSet(C context);

        // /////////////////////////////////////////////////////////////////////////
        // Implementations
        // /////////////////////////////////////////////////////////////////////////

        private readonly ILogger _logger = (rest.Logging.ILogger)LoggerFactory.GetLogger();

        public virtual List<E> GetAll() {
            _logger.Debug($"Getting all {typeof(E).Name}s...");
            using var context = new C();
            DbSet<E> dbSet = GetDbSet(context);
            _logger.Debug($"Got {dbSet.Count()} {typeof(E).Name}s");
            dbSet.Load();
            _logger.Debug("Finished GetAll()");
            return dbSet.ToList();
        }

        public virtual E? GetById(long id) {
            _logger.Debug($"Getting {typeof(E).Name} with id {id}...");
            using var context = new C();
            _logger.Debug("Finished GetById()");
            return GetDbSet(context).Find(id);
        }

        public virtual E Add(E entity) {
            _logger.Debug($"Adding {typeof(E).Name}...");
            using var context = new C();
            context.Add(entity);
            context.SaveChanges();
            _logger.Debug($"Added entity {typeof(E).Name} via Add(E entity).");
            return entity;
        }

        public virtual E Update(E entity) {
            _logger.Debug($"Updating {typeof(E).Name}...");
            using var context = new C();
            context.Update(entity);
            context.SaveChanges();
            _logger.Debug($"Updated entity {typeof(E).Name} via Update(E entity).");
            return entity;
        }

        public virtual void Remove(E entity) {
            _logger.Debug($"Removing {typeof(E).Name}...");
            using var context = new C();
            context.Remove(entity);
            context.SaveChanges();
            _logger.Debug($"Removed entity {typeof(E).Name} via Remove(E entity).");
        }
    }
}
