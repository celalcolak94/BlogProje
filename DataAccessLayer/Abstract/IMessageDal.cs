using EntityLayer.Concrete;

namespace DataAccessLayer.Abstract
{
    public interface IMessageDal : IGenericDal<Message2>
    {
        List<Message2> GetListWithMessageByWriter(int id);
        Message2 GetMessageIncludeSender(int id);
    }
}
