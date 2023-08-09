using EntityLayer.Concrete;
using System.Linq.Expressions;

namespace DataAccessLayer.Abstract
{
    public interface INotificationDal : IGenericDal<Notification>
    {
        List<Notification> ListStatus();
    }
}
