using LoanApplicationPortal.Data;
using LoanApplicationPortal.Data.Repositories.Implementations;
using LoanApplicationPortal.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LoanApplicationPortal
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
                new MySqlServerVersion(new Version(8, 0, 37))));

            builder.Services.AddScoped<ILoanApplicationRepository, LoanApplicationRepository>();


            builder.Services.AddRazorPages();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            // Ensure routing to /Apply works
            app.MapGet("/", async context =>
            {
                context.Response.Redirect("/Apply");
                await Task.CompletedTask;
            });

            app.Run();
        }
    }
}
