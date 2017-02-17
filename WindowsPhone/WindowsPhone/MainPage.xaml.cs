using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.InteropServices.WindowsRuntime;
using WebServiceExampleApp;
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

// Pour en savoir plus sur le modèle d'élément Page vierge, consultez la page http://go.microsoft.com/fwlink/?LinkId=391641

namespace WindowsPhone
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
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

        /// <summary>
        /// Invoqué lorsque cette page est sur le point d'être affichée dans un frame.
        /// </summary>
        /// <param name="e">Données d'événement décrivant la manière dont l'utilisateur a accédé à cette page.
        /// Ce paramètre est généralement utilisé pour configurer la page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO: préparer la page pour affichage ici.

            // TODO: si votre application comporte plusieurs pages, assurez-vous que vous
            // gérez le bouton Retour physique en vous inscrivant à l’événement
            // Événement Windows.Phone.UI.Input.HardwareButtons.BackPressed.
            // Si vous utilisez le NavigationHelper fourni par certains modèles,
            // cet événement est géré automatiquement.
        }

        /// <summary>
        /// Tentative récupération des valeurs d'une api  (en json) 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Valider_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://api.openweathermap.org");

                    var url = "data/2.5/forecast/daily?q={0}&mode=json&units=metric&cnt=7";

                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = await client.GetAsync(String.Format(url, UriKind.RelativeOrAbsolute));
                if (response.IsSuccessStatusCode)
                   {
                        var data = response.Content.ReadAsStringAsync();
                        var weatherdata = JsonConvert.DeserializeObject<WeatherObject>(data.Result.ToString());
                        reponse1.DataContext = weatherdata.city.name.ToString();
                        reponse2.DataContext = weatherdata.message.ToString();
                        reponse3.DataContext = weatherdata.list[1].temp.ToString();
                        reponse4.DataContext = weatherdata.list[1].humidity.ToString();

                    }
                }
            }
            catch (Exception ex)
            {
               
            }
        }

    }
}

