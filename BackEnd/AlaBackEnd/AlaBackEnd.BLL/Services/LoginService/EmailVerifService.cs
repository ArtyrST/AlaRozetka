using AlaBackEnd.DAL.Entity.Users;
using AlaBackEnd.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MimeKit;
using MailKit.Net.Smtp;
using MailKit.Security;


namespace AlaBackEnd.BLL.Services.LoginService
{
    public class EmailVerifService
    {
        private readonly IConfiguration _config;
        private readonly EmailCodeRepository _code;
        public EmailVerifService(IConfiguration config, EmailCodeRepository code)
        {
            _config = config;
            _code = code;
        }

        public async Task<ServiceResponse> SendOtpAsync(string email)
        {
            var code = new Random().Next(100000, 999999).ToString();

            var otp = new EmailCodeEntity
            {
                Email = email,
                Code = code,
                IsUsed = false,
                Timer = DateTime.UtcNow.AddMinutes(10)
            };

            await _code.CreateAsync(otp);

            await SendAsync(email, "Your code", $"Code: {code}");
            return ServiceResponse.Success("Code sent", null);
        }
        public async Task<bool> VerifyAsync(string email, string code)
        {
            var otp = await _code.GetAll()
                .Where(c => c.Email == email
                    && c.Code == code
                    && !c.IsUsed
                    && c.Timer > DateTime.UtcNow)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            if (otp == null)
            {
                return false;
            }
            if (otp.UsingCount > 5)
            {
                return false;
            }
            otp.UsingCount++;

            otp.IsUsed = true;
            await _code.UpdateAsync(otp);

            object response = new { email, code };

            return true;

        }

        private async Task SendAsync(string to, string subject, string body)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("EasyStay", _config["EmailSettings:Email"]));
            message.To.Add(new MailboxAddress("", to));
            message.Subject = subject;
            message.Body = new TextPart("plain") { Text = body };

            using var client = new MailKit.Net.Smtp.SmtpClient();
            await client.ConnectAsync(_config["EmailSettings:Host"], 587, SecureSocketOptions.StartTls);
            await client.AuthenticateAsync(_config["EmailSettings:Email"], _config["EmailSettings:Password"]);
            await client.SendAsync(message);
            await client.DisconnectAsync(true);

        }
    }
}
