using Burger.DATA.Concrete;
using Microsoft.AspNetCore.Hosting;
using System.Net.Mail;
using System.Net;
using Burger.WEBUI.Models.VMs;

namespace Burger.WEBUI.HelperClass
{
    public static class Helper
    {
        public static string AddPhoto(IFormFile file, IWebHostEnvironment _webHostEnvironment)
        {
            string uploadFolder = Path.Combine(_webHostEnvironment.WebRootPath, "burgerImages");
            string uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(file.FileName);
            string filePath = Path.Combine(uploadFolder, uniqueFileName);

            using (var filestream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(filestream);
            }

            string relativeFilePath = Path.Combine("/burgerImages", uniqueFileName);
            return relativeFilePath;
        }

        public static void SendMail(AppUser user, CreateUserVm vm,int confirmationCode)
        {
            

            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("burgershop12@outlook.com", "BurgerShop");
            mail.To.Add(vm.Email);
            mail.Subject = "BurgerShop Doğrulama Kodu";
            mail.IsBodyHtml = true;
            mail.Body = "BurgerShop'a hoşgeldiniz. İşte doğrulama kodun: " + confirmationCode;

            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Port = 587;
            smtpClient.Host = "smtp.outlook.com";
            smtpClient.EnableSsl = true;
            smtpClient.Credentials = new NetworkCredential("burgershop12@outlook.com", "Admin..1234");

            smtpClient.Send(mail);
            smtpClient.Timeout = 100;
        }
    }
}
