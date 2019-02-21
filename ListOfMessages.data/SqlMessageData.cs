using System.Collections.Generic;
using AddMessages.core;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ListOfMessages.data
{
    public class SqlMessageData : IListsData
    {
        private readonly MessageDbContext db;

        public SqlMessageData(MessageDbContext db)
        {
            this.db = db;
        }

        public MessageB Add(MessageB newMessageB)
        {
            db.Add(newMessageB);
            return newMessageB;
        }

        public int AddLike(int id)
        {

            return db.SaveChanges();
        }

        public int Commit()
        {
            return db.SaveChanges();
        }

        public MessageB GetById(int id)
        {
            return db.MessageBs.Find(id);
        }

        public IEnumerable<MessageB> GetMessagesByName(string name)
        {
            var query = from m in db.MessageBs
                        where m.Name.StartsWith(name) || string.IsNullOrEmpty(name)
                        orderby m.Name
                        select m;
            return query;
        }

        public MessageB Update(MessageB addComment)
        {
            var entity = db.MessageBs.Attach(addComment);
            entity.State = EntityState.Modified;
            return addComment;
        }
    }
}
