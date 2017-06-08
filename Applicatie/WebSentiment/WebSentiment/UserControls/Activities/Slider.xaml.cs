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
    public sealed partial class Slider : UserControl
    {
        private List<Client> listOfClients;
        private int startID;
        private int endID;
        public Slider()
        {
            this.InitializeComponent();
            LoadSlider();
        }

        private void LoadSlider()
        {
            Client client = new Client();
            listOfClients = client.GetClients();
            startID = 0;
            endID = 4;
            UpdateSlider();
        }

        private void UpdateSlider()
        {
            imgLogoOne.Visibility = Visibility.Collapsed;
            imgLogoTwo.Visibility = Visibility.Collapsed;
            imgLogoThree.Visibility = Visibility.Collapsed;
            imgLogoFour.Visibility = Visibility.Collapsed;
            ImageManager imageManager = new ImageManager();
            int count = 0;
            foreach (Client client in listOfClients.Skip(startID).Take(endID - startID))
            {
                switch(count)
                {
                    case 0:
                        {
                            imgLogoOne.Visibility = Visibility.Visible;
                            imageManager.SetImage(imgLogoOne, client.clientImage);
                            imgLogoOne.Stretch = Stretch.Fill;
                            break;
                        }
                    case 1:
                        {
                            imgLogoTwo.Visibility = Visibility.Visible;
                            imageManager.SetImage(imgLogoTwo, client.clientImage);
                            imgLogoTwo.Stretch = Stretch.Fill;
                            break;
                        }
                    case 2:
                        {
                            imgLogoThree.Visibility = Visibility.Visible;
                            imageManager.SetImage(imgLogoThree, client.clientImage);
                            imgLogoThree.Stretch = Stretch.Fill;
                            break;
                        }
                    case 3:
                        {
                            imgLogoFour.Visibility = Visibility.Visible;
                            imageManager.SetImage(imgLogoFour, client.clientImage);
                            imgLogoFour.Stretch = Stretch.Fill;
                            break;
                        }
                }
                count += 1;
            }
        }

        private void imgPrevious_Tapped(object sender, TappedRoutedEventArgs e)
        {
            int amountOfImagesTotal = 20;
            int amountOfImagesPerSlider = 4;
            //When you are at the first element of the list (0) go to the last element
            if (startID == 0)
            {
                startID = (amountOfImagesTotal - amountOfImagesPerSlider);
                endID = amountOfImagesTotal;
            }
            //Else if the element is more or same as the amount of images per page than paginate to the previous 4 elements.
            else if(startID >= amountOfImagesPerSlider)
            {
                startID = (startID - amountOfImagesPerSlider);
                endID = (endID - amountOfImagesPerSlider);
            }
            UpdateSlider();
        }

        private void imgNext_Tapped(object sender, TappedRoutedEventArgs e)
        {
            int amountOfImagesTotal = 20;
            int amountOfImagesPerSlider = 4;
            //When you are at the last element of the list (20) go to the first element
            if (endID == amountOfImagesTotal)
            {
                endID = amountOfImagesPerSlider;
                startID = 0;
            }
            //Else if the element is more or same as the amount of images per page than paginate to the next 4 elements.
            else if (endID >= 4)
            {
                startID = (startID + amountOfImagesPerSlider);
                endID = (endID + amountOfImagesPerSlider);
            }
            UpdateSlider();
        }
    }
}
