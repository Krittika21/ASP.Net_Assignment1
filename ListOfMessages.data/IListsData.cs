using AddMessages.core;
using System.Collections.Generic;
using System.Text;

namespace ListOfMessages.data
{
    public interface IListsData
    {
        IEnumerable<MessageB> GetMessagesByName(string name);
        MessageB GetById(int id);
        MessageB Update(MessageB addComment);
        MessageB Add(MessageB newMessageB);
        int AddLike(int id);
        int Commit();
    }
}
