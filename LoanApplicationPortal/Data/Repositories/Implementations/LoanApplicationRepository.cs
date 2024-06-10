using LoanApplicationPortal.Data.Repositories.Interfaces;
using LoanApplicationPortal.Enums;
using Microsoft.EntityFrameworkCore;

namespace LoanApplicationPortal.Data.Repositories.Implementations
{
    public class LoanApplicationRepository(ApplicationDbContext context) : ILoanApplicationRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<LoanApplication> GetLoanApplication(int id)
        {
            return await _context.LoanApplications.FindAsync(id);
        }

        public async Task<IList<LoanApplication>> GetLoanApplications(string status)
        {
            return await _context.LoanApplications
                                 .Where(a => a.Status == status)
                                 .ToListAsync();
        }

        public async Task<IList<LoanApplication>> GetLoanApplicationDeclined()
        {
            var declinedStatus = await _context.LoanApplications
                                  .Where(a => a.Status == ReviewLoanApplication.Declined.ToString())
                                  .ToListAsync();
            return declinedStatus;
        }

        public async Task<IList<LoanApplication>> GetLoanApplicationApproved()
        {
            var approvedStatus = await _context.LoanApplications
                                  .Where(a => a.Status == ReviewLoanApplication.Approved.ToString())
                                  .ToListAsync();
            return approvedStatus;
        }

        public async Task<IList<LoanApplication>> GetLoanApplicationInProgress()
        {
            var inProgress = EnumHelper.GetDisplayValue(ReviewLoanApplication.InProgress);
            var pendingStatus = await _context.LoanApplications
                                  .Where(a => a.Status == inProgress)
                                  .ToListAsync();
            return pendingStatus;
        }

        public async Task CreateLoanApplication(LoanApplication application)
        {
            _context.LoanApplications.Add(application);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateLoanApplicationStatus(int id, string status)
        {
            var application = await _context.LoanApplications.FindAsync(id);
            if (application == null)
            {
                return;
            }

            application.Status = status;
            application.AdminActionAt = DateTime.Now;
            _context.Attach(application).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }


    }
}
