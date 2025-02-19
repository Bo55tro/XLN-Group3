﻿using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Configuration;

public class EmailService
{
    private readonly IConfiguration _configuration;

    public EmailService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task SendEmailAsync(string toEmail, string subject, string body)
    {
        var smtpSettings = _configuration.GetSection("SmtpSettings");

        var smtpClient = new SmtpClient
        {
            Host = smtpSettings["Server"],
            Port = int.Parse(smtpSettings["Port"]),
            EnableSsl = bool.Parse(smtpSettings["UseSsl"]),
            Credentials = new NetworkCredential(smtpSettings["Username"], smtpSettings["Password"])
        };

        var mailMessage = new MailMessage
        {
            From = new MailAddress(smtpSettings["Username"]),
            Subject = subject,
            Body = body,
            IsBodyHtml = true
        };

        mailMessage.To.Add(toEmail);

        await smtpClient.SendMailAsync(mailMessage);
    }
}


