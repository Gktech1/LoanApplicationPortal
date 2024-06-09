using LoanApplicationPortal.Utilities;
using System.ComponentModel.DataAnnotations;

public class LoanApplication
{
    public int Id { get; set; }

    [Required, StringLength(20, MinimumLength = 2)]
    public string Name { get; set; }

    [Required]
    public string Address { get; set; }

    [Required, DataType(DataType.Date)]
    [CustomValidation(typeof(Utility), nameof(Utility.ValidateAge))]
    public DateTime DateOfBirth { get; set; }

    [Required, EmailAddress]
    public string Email { get; set; }

    [Required]
    public bool HomeOwner { get; set; } 

    [Required(ErrorMessage = "Loan Request Amount is required."), Range(20000, 50000)]
    [Display(Name = "Loan Request Amount")]
    public decimal LoanRequestAmount { get; set; }

    public string Status { get; set; } = "In Progress";

}