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
            Uri myUri = new Uri("http://thecatapi.com/api/images/get?format=src&type=jpg", UriKind.Absolute);
            BitmapImage bmi = new BitmapImage();
            bmi.CreateOptions = BitmapCreateOptions.IgnoreImageCache;
            bmi.UriSource = myUri;
            image.Source = bmi;
        }

        /// Invoqué lorsque cette page est sur le point d'être affichée dans un frame.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO: préparer la page pour affichage ici.
        }

        private void Valider_Click(object sender, RoutedEventArgs e)
        {
            Uri myUri = new Uri("http://thecatapi.com/api/images/get?format=src&type=jpg", UriKind.Absolute);
            BitmapImage bmi = new BitmapImage();
            bmi.CreateOptions = BitmapCreateOptions.IgnoreImageCache;
            bmi.UriSource = myUri;
            image.Source = bmi;
        }

        private void Question_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
