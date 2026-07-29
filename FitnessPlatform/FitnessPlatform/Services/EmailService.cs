using FitnessPlatform.Configurations;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;

namespace FitnessPlatform.Services
{
    public class EmailService
    {
        private readonly EmailSettings _emailSettings;

        public EmailService(IOptions<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }

        public async Task SendEmailAsync(string toEmail, string subject, string body)
        {
            // المرحلة الأولى: إنشاء وتجهيز كائن الرسالة (MimeMessage)
            var email = new MimeMessage();
            // تحديد بريد المُرسِل (بريد النظام) المجلوب من الإعدادات
            email.From.Add(MailboxAddress.Parse(_emailSettings.Email));
            // تحديد بريد المُستقبِل (العضو/المستخدم)
            email.To.Add(MailboxAddress.Parse(toEmail));
            // تحديد عنوان/موضوع الرسالة
            email.Subject = subject;

            email.Body = new TextPart("plain")
            {
                Text = body
            };
            // المرحلة الثانية: الاتصال بسيرفر البريد الإلكتروني (SMTP) والإرسال
            using var smtp = new SmtpClient();

            await smtp.ConnectAsync(_emailSettings.Host, _emailSettings.Port, MailKit.Security.SecureSocketOptions.StartTls);

            await smtp.AuthenticateAsync(_emailSettings.Email, _emailSettings.Password);

            await smtp.SendAsync(email);

            await smtp.DisconnectAsync(true);
        }
    }
}