using Spotify.Models;
using Spotify.Repository.Base;

namespace Spotify.Repository
{
    public class Repository<T>:IRepository<T> where T : class
    {
        private readonly Context Context;
        public Repository(Context _Context)
        {
            Context = _Context;
        }

        public void Add(T entity)
        {
            Context.Set<T>().Add(entity);
            Context.SaveChanges();
        }

        public void Delete(int id)
        {
            T element = Context.Set<T>().Find(id);
            Context.Set<T>().Remove(element);
            Context.SaveChanges();
        }

        public List<T> GetAll(Func<T, bool> predicate)
        {
            return Context.Set<T>().Where(predicate).ToList();
        }

        public T GetById(int id, Func<T, bool> predicate)
        {
            return Context.Find<T>(id);
        }

        public void Update(int id, T newElement)
        {
            Context.Set<T>().Update(newElement);
            Context.SaveChanges();
        }
    }
}
