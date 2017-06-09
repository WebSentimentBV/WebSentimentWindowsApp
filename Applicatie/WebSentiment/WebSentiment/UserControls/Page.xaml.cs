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
using WebSentiment.UserControls;
using Windows.UI.Core;
using System.Diagnostics;
using Windows.Phone.UI.Input;
using Windows.ApplicationModel.Core;


// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace WebSentiment.UserControls
{
    public sealed partial class Page : UserControl
    {

        public Category category { get; set; }
        public Classes.Page page { get; set; }
        List<int> pageHistoryList;
        public Page()
        {
            this.InitializeComponent();
            category = new Category();
            page = new Classes.Page();
            pageHistoryList = new List<int>();
            category.categoryID = 1;
            LoadPage(category.categoryID);
            SystemNavigationManager.GetForCurrentView().BackRequested += OnBackRequested;
        }

    private void OnBackRequested(object sender, BackRequestedEventArgs e)
        {
            string platform = Windows.System.Profile.AnalyticsInfo.VersionInfo.DeviceFamily;
            if (platform == "Windows.Desktop")
            {
                pageHistoryList.Remove(pageHistoryList.Last());
                LoadPage(pageHistoryList.Count);
                pageHistoryList.Remove(pageHistoryList.Last());
            }
            else if (platform == "Windows.Mobile")
            {
                //Frame rootFrame = Window.Current.Content as Frame;
                //e.Handled = true;
                //rootFrame.GoBack();
            }
        }

        public void ShowBackbutton(bool bShowBackButton)
        {
            if(bShowBackButton)
            {
                Windows.UI.Core.SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
               
            }
            else
            {
                Windows.UI.Core.SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Collapsed;
            }
           
        }
        public void LoadPage(int categoryID)
        {
            pageHistoryList.Add(category.categoryID);
            category.categoryID = categoryID;
            category.GetCategory();
            page.pageID = category.pageID;
            page.GetPage();

            LoadHeader();
            LoadActivity();
            if(category.categoryID != 1)
            {
                ShowBackbutton(true);
            }
            else
            {
                ShowBackbutton(false);
            }
           
        }

        public void LoadHeader()
        {
            SpHeader.Children.Clear();
            Header.Header pageHeader = new Header.Header(this, category, page);
            SpHeader.Children.Add(pageHeader);
        }

        public void LoadActivity()
        {
            SpActivity.Children.Clear();
            switch (page.pageType)
            {
                case "Menu":
                    {
                        SpActivity.Background = (SolidColorBrush)Application.Current.Resources["AppBackgroundWhite"];
                        Activity.Menu pageMenu = new Activity.Menu(this);
                        SpActivity.Children.Add(pageMenu);
                        break;
                    }
                case "SliderProjects":
                    {
                        SpActivity.Background = (SolidColorBrush)Application.Current.Resources["AppBackgroundWhite"];
                        Activity.SliderProjects pageSliderProjects = new Activity.SliderProjects();
                        SpActivity.Children.Add(pageSliderProjects);

                        break;
                    }
                case "Text":
                    {
                        SpActivity.Background = (SolidColorBrush)Application.Current.Resources["AppBackgroundWhite"];
                        Activity.Text pageText = new Activity.Text(page);
                        SpActivity.Children.Add(pageText);
                        break;
                    }
                case "Slider":
                    {
                        SpActivity.Background = (SolidColorBrush)Application.Current.Resources["AppBackgroundWhite"];
                        Activity.Slider pageSlider = new Activity.Slider();
                        SpActivity.Children.Add(pageSlider);
                        break;
                    }
                case "ImageText":
                    {
                        SpActivity.Background = (SolidColorBrush)Application.Current.Resources["AppBackgroundWhite"];
                        Activity.ImageText pageImageText = new Activity.ImageText(page);
                        SpActivity.Children.Add(pageImageText);
                        break;
                    }
                case "Contact":
                    {
                       SpActivity.Background  = (SolidColorBrush)Application.Current.Resources["AppBackgroundGrey"];
                        Activity.Contact pageContact = new Activity.Contact(page);
                        SpActivity.Children.Add(pageContact);
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }
    }
}
