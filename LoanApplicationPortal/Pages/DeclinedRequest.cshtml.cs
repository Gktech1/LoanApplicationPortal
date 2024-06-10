using LoanApplicationPortal.Data;
using LoanApplicationPortal.Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace LoanApplicationPortal.Pages
{
    public class DeclinedRequestModel(ILoanApplicationRepository loanApplicationRepo) : PageModel
    {
        private readonly ILoanApplicationRepository _loanApplicationRepo = loanApplicationRepo;

        public IList<LoanApplication> LoanApplications { get; set; }
        public async Task OnGetAsync()
        {
            LoanApplications = await _loanApplicationRepo.GetLoanApplicationDeclined(); 
        }
    }
}
