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
        public Menu(Page pageUserControl)
        {
            this.InitializeComponent();
            this.pageUserControl = pageUserControl;
            LoadButtons();
        }

        private void LoadButtons()
        {
            Category category = new Category();
            category.categoryID = pageUserControl.category.categoryID;
            foreach (Category pageSubItem in category.GetSubCategories())
            {
                Objects.Button btnPage = new Objects.Button(pageUserControl, pageSubItem.categoryID, pageSubItem.categoryTitle);
                if (SpRowOne.Children.Count() < 1)
                {
                    SpRowOne.Children.Add(btnPage);
                }
                else if (SpRowTwo.Children.Count() < 1)
                {
                    SpRowTwo.Children.Add(btnPage);
                }
                else if (SpRowThree.Children.Count() < 1)
                {
                    SpRowThree.Children.Add(btnPage);
                }
                else if (SpRowFour.Children.Count() < 1)
                {
                    SpRowFour.Children.Add(btnPage);
                }
                else if (SpRowFive.Children.Count() < 1)
                {
                    SpRowFive.Children.Add(btnPage);
                }
            }
        }
    }
}
