using LoanApplicationPortal.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace LoanApplicationPortal.Pages
{
    public class PendingRequestModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public PendingRequestModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<LoanApplication> LoanApplications { get; set; }

        public async Task OnGetAsync()
        {
            LoanApplications = await _context.LoanApplications
                                              .Where(a => a.Status == "In Progress")
                                              .ToListAsync();
        }

        public async Task<IActionResult> OnPostUpdateStatusAsync(int id, string status)
        {
            var application = await _context.LoanApplications.FindAsync(id);
            if (application == null)
            {
                return NotFound();
            }

            application.Status = status;
            application.AdminActionAt = DateTime.Now;
            _context.Attach(application).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return RedirectToPage();
        }
    }
}
