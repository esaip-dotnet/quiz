using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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

namespace ESAIP_Quiz
{

    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            this.LoadImage();
            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        void LoadImage()
        {
            // API affichage d'une image
            Uri myUri = new Uri("http://thecatapi.com/api/images/get?format=src&type=jpg", UriKind.Absolute);
            BitmapImage bmi = new BitmapImage();
            bmi.CreateOptions = BitmapCreateOptions.IgnoreImageCache;
            bmi.UriSource = myUri;
            image.Source = bmi;
        }

        private void Valider_Click(object sender, RoutedEventArgs e)
        {
            // permet de changer l'image afficher par l'API
            Uri myUri = new Uri("http://thecatapi.com/api/images/get?format=src&type=jpg", UriKind.Absolute);
            BitmapImage bmi = new BitmapImage();
            bmi.CreateOptions = BitmapCreateOptions.IgnoreImageCache;
            bmi.UriSource = myUri;
            image.Source = bmi;
        }

        private void Suivant_Click(object sender, RoutedEventArgs e)
        {
            //permet de changer de page vers Quiz_Play
            Frame.Navigate(typeof(Quiz_Play));
        }
    }
}
