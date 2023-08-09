using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class AdminManager : IAdminService
    {
        IAdminDal _AdminDal;

        public AdminManager(IAdminDal adminDal)
        {
            _AdminDal = adminDal;
        }

        public Admin GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Admin> GetList()
        {
            throw new NotImplementedException();
        }

        public void TAdd(Admin t)
        {
            throw new NotImplementedException();
        }

        public void TDelete(Admin t)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Admin t)
        {
            throw new NotImplementedException();
        }
    }
}
