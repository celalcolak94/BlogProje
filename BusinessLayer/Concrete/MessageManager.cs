using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class MessageManager : IMessageService
    {
        IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public Message2 GetById(int id)
        {
            return _messageDal.GetById(id);
        }

        public List<Message2> GetInboxListByWriter(int id)
        {
            return _messageDal.GetListWithMessageByWriter(id);
        }

        public List<Message2> GetList()
        {
            return _messageDal.GetListAll();
        }

        public Message2 GetMessageIncludeSenderUser(int id)
        {
            return _messageDal.GetMessageIncludeSender(id);
        }

        public void TAdd(Message2 t)
        {
            throw new NotImplementedException();
        }

        public void TDelete(Message2 t)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Message2 t)
        {
            throw new NotImplementedException();
        }
    }
}
