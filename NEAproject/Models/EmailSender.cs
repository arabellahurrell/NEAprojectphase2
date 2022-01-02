using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace NEAproject.Models
{
    public class EmailSender
    {
        public static bool sendtestemail(string emailaddress, string message,string subject
            )
        {
            SmtpClient smtpserver = new SmtpClient();
            smtpserver.Host = "smtp.gmail.com";
            smtpserver.Port= 587;
            smtpserver.EnableSsl = true;
            smtpserver.UseDefaultCredentials = false;
            smtpserver.Credentials = new NetworkCredential("belh2808", "Privet123!"); //replace later
            smtpserver.DeliveryMethod = SmtpDeliveryMethod.Network;
            var mail = new MailMessage();
            try
            {
                mail.From = new MailAddress("belh2808@gmail.com", "arabella hurrell", System.Text.Encoding.UTF8);
                mail.To.Add(emailaddress);
                mail.Subject = subject;
                mail.Body = message;
                smtpserver.Send(mail);
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }

        }
    }
}
