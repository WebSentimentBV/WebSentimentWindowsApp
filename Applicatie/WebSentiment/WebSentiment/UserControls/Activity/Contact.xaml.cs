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

        private void btnSendMail_Click(object sender, RoutedEventArgs e)
        {
            MailManager mailManager = new MailManager("TEST", "CtarikC@hotmail.com");
            mailManager.SendMail();
            tbMessage.Text = "Verzonden :)";
        }
    }
}
