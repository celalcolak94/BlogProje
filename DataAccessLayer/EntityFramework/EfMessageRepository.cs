using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.EntityFramework
{
    public class EfMessageRepository : GenericRepository<Message2>, IMessageDal
    {
        public List<Message2> GetListWithMessageByWriter(int id)
        {
            using (var db = new Context())
            {
                return db.Message2s.Include(x => x.SenderUser).Where(x => x.ReceiverId == id).ToList();
            }
        }

        public Message2 GetMessageIncludeSender(int id)
        {
            using (var db = new Context())
            {
                return db.Message2s.Include(x => x.SenderUser).FirstOrDefault(y => y.MessageId == id);
            }
        }
    }
}
