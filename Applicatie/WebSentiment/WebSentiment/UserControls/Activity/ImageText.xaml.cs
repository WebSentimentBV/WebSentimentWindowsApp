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
    public sealed partial class ImageText : UserControl
    {
        Classes.Page page;
        public ImageText(Classes.Page page)
        {
            this.InitializeComponent();
            this.page = page;
            Init();
        }

        private void Init()
        {
            ImageManager imageManager = new ImageManager();
            imageManager.SetImage(imgPicture, page.pageImage);
            lblText.Text = page.pageTextOne;
        }
    }
}
