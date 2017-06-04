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
using Windows.UI.Xaml.Media.Imaging;
// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace WebSentiment.UserControls.Header
{
    public sealed partial class PageHeader : UserControl
    {
        private Page pageUserControl;
        private Category category;
        private Classes.Page page;
        public PageHeader(Page pageUserControl, Category category, Classes.Page page)
        {
            this.InitializeComponent();
            this.pageUserControl = pageUserControl;
            this.category = category;
            this.page = page;
            Load();
        }

        private void Load()
        {
            lblPageName.Text = page.pageTitle;
            if (category.categoryID > 1)
            {
                imgHome.Source = new BitmapImage(new Uri("ms-appx:///Images/Home.png", UriKind.Absolute));
            }
            else
            {
                imgHome.Source = new BitmapImage(new Uri("ms-appx:///Images/WebSentiment-logo-icon.png", UriKind.Absolute));
            }
        }

        private void imgHome_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (category.categoryID != 1)
            {
                pageUserControl.category.categoryID = 1;
                pageUserControl.LoadPage();
            }
        }

        private void imgContact_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (category.categoryID != 6)
            {
                pageUserControl.category.categoryID = 6;
                pageUserControl.LoadPage();
            }
        }
    }
}

