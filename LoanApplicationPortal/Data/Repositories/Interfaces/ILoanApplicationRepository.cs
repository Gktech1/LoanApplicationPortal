namespace LoanApplicationPortal.Data.Repositories.Interfaces
{
    public interface ILoanApplicationRepository
    {
        Task<LoanApplication> GetLoanApplication(int id);
        Task<IList<LoanApplication>> GetLoanApplications(string status);
        Task<IList<LoanApplication>> GetLoanApplicationDeclined();
        Task<IList<LoanApplication>> GetLoanApplicationApproved();
        Task<IList<LoanApplication>> GetLoanApplicationInProgress();
        Task CreateLoanApplication(LoanApplication application);
        Task UpdateLoanApplicationStatus(int id, string status);        
    }
}