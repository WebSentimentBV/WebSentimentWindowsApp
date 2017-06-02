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
using Windows.UI.Core;
using System.Diagnostics;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace WebSentiment.UserControls
{
    public sealed partial class Page : UserControl
    {
        public int pageOrderID { get; set; }
        public Page()
        {
            this.InitializeComponent();
            pageOrderID = 1;
            LoadPage();
           
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
        public void LoadPage()
        {
            LoadHeader();
            LoadActivity();
            if(pageOrderID != 0)
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
            Header.PageHeader pageHeader = new Header.PageHeader();
            spHeader.Children.Add(pageHeader);
        }

        public void LoadActivity()
        {
            
            PageOrder pageOrder = new PageOrder();
            pageOrder.pageOrderID = pageOrderID;
            pageOrder.GetPageOrder();
            Classes.Page page = new Classes.Page();
            page.pageID = pageOrder.pageID;
            page.GetPage();
            spActivity.Children.Clear();
            switch (page.pageType)
            {
                case "Menu":
                    {
                        Activity.Menu pageMenu = new Activity.Menu(this, pageOrderID);
                        spActivity.Children.Add(pageMenu);
                        break;
                    }
                case "SliderProjects":
                    {
                        Activity.SliderProjects pageSliderProjects = new Activity.SliderProjects();
                        spActivity.Children.Add(pageSliderProjects);

                        break;
                    }
                case "Text":
                    {
                        Activity.Text pageText = new Activity.Text(page);
                        spActivity.Children.Add(pageText);
                        break;
                    }
                case "Slider":
                    {
                        Activity.Slider pageSlider = new Activity.Slider();
                        spActivity.Children.Add(pageSlider);
                        break;
                    }
                case "ImageText":
                    {
                        Activity.ImageText pageImageText = new Activity.ImageText(page);
                        spActivity.Children.Add(pageImageText);
                        break;
                    }
                case "Contact":
                    {
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
