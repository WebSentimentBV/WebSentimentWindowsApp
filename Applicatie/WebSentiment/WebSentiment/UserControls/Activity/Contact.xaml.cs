using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using WebSentiment.Classes;
using Windows.UI.Popups;
using System.ComponentModel.DataAnnotations;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace WebSentiment.UserControls.Activity
{
    public sealed partial class Contact : UserControl
    {
        Classes.Page page;
        public Contact(Classes.Page page)
        {
            this.InitializeComponent();
            this.page = page;
            Init();
        }

        private void Init()
        {
            lblTextOne.Text = page.pageTextOne;
            lblTextTwo.Text = page.pageTextTwo;

        }

        private void SendMail()
        {
            string mailMessage = tbMessage.Text += "\n\nMet vriendelijke groet, \n" + tbName.Text + " \n" + tbPhone.Text; 
         MailManager mailManager = new MailManager(tbMessage.Text, "nigel@websentiment.nl");
        mailManager.SendMail();
            FieldsCleaner(false, true);
        }
        private async void btnSendMail_Click(object sender, RoutedEventArgs e)
        {
            FieldsCleaner(true, false);
            if (FieldsChecker())
            {
                var dialog = new Windows.UI.Popups.MessageDialog(
                "Uw bericht wordt verstuurd in het volgende scherm.",
                "Ga door naar het volgende scherm.");
                dialog.Commands.Add(new UICommand(
        "Doorgaan", new UICommandInvokedHandler(this.CommandInvokedHandler)));
                await dialog.ShowAsync();
            }
        }

        private void CommandInvokedHandler(IUICommand command)
        {
            // Display message showing the label of the command that was invoked
            if(command.Label == "Doorgaan")
            {
                SendMail();
            }
        }
        private void FieldsCleaner(bool bLabels, bool bTextBoxes)
        {
            if( bLabels)
            {
                lblName.Text = "";
                lblMail.Text = "";
                lblPhone.Text = "";
                lblMessage.Text = "";
            }
            if(bTextBoxes)
            {
                tbName.Text = "";
                tbMail.Text = "";
                tbPhone.Text = "";
                tbMessage.Text = "";
            }

        }

        private bool FieldsChecker()
        {
            bool boolCorrect = true;
            if (!CheckName())
            {
                boolCorrect = false;
            }
            if (!CheckMail())
            {
                boolCorrect = false;
            }
            if (!CheckPhone())
            {
                boolCorrect = false;
            }
            if (!CheckMessage())
            {
                boolCorrect = false;
            }
            return boolCorrect;
        }

        private bool CheckName()
        {
            string nameInput = tbName.Text;
            if (nameInput.Any(char.IsDigit))
            {
                lblName.Text = "Uw naam kan alleen bestaan uit letters.";
                return false;
            }
            if(nameInput.Count() >= 2 && nameInput.Count() <= 25)
            {
            }
            else
            {
                lblName.Text = "Uw naam moet minstens 2 en maximaal 25 letters bevatten.";
                return false;
            }
            return true;
        }
        private bool CheckMail()
        {
            var eAA = new EmailAddressAttribute();
            if(!eAA.IsValid(tbMail.Text))
            {
                lblMail.Text = "Dit is geen geldig e-mailadres.";
                return false;
            }
            return true;
        }
        private bool CheckPhone()
        {
            int phoneNumber;
            string phoneInput = tbPhone.Text;
            if (!int.TryParse(phoneInput, out phoneNumber))
            {
                lblPhone.Text = "Uw telefoonnummer kan alleen bestaan uit cijfers.";
                return false;
            }
            if (phoneInput.Count() >= 10 && phoneInput.Count() <= 15)
            {
            }
            else
            {
                lblPhone.Text = "Uw telefoonnummer moet minstens 10 en maximaal 15 cijfers bevatten.";
                return false;
            }
            return true;
        }
        private bool CheckMessage()
        {
            string messageInput = tbMessage.Text;
            if (messageInput.Count() >= 10 && messageInput.Count() <= 1000)
            {
            }
            else
            {
                lblMessage.Text = "Uw bericht moet minstens 10 en maximaal 1000 karakters bevatten.";
                return false;
            }
            return true;
        }
    }
}
