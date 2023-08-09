using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using System.Linq.Expressions;

namespace DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        Context db = new Context();

        public void Delete(T t)
        {
            db.Remove(t);
            db.SaveChanges();
        }

        public T GetById(int id)
        {
            return db.Set<T>().Find(id);
        }

        public List<T> GetListAll()
        {
            return db.Set<T>().ToList();
        }

        public void Insert(T t)
        {
            db.Add(t);
            db.SaveChanges();
        }

        public List<T> GetListAll(Expression<Func<T, bool>> filter)
        {
            return db.Set<T>().Where(filter).ToList();
        }

        public void Update(T t)
        {
            db.Update(t);
            db.SaveChanges();
        }
    }
}
