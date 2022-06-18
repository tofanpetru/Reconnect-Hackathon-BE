using PartyMaker.Infrastructure.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace PartyMaker.Infrastructure.Repository.Abstract
{
    public abstract class AbstractRepository<TModel> : IAbstractRepository<TModel> where TModel : class
    {
        protected readonly ApplicationDbContext DataBaseContext;

        public AbstractRepository(ApplicationDbContext context)
        {
            DataBaseContext = context;
        }

        public void Add(TModel entity)
        {
            DataBaseContext.Set<TModel>().Add(entity);
        }

        public TModel Get<T>(T id)
        {
            return DataBaseContext.Set<TModel>().Find(id);
        }

        public ICollection<TModel> GetAll()
        {
            return DataBaseContext.Set<TModel>().ToList();
        }

        public void Remove(TModel entity)
        {
            DataBaseContext.Set<TModel>().Remove(entity);
        }

        public void SaveChanges()
        {
            DataBaseContext.SaveChanges();
        }
    }
}
