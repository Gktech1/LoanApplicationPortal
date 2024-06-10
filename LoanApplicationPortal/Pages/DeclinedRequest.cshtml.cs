using LoanApplicationPortal.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace LoanApplicationPortal.Pages
{
    public class DeclinedRequestModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DeclinedRequestModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<LoanApplication> LoanApplications { get; set; }
        public async Task OnGetAsync()
        {
            LoanApplications = await _context.LoanApplications
                                              .Where(a => a.Status == "Declined")
                                              .ToListAsync();
        }
    }
}
