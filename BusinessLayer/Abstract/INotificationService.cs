using EntityLayer.Concrete;
using System.Linq.Expressions;

namespace BusinessLayer.Abstract
{
    public interface INotificationService : IGenericService<Notification>
    {
        List<Notification> ListStatus();
    }
}
