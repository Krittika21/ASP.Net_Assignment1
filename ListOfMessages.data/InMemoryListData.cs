using AddMessages.core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ListOfMessages.data
{
    public class InMemoryListData : IListsData
    {
        List<MessageB> messages;
        public InMemoryListData()
        {
            messages = new List<MessageB>();
        }
        public MessageB GetById(int id)
        {
            return messages.SingleOrDefault(m => m.Id == id);
        }
        public MessageB Add(MessageB newMessageB)
        {
            messages.Add(newMessageB);
            newMessageB.Id = messages.Max(m => m.Id) + 1;
            return newMessageB;
        }
        public MessageB Update(MessageB addComment)
        {
            var message = messages.SingleOrDefault(m => m.Id == addComment.Id);

            if (message != null)
            {
                addComment.comment = message.comment + addComment.comment;
            }
            return message;
        }
        public int Commit()
        {
            return 0;
        }

        public IEnumerable<MessageB> GetMessagesByName(string name = null)
        {
            //return messages;
            return from m in messages
                   where string.IsNullOrEmpty(name) || m.Name.StartsWith(name)
                   orderby m.Name
                   select m;
        }

        public int AddLike(int id)
        {
            return id;
        }

        //int IListsData.AddLike(int id)
        //{
        //    var me = messages.FirstOrDefault(m => m.Id == id);
        //    { MessageB}.me /{ }/{ id};
        //    var me = GetById(id);
        //    me.Like = me.Like + 1;
        //    return me.Like;
        //}
    }
}
