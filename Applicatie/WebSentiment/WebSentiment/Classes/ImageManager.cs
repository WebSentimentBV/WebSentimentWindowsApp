using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace E_Divison.Classes
{
    public class ImageManager
    {
        public async void SetImage(Image imageControl, byte[] imageArray)
        {
            if (imageArray != null)
            {
                BitmapImage imageMap = new BitmapImage();
                imageMap.SetSource(await ConvertTo(imageArray));
                imageControl.Source = imageMap;
            }
        }

        private async Task<InMemoryRandomAccessStream> ConvertTo(byte[] arr)
        {
            InMemoryRandomAccessStream randomAccessStream = new InMemoryRandomAccessStream();
            await randomAccessStream.WriteAsync(arr.AsBuffer());
            randomAccessStream.Seek(0);
            return randomAccessStream;
        }
    }
}
