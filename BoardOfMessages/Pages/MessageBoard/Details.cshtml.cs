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
    public class DetailsModel : PageModel
    {
        private readonly IListsData listsData;

        public MessageB messageD { get; set; }

        public DetailsModel(IListsData listsData)
        {
            this.listsData = listsData;
        }
        public IActionResult OnGet(int messageId)
        {
            messageD = listsData.GetById(messageId);
            if(messageD == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }
    }
}