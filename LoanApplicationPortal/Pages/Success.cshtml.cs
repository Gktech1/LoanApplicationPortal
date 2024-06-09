using LoanApplicationPortal.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LoanApplicationPortal.Pages
{
    public class SuccessModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public LoanApplication LoanApplication { get; set; }

        public decimal MonthlyRepayment { get; set; }
        public decimal TotalPayable { get; set; }

        public SuccessModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            LoanApplication = await _context.LoanApplications.FindAsync(id);

            if (LoanApplication == null)
            {
                return NotFound();
            }

            decimal interestRate = 0.15M;
            int term = 18;

            MonthlyRepayment = LoanApplication.LoanRequestAmount * interestRate / (1 - (decimal)Math.Pow((double)(1 + interestRate), -term));
            TotalPayable = MonthlyRepayment * term;

            return Page();
        }

    }
}
