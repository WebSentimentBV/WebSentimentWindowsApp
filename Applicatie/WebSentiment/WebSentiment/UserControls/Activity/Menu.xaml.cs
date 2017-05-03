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

namespace WebSentiment.UserControls.Activity
{
    public sealed partial class Menu : UserControl
    {
        Page pageUserControl;
        public Menu(Page pageUserControl)
        {
            this.InitializeComponent();
            this.pageUserControl = pageUserControl;
            LoadButtons();
        }

        private void LoadButtons()
        {
            
            Objects.Button btnFirst = new Objects.Button(1, "Test1");
            Objects.Button btnSec = new Objects.Button(1, "Test2");
            Objects.Button btnThort = new Objects.Button(1, "Test3");
            Objects.Button btnFourth = new Objects.Button(1, "Test4");
            Objects.Button btnFifth = new Objects.Button(1, "Test5");
            spRowOne.Children.Add(btnFirst);
            spRowTwo.Children.Add(btnSec);
            spRowThree.Children.Add(btnThort);
            spRowFour.Children.Add(btnFourth);
            spRowFive.Children.Add(btnFifth);
        }
    }
}
