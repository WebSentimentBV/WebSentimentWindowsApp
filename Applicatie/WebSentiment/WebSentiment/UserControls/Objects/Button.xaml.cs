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

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace WebSentiment.UserControls.Objects
{
    public sealed partial class Button : UserControl
    {
        //PROPERTIES
        private int pageOrderID;
        private string pageTitle;
        private Page pageUserControl;
        //CONSTRUCTOR
        public Button(Page pageUserControl, int pageOrderID, string pageTitle)
        {
            this.InitializeComponent();
            this.pageOrderID = pageOrderID;
            this.pageTitle = pageTitle;
            this.pageUserControl = pageUserControl;
            LoadButton();
        }

        private void LoadButton()
        {
            txtPageTitle.Text = pageTitle;
        }

        private void buttonGrid_Tapped(object sender, TappedRoutedEventArgs e)
        {
            pageUserControl.pageOrderID = pageOrderID;
            pageUserControl.LoadPage();
        }
    }
}
