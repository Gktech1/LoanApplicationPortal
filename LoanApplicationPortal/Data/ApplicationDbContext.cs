using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace LoanApplicationPortal.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<LoanApplication> LoanApplications { get; set; }
    }
}
