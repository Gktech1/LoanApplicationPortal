using LoanApplicationPortal.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace LoanApplicationPortal.Pages
{
    public class ApprovedRequestModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public ApprovedRequestModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<LoanApplication> LoanApplications { get; set; }
        public async Task OnGetAsync()
        {
            LoanApplications = await _context.LoanApplications
                                              .Where(a => a.Status == "Approved")
                                              .ToListAsync();
        }
    }
}
