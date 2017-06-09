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
            //pageHistoryList.Add(category.categoryID);
            LoadPage(category.categoryID);

            SystemNavigationManager.GetForCurrentView().BackRequested += OnBackRequested;
        }
        private void OnBackRequested(object sender, BackRequestedEventArgs e)
        {
            pageHistoryList.Remove(pageHistoryList.Last());
            LoadPage(pageHistoryList.Count);
            pageHistoryList.Remove(pageHistoryList.Last());
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
            spHeader.Children.Clear();
            Header.Header pageHeader = new Header.Header(this, category, page);
            spHeader.Children.Add(pageHeader);
        }

        public void LoadActivity()
        {
            spActivity.Children.Clear();
            switch (page.pageType)
            {
                case "Menu":
                    {
                        spActivity.Background = (SolidColorBrush)Application.Current.Resources["AppBackgroundWhite"];
                        Activity.Menu pageMenu = new Activity.Menu(this);
                        spActivity.Children.Add(pageMenu);
                        break;
                    }
                case "SliderProjects":
                    {
                        spActivity.Background = (SolidColorBrush)Application.Current.Resources["AppBackgroundWhite"];
                        Activity.SliderProjects pageSliderProjects = new Activity.SliderProjects();
                        spActivity.Children.Add(pageSliderProjects);

                        break;
                    }
                case "Text":
                    {
                        spActivity.Background = (SolidColorBrush)Application.Current.Resources["AppBackgroundWhite"];
                        Activity.Text pageText = new Activity.Text(page);
                        spActivity.Children.Add(pageText);
                        break;
                    }
                case "Slider":
                    {
                        spActivity.Background = (SolidColorBrush)Application.Current.Resources["AppBackgroundWhite"];
                        Activity.Slider pageSlider = new Activity.Slider();
                        spActivity.Children.Add(pageSlider);
                        break;
                    }
                case "ImageText":
                    {
                        spActivity.Background = (SolidColorBrush)Application.Current.Resources["AppBackgroundWhite"];
                        Activity.ImageText pageImageText = new Activity.ImageText(page);
                        spActivity.Children.Add(pageImageText);
                        break;
                    }
                case "Contact":
                    {
                       spActivity.Background  = (SolidColorBrush)Application.Current.Resources["AppBackgroundGrey"];
                        Activity.Contact pageContact = new Activity.Contact(page);
                        spActivity.Children.Add(pageContact);
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
