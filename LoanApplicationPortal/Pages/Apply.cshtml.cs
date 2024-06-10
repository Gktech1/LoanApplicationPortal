using LoanApplicationPortal.Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Globalization;

namespace LoanApplicationPortal.Pages
{
    public class ApplyModel(ILoanApplicationRepository loanApplicationRepo) : PageModel
    {
        private readonly ILoanApplicationRepository _loanApplicationRepo = loanApplicationRepo;

        [BindProperty]
        public LoanApplication LoanApplication { get; set; }

        [BindProperty]
        public string LoanRequestAmountString { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            
            // Parse the LoanRequestAmount string into a decimal
            if (Decimal.TryParse(LoanRequestAmountString.Replace("₦", "").Replace(",", ""), NumberStyles.Currency, CultureInfo.InvariantCulture, out decimal amount))
            {
                // Assign the parsed decimal to the LoanApplication's LoanRequestAmount property
                LoanApplication.LoanRequestAmount = amount;

                // Add the loan application to the context and save changes
                await  _loanApplicationRepo.CreateLoanApplication(LoanApplication);

                // Redirect to the success page with the loan application ID
                return RedirectToPage("Success", new { id = LoanApplication.Id });
            }
            else
            {
                // Handle parsing error if the input is not a valid decimal
                ModelState.AddModelError(nameof(LoanRequestAmountString), "Please enter a valid Loan Request Amount.");
                return Page();
            }
        }
    }
}
