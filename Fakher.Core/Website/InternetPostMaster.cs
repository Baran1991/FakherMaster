using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
using Fakher.Core.DomainModel;
using rComponents;

public static class InternetPostMaster
{
    public static MailAddress NoReply = new MailAddress("noreply@fakher.ac.ir", "Fakher College", Encoding.UTF8);
//    public static string SmtpServer = "85.185.142.244";
    public static string SmtpServer = "mail.fakher.ac.ir";
    public static string SmtpUsername = "noreply@fakher.ac.ir";
    public static string SmtpPassword = "ffbelux5";
//    public static string SmtpUsername = "admin@fakher.ac.ir";
//    public static string SmtpPassword = "81391512";

    public static void Send(MailAddress fromAddress, MailAddress[] toAddress, string subject, string message, bool isBodyHtml, bool selfBcc)
    {
        MailMessage email = CreateMailMessage(fromAddress, toAddress, subject, message, isBodyHtml, selfBcc);
        Send(email);
    }

    public static void SendAsync(MailAddress fromAddress, MailAddress[] toAddress, string subject, string message, bool isBodyHtml, bool selfBcc)
    {
        MailMessage email = CreateMailMessage(fromAddress, toAddress, subject, message, isBodyHtml, selfBcc);
        SendAsync(email);
    }

    private static MailMessage CreateMailMessage(MailAddress fromAddress, MailAddress[] toAddress, string subject,
                                                 string message, bool isBodyHtml, bool selfBcc)
    {
        MailMessage email = new MailMessage();
        foreach (MailAddress address in toAddress)
            email.To.Add(address);
        email.From = fromAddress;
        email.Sender = fromAddress;
        email.ReplyTo = fromAddress;
        if (selfBcc)
            email.Bcc.Add(fromAddress);
        email.Subject = subject;
        email.Body = message;
        email.SubjectEncoding = Encoding.UTF8;
        email.BodyEncoding = Encoding.UTF8;
        email.IsBodyHtml = isBodyHtml;
        return email;
    }

    public static void Send(MailMessage message)
    {
        SmtpClient client = new SmtpClient(SmtpServer);
        client.UseDefaultCredentials = false;
        client.Credentials = new NetworkCredential(SmtpUsername, SmtpPassword);
//        client.EnableSsl = true;
        client.Send(message);
    }

    public static void SendAsync(MailMessage message)
    {
//        SmtpClient client = new SmtpClient(SmtpServer, 587);
        SmtpClient client = new SmtpClient(SmtpServer);
        client.UseDefaultCredentials = false;
        client.Credentials = new NetworkCredential(SmtpUsername, SmtpPassword);
//        client.EnableSsl = true;
        client.SendAsync(message, new object());
    }
}
