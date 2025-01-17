﻿using System;
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
using System.Text.RegularExpressions;

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
            LblTextOne.Text = page.pageTextOne.Replace(@"\n", "\n");
            LblTextTwo.Text = page.pageTextTwo;
        }

        private void SendMail()
        {
            //Take the input and send it to the next window (mail window).
            string senderName = tbName.Text;
            string senderMail = tbMail.Text;
            string senderPhone = tbPhone.Text;
            string mailSubject = "Contact bericht van " + senderName + " via de Windowsapplicatie";
            string mailMessage = tbMessage.Text + "\n\nMet vriendelijke groet, \n" + senderName + " \n" + senderMail + " \n" + senderPhone;
            MailManager mailManager = new MailManager(mailSubject, mailMessage, "nigel@websentiment.nl");
            mailManager.SendMail();
            FieldsCleaner(false, true);
        }
        private async void BtnSendMail_Click(object sender, RoutedEventArgs e)
        {
            //Clean the input, so that the user doesnt send it again.
            FieldsCleaner(true, false);
            //Check the fields if the input is right
            if (FieldsChecker())
            {
                var dialog = new Windows.UI.Popups.MessageDialog(
                "Uw bericht wordt verstuurd in het volgende scherm.",
                "Ga door naar het volgende scherm.");
                dialog.Commands.Add(new UICommand("Doorgaan", new UICommandInvokedHandler(this.CommandInvokedHandler)));
                await dialog.ShowAsync();
            }
        }

        private void CommandInvokedHandler(IUICommand command)
        {
            if (command.Label == "Doorgaan")
            {
                SendMail();
            }
        }
        private void FieldsCleaner(bool bLabels, bool bTextBoxes)
        {
            if (bLabels)
            {
                lblName.Text = "";
                lblMail.Text = "";
                lblPhone.Text = "";
                lblMessage.Text = "";
            }
            if (bTextBoxes)
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
            if (nameInput.Count() < 2 || nameInput.Count() > 25)
            {
                lblName.Text = "Uw naam moet 2-25 letters bevatten.";
                return false;
            }

            return true;
        }
        private bool CheckMail()
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(tbMail.Text);
            if (!match.Success)
            {
                lblMail.Text = "Dit is geen geldig e-mailadres.";
                return false;
            }

            string mailInput = tbMail.Text;
            if (mailInput.Count() < 6 || mailInput.Count() > 60)
            {
                lblMail.Text = "Uw mail moet 6-60 karakters bevatten.";
                return false;
            }
            return true;
        }
        private bool CheckPhone()
        {
            double phoneNumber;
            string phoneInput = tbPhone.Text;
            if (phoneInput.Count() >= 10 && phoneInput.Count() <= 15)
            {
                if (!double.TryParse(phoneInput, out phoneNumber))
                {
                    lblPhone.Text = "Uw nummer kan alleen bestaan uit cijfers.";
                    return false;
                }
            }
            else
            {
                lblPhone.Text = "Uw nummer moet 10-15 cijfers bevatten.";
                return false;
            }
            return true;
        }
        private bool CheckMessage()
        {
            string messageInput = tbMessage.Text;
            if (messageInput.Count() < 10 || messageInput.Count() > 1000)
            {
                lblMessage.Text = "Uw bericht moet 10-1000 karakters bevatten.";
                return false;
            }
            return true;
        }

        private void LblTextTwo_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Windows.ApplicationModel
            .Calls.PhoneCallManager
            .ShowPhoneCallUI("0634574130", "Nigel Severing");
        }
    }
}
