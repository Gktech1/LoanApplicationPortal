using LoanApplicationPortal.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Globalization;
using System.Threading.Tasks;

namespace LoanApplicationPortal.Pages
{
    public class ApplyModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        [BindProperty]
        public LoanApplication LoanApplication { get; set; }

        [BindProperty]
        public string LoanRequestAmountString { get; set; }

        public ApplyModel(ApplicationDbContext context)
        {
            _context = context;
        }

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
                _context.LoanApplications.Add(LoanApplication);
                await _context.SaveChangesAsync();

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
