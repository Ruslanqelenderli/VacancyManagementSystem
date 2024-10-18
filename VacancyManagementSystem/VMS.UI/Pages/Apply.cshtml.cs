using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using VMS.BUSINESS.Abstract;
using VMS.BUSINESS.Helpers.Models.Request.ApplicationInfo;

namespace VMS.UI.Pages
{
    public class ApplyModel : PageModel
    {
        private readonly IApplicationInfoService applicationInfoService;
        public ApplyModel(IApplicationInfoService applicationInfoService)
        {
            this.applicationInfoService = applicationInfoService;
        }
        [BindProperty]
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Surname is required.")]
        public string Surname { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }

        [BindProperty]

        [Required(ErrorMessage = "Phone number is required.")]
        [Phone(ErrorMessage = "Invalid phone number.")]
        public string PhoneNumber { get; set; }
        [BindProperty]
        public string VacancyId { get; set; }


        public void OnGet(string vacancyId)
        {
            this.VacancyId = vacancyId;
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var result = await applicationInfoService.ApplyCreateAsync(new ApplicationInfoCreateRequest(Name,Surname,Email,PhoneNumber,VacancyId));


            return RedirectToPage("/Exam", new { actionId = result.Value.Id });
        }
    }
}
