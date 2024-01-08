using Rest.Dal;
using Rest.Logic.Validation;
using Rest.Model;


namespace Rest.Logic.Service;

public class CrudService<E, R, V> : ICrudService<E> where E : Entity where R : ICrudRepository<E> where V : IValidator<E>
{

    protected readonly R _repository;
    protected readonly V _validator;

    // /////////////////////////////////////////////////////////////////////////
    // Init
    // /////////////////////////////////////////////////////////////////////////

    public CrudService(R repository, V validator)
    {
        _repository = repository;
        _validator = validator;
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
        var result = _validator.ValidateSave(entity);

        if (!result.Valid) {
            throw new ValidationException(result);
        }

        

        return _repository.Add(entity);
    }

    public virtual E Update(E entity)
    {
        var result = _validator.ValidateSave(entity);

        if (!result.Valid) {
            throw new ValidationException(result);
        }

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
