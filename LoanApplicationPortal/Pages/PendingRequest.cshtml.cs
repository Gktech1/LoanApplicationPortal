using LoanApplicationPortal.Data;
using LoanApplicationPortal.Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace LoanApplicationPortal.Pages
{
    public class PendingRequestModel(ILoanApplicationRepository loanApplicationRepo) : PageModel
    {
        private readonly ILoanApplicationRepository _loanApplicationRepo = loanApplicationRepo;

        public IList<LoanApplication> LoanApplications { get; set; }

        public async Task OnGetAsync()
        {
            LoanApplications = await _loanApplicationRepo.GetLoanApplicationInProgress();
        }

        public async Task<IActionResult> OnPostUpdateStatusAsync(int id, string status)
        {
            var application = await _loanApplicationRepo.GetLoanApplication(id);
            if (application == null)
            {
                return NotFound();
            }

            application.Status = status;
            application.AdminActionAt = DateTime.Now;

            await _loanApplicationRepo.UpdateLoanApplicationStatus(id, status); 

            return RedirectToPage();
        }
    }
}
