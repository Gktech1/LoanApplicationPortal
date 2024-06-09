using System.ComponentModel.DataAnnotations;

namespace LoanApplicationPortal.Utilities
{
    public static class Utility
    {
        public static ValidationResult ValidateAge(DateTime dateOfBirth, ValidationContext context)
        {
            var age = dateOfBirth.AddYears(18);
            if (age > DateTime.Now)
            {
                return new ValidationResult("Applicant must be at least 18 years old.");
            }
            return ValidationResult.Success;
        }
    }
}
