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
    // Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
          // Initialisation des fonctionalités de l'application
            this.InitializeComponent();
            this.LoadImage();
            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        void LoadImage()
        {
          // API pour afficher l'image, avec construction de l'URI
            Uri myUri = new Uri("http://thecatapi.com/api/images/get?format=src&type=jpg", UriKind.Absolute);
            BitmapImage bmi = new BitmapImage();
            bmi.CreateOptions = BitmapCreateOptions.IgnoreImageCache;
            bmi.UriSource = myUri;
            image.Source = bmi;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO: préparer la page pour affichage ici.
        }

        private void Valider_Click(object sender, RoutedEventArgs e)
        {
          // Lorsque l'on appuye sur le bouton Valider...
          // API pour afficher l'image, avec construction de l'URI
            Uri myUri = new Uri("http://thecatapi.com/api/images/get?format=src&type=jpg", UriKind.Absolute);
            BitmapImage bmi = new BitmapImage();
            bmi.CreateOptions = BitmapCreateOptions.IgnoreImageCache;
            bmi.UriSource = myUri;
            image.Source = bmi;
        }

        private void Suivant_Click(object sender, RoutedEventArgs e)
        {
          // Lorsque l'on appuye sur le bouton "Page Suivante"
          // On change de page, vers Quiz_Play
            Frame.Navigate(typeof(Quiz_Play));
        }
    }
}
