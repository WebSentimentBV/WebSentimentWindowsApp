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
        public void LoadPage()
        {
            LoadHeader();
            LoadActivity();
        }

        public void LoadHeader()
        {
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
