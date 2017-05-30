using WebSentiment.Classes;
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
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace WebSentiment.UserControls.Activity
{
    public sealed partial class SliderProjects : UserControl
    {
        private int projectID;
        private string screenMode;
        public SliderProjects()
        {
            this.InitializeComponent();
            projectID = 1;
            screenMode = "Dekstop";
            LoadProject();
        }

        private void LoadProject()
        {
            Classes.Project project = new Classes.Project();
            project.projectID = projectID;
            project.GetProject();
            ImageManager imageManager = new ImageManager();
            switch (screenMode)
            {
                case "Dekstop":
                    {
                        //Select Dekstop image.
                        imgDekstop.Source = new BitmapImage(new Uri("ms-appx:///Images/Dekstop.png", UriKind.Absolute));
                        //Deselect Tablet image.
                        imgTablet.Source = new BitmapImage(new Uri("ms-appx:///Images/Tablet-not-selected.png", UriKind.Absolute));
                        //Deselect Phone image.
                        imgPhone.Source = new BitmapImage(new Uri("ms-appx:///Images/Phone-not-selected.png", UriKind.Absolute));
                        //Change project Image.
                        imageManager.SetImage(imgProjectImage, project.projectImageOne);
                        break;
                    }
                case "Tablet":
                    {
                        //Deselect Dekstop image.
                        imgDekstop.Source = new BitmapImage(new Uri("ms-appx:///Images/Dekstop-not-selected.png", UriKind.Absolute));
                        //Select Tablet image.
                        imgTablet.Source = new BitmapImage(new Uri("ms-appx:///Images/Tablet.png", UriKind.Absolute));
                        //Deselect Phone image.
                        imgPhone.Source = new BitmapImage(new Uri("ms-appx:///Images/Phone-not-selected.png", UriKind.Absolute));
                        //Change project Image.
                        imageManager.SetImage(imgProjectImage, project.projectImageTwo);
                        break;
                    }
                case "Phone":
                    {
                        //Deselect Dekstop image.
                        imgDekstop.Source = new BitmapImage(new Uri("ms-appx:///Images/Dekstop-not-selected.png", UriKind.Absolute));
                        //Deselect Tablet image.
                        imgTablet.Source = new BitmapImage(new Uri("ms-appx:///Images/Tablet-not-selected.png", UriKind.Absolute));
                        //Select Phone image.
                        imgPhone.Source = new BitmapImage(new Uri("ms-appx:///Images/Phone.png", UriKind.Absolute));
                        //Change project Image.
                        imageManager.SetImage(imgProjectImage, project.projectImageThree);
                        break;
                    }
            }
        }

        private void imgNext_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if(projectID >= 3)
            {
                projectID = 1;
                LoadProject();
            }
            else
            {
                projectID = projectID += 1;
                LoadProject();
            }
        }

        private void imgPrevious_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (projectID <= 1)
            {
                projectID = 3;
                LoadProject();
            }
            else
            {
                projectID = projectID -= 1;
                LoadProject();
            }
        }

        private void imgDekstop_Tapped(object sender, TappedRoutedEventArgs e)
        {
            screenMode = "Dekstop";
            LoadProject();
        }

        private void imgTablet_Tapped(object sender, TappedRoutedEventArgs e)
        {
            screenMode = "Tablet";
            LoadProject();
        }

        private void imgPhone_Tapped(object sender, TappedRoutedEventArgs e)
        {
            screenMode = "Phone";
            LoadProject();
        }
    }
}
