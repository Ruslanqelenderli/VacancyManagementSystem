using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VMS.BUSINESS.Abstract;
using VMS.BUSINESS.Helpers.Models.Request.Action;

namespace VMS.UI.Pages
{
    public class CVModel : PageModel
    {
        private readonly IActionService actionService;
        public CVModel(IActionService actionService)
        {
            this.actionService = actionService;
        }
        [BindProperty]
        public IFormFile CvInput { get; set; }

        public string UploadedFilePath { get; private set; }
        [BindProperty]
        public string ActionId { get;  set; }

        public void OnGet(string actionId)
        {
            ActionId = actionId;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (CvInput == null || CvInput.Length == 0)
            {
                ModelState.AddModelError("CvInput", "No file uploaded.");
                return Page();
            }

            if (CvInput.Length > 5 * 1024 * 1024)
            {
                ModelState.AddModelError("CvInput", "File size cannot exceed 5MB.");
                return Page();
            }

            var extension = Path.GetExtension(CvInput.FileName).ToLower();
            if (extension != ".pdf" && extension != ".docx")
            {
                ModelState.AddModelError("CvInput", "Invalid file format. Please upload a PDF or DOCX file.");
                return Page();
            }
            var directory = Directory.GetCurrentDirectory();
            var uploads = Path.Combine(directory, "uploads");
            if (!Directory.Exists(uploads))
                Directory.CreateDirectory(uploads);

            var filePath = Path.Combine(uploads, CvInput.FileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await CvInput.CopyToAsync(stream);
            }
            await actionService.Complete(new ActionCompleteRequest(ActionId, filePath));
            UploadedFilePath = filePath;
            return Page(); 
        }
    }
}
