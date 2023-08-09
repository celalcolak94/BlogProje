using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface IMessageService : IGenericService<Message2>
    {
        List<Message2> GetInboxListByWriter(int id);
        Message2 GetMessageIncludeSenderUser(int id);
    }
}
