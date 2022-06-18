using System.Collections.Generic;

namespace PartyMaker.Infrastructure.Repository.Interfaces
{
    public interface IAbstractRepository<TModel> where TModel : class
    {
        TModel Get<T>(T id);
        ICollection<TModel> GetAll();
        void Add(TModel entity);
        void Remove(TModel entity);
        void SaveChanges();
    }
}
