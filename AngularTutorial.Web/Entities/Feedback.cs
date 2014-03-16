using System.Configuration;
using System.Net;
using System.Net.Configuration;
using System.Net.Mail;

namespace AngularTutorial.Web.Entities
{
    public static class Feedback
    {
        public static void SendMessage(string subject, string message)
        {
            var smtpSection = (SmtpSection)ConfigurationManager.GetSection("system.net/mailSettings/smtp");
            var client = new SmtpClient
            {
                Credentials = new NetworkCredential(smtpSection.Network.UserName, smtpSection.Network.Password),
                DeliveryMethod = SmtpDeliveryMethod.Network
            };

            var mail = new MailMessage(new MailAddress(smtpSection.From, "learn-angular.org"), new MailAddress(ConfigurationFacade.FeedbackToAddress))
            {
                Subject = subject,
                Body = message
            };
            client.Send(mail);
        }
    }
}