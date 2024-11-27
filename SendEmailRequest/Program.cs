using System;
using System.Net;
using System.Net.Mail;
//using OpenPop.Pop3;

class Program
{
    static void Main(string[] args)
    {

        SendEmail();
    }

    static void SendEmail()
    {

        string senderEmail = "pmohanraja3@gmail.com";
        string senderPassword = "";//senderPassword


        string recipientEmail = "pmohanraja3@gmail.com";


        SmtpClient client = new SmtpClient("smtp.gmail.com")
        {
            Port = 587,
            Credentials = new NetworkCredential(senderEmail, senderPassword),
            EnableSsl = true,          
        };
        string htmlBody = @"<p>Please review the request and click on one of the following buttons:</p>
                            <form method='post'>
                                <input type='hidden' name='email' value='" + recipientEmail + @"' />
                                <input type='submit' name='response' value='Accepted' />
                                <input type='submit' name='response' value='Rejected' />
                            </form>";

        MailMessage mailMessage = new MailMessage(senderEmail, recipientEmail)
        {
            Subject = "Request for information",
            IsBodyHtml = true,
            Body = htmlBody
        };

        try
        {
            client.Send(mailMessage);
            Console.WriteLine("Email sent successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to send email: {ex.Message}");
        }
    }
}
