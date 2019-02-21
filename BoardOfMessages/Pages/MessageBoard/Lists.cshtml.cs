using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AddMessages.core;
using ListOfMessages.data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace BoardOfMessages.Pages.MessageBoard
{
    public class ListsModel : PageModel
    {
        private readonly IConfiguration config;
        private readonly IListsData messageData;

        [BindProperty]
        public String Message { get; set; }
        public IEnumerable<MessageB> Messages { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Search { get; set; }

        public ListsModel(IConfiguration config, IListsData messageData)
        {
            this.config = config;
            this.messageData = messageData;
        }
        public void OnGet()
        {
            Message = config["message"];
            Messages = messageData.GetMessagesByName(Search);
        }
        //public IActionResult OnPost(int id)
        //{
        //   // var message = message.Single
        //    var Like = messageData.AddLike(id);
        //    messageData.Commit();
        //    return RedirectToPage("./Lists");
        //}
    }
}