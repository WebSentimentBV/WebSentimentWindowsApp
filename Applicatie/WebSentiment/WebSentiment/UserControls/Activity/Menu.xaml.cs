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
    public sealed partial class Menu : UserControl
    {
        private Page pageUserControl;
        private int pageOrderID;
        public Menu(Page pageUserControl, int pageOrderID)
        {
            this.InitializeComponent();
            this.pageUserControl = pageUserControl;
            this.pageOrderID = pageOrderID;
            LoadButtons();
        }

        private void LoadButtons()
        {
            Category pageOrder = new Category();
            pageOrder.categoryID = pageOrderID;
            foreach (Category pageSubItem in pageOrder.GetSubPageOrders())
            {
                Objects.Button btnPage = new Objects.Button(pageUserControl, pageSubItem.categoryID, pageSubItem.categoryTitle);
                if(spRowOne.Children.Count() < 1)
                {
                    spRowOne.Children.Add(btnPage);
                }
                else if(spRowTwo.Children.Count() < 1)
                {
                    spRowTwo.Children.Add(btnPage);
                }
                else if (spRowThree.Children.Count() < 1)
                {
                    spRowThree.Children.Add(btnPage);
                }
                else if (spRowFour.Children.Count() < 1)
                {
                    spRowFour.Children.Add(btnPage);
                }
                else if (spRowFive.Children.Count() < 1)
                {
                    spRowFive.Children.Add(btnPage);
                }
            }

        }
    }
}
