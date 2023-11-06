using Rest.Dal;
using Rest.Model;

namespace Rest.Logic.Service;

public class CrudService<E, R> : ICrudService<E> where E : Entity where R : ICrudRepository<E>
{

    protected readonly R _repository;

    // /////////////////////////////////////////////////////////////////////////
    // Init
    // /////////////////////////////////////////////////////////////////////////

    public CrudService(R repository)
    {
        _repository = repository;
    }

    // /////////////////////////////////////////////////////////////////////////
    // Methods
    // /////////////////////////////////////////////////////////////////////////

    public virtual List<E> GetAll()
    {
        return _repository.GetAll();
    }

    public virtual E? GetById(long id)
    {
        return _repository.GetById(id);
    }

    public virtual E Add(E entity)
    {
        return _repository.Add(entity);
    }

    public virtual E Update(E entity)
    {
        return _repository.Update(entity);
    }

    public virtual void Remove(E entity)
    {
        _repository.Remove(entity);
    }

    public virtual void Remove(long id)
    {
        E? e = GetById(id);

        if (e != null) {
            Remove(e);
        }
    }
}
