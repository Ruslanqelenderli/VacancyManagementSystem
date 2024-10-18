using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VMS.BUSINESS.Abstract;
using VMS.BUSINESS.Helpers.Models.Response.Question;
using VMS.ENTITY.Entities.Application;

namespace VMS.UI.Pages
{
    public class ExamModel : PageModel
    {
        private readonly IQuestionService questionService;
        public ExamModel(IQuestionService questionService)
        {
            this.questionService = questionService;

        }
        [BindProperty]

        public List<QuestionGetByActionIdResponse> Questions { get; set; }
        public int TimeLimit { get; set; }
        [BindProperty]
        public string ActionId { get; set; }

        [BindProperty]
        public int SelectedCount { get; set; } = 0;


        public async Task OnGet(string actionId)
        {
            var result = await questionService.GetByActionIdAsync(actionId);
            Questions = result.List;
            TimeLimit = Questions.Count * 60;
            ActionId = actionId;
        }

        public void OnPost()
        {

        }
    }

}
