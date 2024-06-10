using System.ComponentModel.DataAnnotations;

namespace LoanApplicationPortal.Enums
{
    public enum ReviewLoanApplication
    {
        [Display(Name = "Approved")]
        Approved,
        [Display(Name = "Declined")]
        Declined,
        [Display(Name = "In Progress")]
        InProgress
    }
}
