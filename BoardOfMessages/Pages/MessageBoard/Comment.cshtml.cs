using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AddMessages.core;
using ListOfMessages.data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BoardOfMessages.Pages.MessageBoard
{
    public class CommentModel : PageModel
    {
        private readonly IListsData listsData;
        [BindProperty]
        public MessageB message { get; set; }

        public CommentModel(IListsData listsData)
        {
            this.listsData = listsData;
        }
        public IActionResult OnGet(int messageId)
        {
            //message = listsData.GetById(id);
            message = listsData.GetById(messageId);
            if (message == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }
        public IActionResult OnPost()
        {
            //    switch (forCase)
            //    {
            //        case "forComment":
            if (ModelState.IsValid)
                    {
                        listsData.Update(message);
                        listsData.Commit();
                        return RedirectToPage("./Details", new { messageId = message.Id });
                    }
                //    break;
                //case "forLike":
                    message.Like += 1;
                    listsData.Update(message);
                    listsData.Commit();
            //        break;
            //}
            return Page();
        }
    }
}
