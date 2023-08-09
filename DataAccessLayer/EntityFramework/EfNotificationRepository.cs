using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;

namespace DataAccessLayer.EntityFramework
{
    public class EfNotificationRepository : GenericRepository<Notification>, INotificationDal
    {
        public List<Notification> ListStatus()
        {
            using (var db = new Context())
            {
                return db.Notifications.Where(x => x.NotificationStatus == true).ToList();
            }
        }
    }
}
