using LeaveManagement.WebApp.Data.Entities;
using LeaveManagement.WebApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Net.Mail;
using System.Threading.Tasks;

namespace LeaveManagement.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<Employee> _userManager;

        public HomeController(ILogger<HomeController> logger, UserManager<Employee> userManager)
        {
            _logger = logger;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [TempData]
        public string StatusMessage { get; set; }

        public bool IsValidEmail(string email)
        {
            return new EmailAddressAttribute().IsValid(email);
        }

        public async Task<IActionResult> ForgotPasswordAsync(string email)
        {
            if (email == null || email == "")
            {
                StatusMessage = "Error: Email can not be null";
                return Redirect("/Identity/Account/Login");
            }
            if (!IsValidEmail(email))
            {
                StatusMessage = "Error: Email is not valid";
                return Redirect("/Identity/Account/Login");
            }

            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                StatusMessage = "Error: Email is not exist";
                return Redirect("/Identity/Account/Login");
            }

            MailMessage mail = new MailMessage();
            mail.To.Add(email);
            mail.From = new MailAddress("trinh6299@gmail.com");
            mail.Subject = "[Leave Management] Recovery Password";
            Random _random = new Random();
            var newPassword = _random.Next(100000, 999999);
            string Body = "Your new password is: " + newPassword;
            mail.Body = Body;
            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential("trinh6299@gmail.com", "GM@thangpro9xxx"); // Enter seders User name and password
            smtp.EnableSsl = true;
            smtp.Send(mail);

            await SetPassword(user, newPassword.ToString());

            StatusMessage = "New password was changed and sended to your email";
            return Redirect("/Identity/Account/Login");
        }

        public async Task SetPassword(Employee user, string newPassword)
        {
            await _userManager.RemovePasswordAsync(user);
            await _userManager.AddPasswordAsync(user, newPassword);
        }
    }
}