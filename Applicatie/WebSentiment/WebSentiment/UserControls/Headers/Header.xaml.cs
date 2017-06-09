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
using Windows.UI.Core;
// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace WebSentiment.UserControls.Header
{
    public sealed partial class Header : UserControl
    {
        private Page pageUserControl;
        private Category category;
        private Classes.Page page;
        public Header(Page pageUserControl, Category category, Classes.Page page)
        {
            this.InitializeComponent();
            this.pageUserControl = pageUserControl;
            this.category = category;
            this.page = page;
            Load();
        }

        private void Load()
        {
            LblPageName.Text = page.pageTitle;
            if (category.categoryID > 1)
            {
                ImgHome.Source = new BitmapImage(new Uri("ms-appx:///Images/Home.png", UriKind.Absolute));
            }
            else
            {
                ImgHome.Source = new BitmapImage(new Uri("ms-appx:///Images/WebSentiment-logo-icon.png", UriKind.Absolute));
            }
        }

        private void ImgHome_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (category.categoryID != 1)
            {
                pageUserControl.LoadPage(1);
            }
        }

        private void ImgContact_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (category.categoryID != 6)
            {
                pageUserControl.LoadPage(6);
            }
        }
    }
}

