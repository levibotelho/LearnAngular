using System.Net.Mail;

namespace AngularTutorial.Web.Entities
{
    public static class Feedback
    {
        public static void SendMessage(string subject, string message)
        {
            var client = new SmtpClient
            {
                Port = 25,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Host = ConfigurationFacade.SmtpHost
            };
            var mail = new MailMessage(ConfigurationFacade.SmtpFromAddress, ConfigurationFacade.FeedbackToAddress)
            {
                Subject = subject,
                Body = message
            };
            client.Send(mail);
        }
    }
}