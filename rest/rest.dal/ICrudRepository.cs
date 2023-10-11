using Rest.Model;

namespace Rest.Dal {

    /// <summary>
    ///     A repository for CRUD operations.
    /// </summary>
    public interface ICrudRepository<E> where E : Entity {

        /// <summary>
        ///     Get all entities.
        /// </summary>
        /// <returns>All entities</returns>
        public List<E> GetAll();

        /// <summary>
        ///     Gets an entity according to their id.
        /// </summary>
        /// <param name="id">The id of the entity</param>
        /// <returns>The entity or <c>null</c> if it does not exist</returns>
        public E? GetById(Guid id);

        /// <summary>
        ///     Adds an entity to the database.
        /// </summary>
        /// <param name="entity">The entity</param>
        /// <returns>The added entity</returns>
        public E Add(E entity);

        /// <summary>
        ///     Updates an entity in the database.
        /// </summary>
        /// <param name="entity">The entity</param>
        /// <returns>The updated entity</returns>
        public E Update(E entity);

        /// <summary>
        ///     Removes an entity from the database.
        /// </summary>
        /// <param name="entity">The entity</param>
        public void Remove(E entity);
    }
}
