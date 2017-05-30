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
        private string mailMessage;
        private string mailReceiver;
        public MailManager(string mailMessage, string mailReceiver)
        {
            this.mailMessage = mailMessage;
            this.mailReceiver = mailReceiver;
        }

        public async void SendMail()
        {
            EmailMessage emailMessage = new EmailMessage();
            emailMessage.To.Add(new EmailRecipient(mailReceiver));
            emailMessage.Body = mailMessage;
            //StorageFolder MyFolder = Windows.ApplicationModel.Package.Current.InstalledLocation;
            //StorageFile attachmentFile = await MyFolder.GetFileAsync("MyTestFile.txt");
            //if (attachmentFile != null)
            //{
            //    var stream = Windows.Storage.Streams.RandomAccessStreamReference.CreateFromFile(attachmentFile);
            //    var attachment = new Windows.ApplicationModel.Email.EmailAttachment(
            //             attachmentFile.Name,
            //             stream);
            //    emailMessage.Attachments.Add(attachment);
            //}
            await EmailManager.ShowComposeNewEmailAsync(emailMessage);
        }
    }
}
