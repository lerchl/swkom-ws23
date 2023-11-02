using Microsoft.EntityFrameworkCore;
using Rest.Model;

namespace Rest.Dal {

    /// <summary>
    ///     <see cref="Singleton{T}"/> <see cref="ICrudRepository{E}"/> implementation for <see cref="DbContext"/>s.
    /// </summary>
    /// <typeparam name="E">the <see cref="Entity"/> type</typeparam>
    /// <typeparam name="C">the <see cref="DbContext"/> type</typeparam>
    public abstract class DbCrudRepository<E, C> : ICrudRepository<E>
            where E : Entity, new()
            where C : DbContext, new() {

        /// <summary>
        ///     Get the <see cref="DbSet{E}"/> for <typeparamref name="E"/> from the <see cref="DbContext"/>.
        /// </summary>
        protected abstract DbSet<E> GetDbSet(C context);

        // /////////////////////////////////////////////////////////////////////////
        // Implementations
        // /////////////////////////////////////////////////////////////////////////

        public virtual List<E> GetAll() {
            using var context = new C();
            DbSet<E> dbSet = GetDbSet(context);
            dbSet.Load();
            return dbSet.ToList();
        }

        public virtual E? GetById(long id) {
            using var context = new C();
            return GetDbSet(context).Find(id);
        }

        public virtual E Add(E entity) {
            using var context = new C();
            context.Add(entity);
            context.SaveChanges();
            return entity;
        }

        public virtual E Update(E entity) {
            using var context = new C();
            context.Update(entity);
            context.SaveChanges();
            return entity;
        }

        public virtual void Remove(E entity) {
            using var context = new C();
            context.Remove(entity);
            context.SaveChanges();
        }
    }
}
