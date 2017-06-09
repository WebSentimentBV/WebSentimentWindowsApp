using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Email;
using Windows.Storage;

namespace WebSentiment.Classes
{
    class MailManager
    {
        private string mailSubject;
        private string mailMessage;
        private string mailReceiver;
        public MailManager(string mailSubject, string mailMessage, string mailReceiver)
        {
            this.mailSubject = mailSubject;
            this.mailMessage = mailMessage;
            this.mailReceiver = mailReceiver;
        }

        public async void SendMail()
        {
            EmailMessage emailMessage = new EmailMessage();
            emailMessage.To.Add(new EmailRecipient(mailReceiver));
            emailMessage.Subject = mailSubject;
            emailMessage.Body = mailMessage;
            await EmailManager.ShowComposeNewEmailAsync(emailMessage);
        }
    }
}
