using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VMS.BUSINESS.Abstract;
using VMS.BUSINESS.Helpers.Models.Response.Action;

namespace VMS.UI.Pages
{
    public class DetailModel : PageModel
    {
        private readonly IActionService actionService;
        public DetailModel(IActionService actionService)
        {
            this.actionService = actionService;  
        }
        [BindProperty]
        public  ActionGetByIdResponse Action { get; set; }
        public async Task OnGet(string actionId)
        {
            var result  = await actionService.GetByIdAsync(actionId);
            Action  = result.Value;
        }
    }
}
