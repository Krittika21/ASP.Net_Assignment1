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
    public class AddNewModel : PageModel
    {
        private readonly IListsData listsData;
        [BindProperty]
        public MessageB message { get; set; }
        public AddNewModel(IListsData listsData)
        {
            this.listsData = listsData;
        }
        public IActionResult OnGet(int? messageId)
        {
            if (messageId.HasValue)
            {
                message = listsData.GetById(messageId.Value);
            }
            else
            { 
                message = new MessageB();
            }
            if (message == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                listsData.Add(message);
                listsData.Commit();
                return RedirectToPage("./Lists", new { messageId = message.Id });
            }
            
            return Page();
        }
    }
}