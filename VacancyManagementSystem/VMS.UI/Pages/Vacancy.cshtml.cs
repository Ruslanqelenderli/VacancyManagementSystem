using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VMS.BUSINESS.Abstract;
using VMS.BUSINESS.Helpers.Models.Response.Vacancy;
using VMS.CORE.Helpers;

namespace VMS.UI.Pages
{
    public class VacancyModel : PageModel
    {
        private readonly IVacancyService vacancyService;
        public VacancyModel(IVacancyService vacancyService)
        {
            this.vacancyService = vacancyService;
        }
        public int PageSize { get; set; } =5;
        public int TotalCount { get; set; }
        public int TotalPage { get; set; }
        public List<VacancyCommonResponse> Vacancies { get; set; }
        public int CurrentPage { get; set; }
        public async Task OnGet(int pageNumber = 1)
        {
            this.CurrentPage = pageNumber;
            var result = await vacancyService.GetByPagingOutAsync(new PageRequest<object>()
            {
                PageSize = PageSize,
                CurrentPage = CurrentPage
            });
            this.Vacancies = result.List;
            this.TotalCount = result.TotalCount;
            this.TotalPage = TotalCount % this.PageSize == 0 ? TotalCount / this.PageSize : TotalCount / this.PageSize + 1;
        }
    }
}
