using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VMS.BUSINESS.Abstract;
using VMS.BUSINESS.Helpers.Models.Response.Action;
using VMS.BUSINESS.Helpers.Models.Response.Vacancy;
using VMS.CORE.Helpers;

namespace VMS.UI.Pages
{
    public class ActionModel : PageModel
    {
        private readonly IActionService actionService;
        public ActionModel(IActionService actionService)
        {
            this.actionService = actionService;
        }
        public int PageSize { get; set; } = 5;
        public int TotalCount { get; set; }
        public int TotalPage { get; set; }
        public List<ActionPagingResponse> Actions { get; set; }
        public int CurrentPage { get; set; }
        public async Task OnGet(int pageNumber = 1)
        {
            this.CurrentPage = pageNumber;
            var result = await actionService.GetByPagingAsync(new PageRequest<object>()
            {
                PageSize = PageSize,
                CurrentPage = CurrentPage
            });
            this.Actions = result.List;
            this.TotalCount = result.TotalCount;
            this.TotalPage = TotalCount % this.PageSize == 0 ? TotalCount / this.PageSize : TotalCount / this.PageSize + 1;
        }
    }
}
