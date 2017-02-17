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
        /*
        void GetAvatarImageCallback(IAsyncResult result)
        {
            HttpWebRequest request = result.AsyncState as HttpWebRequest;
            if (request != null)
            {
                try
                {
                    WebResponse response = request.EndGetResponse(result);
                    image = imageFromStream(response.GetResponseStream());
                }
                catch (WebException e)
                {
                    gamerTag = "Gamertag not found.";
                    return;
                }
            }
        }
        */
        private void Valider_Click(object sender, RoutedEventArgs e)
        {
            /*String postUrl = "http://127.0.0.1";
            HttpWebRequest httpWebRequest = WebRequest.Create(postUrl) as HttpWebRequest;
            string avatarUri = "https://www.google.fr/url?sa=i&rct=j&q=&esrc=s&source=images&cd=&cad=rja&uact=8&ved=0ahUKEwiKrfLC8ZbSAhXC2hoKHfoUDDEQjRwIBw&url=http%3A%2F%2Fcafoc-auvergne2.net%2Fcampus%2Fcourse%2Findex.php%3Fcategoryid%3D8&psig=AFQjCNEX9CmAZDBBTz5PGrjmE0gpn5H5nw&ust=1487412505383571";
            HttpWebRequest request =
                (HttpWebRequest)HttpWebRequest.Create(avatarUri);
                */
            Uri myUri = new Uri("http://thecatapi.com/api/images/get?format=src&type=jpg", UriKind.Absolute);
            BitmapImage bmi = new BitmapImage();
            bmi.CreateOptions = BitmapCreateOptions.IgnoreImageCache;
            bmi.UriSource = myUri;
            image.Source = bmi;
            /*
            if (httpWebRequest == null)
            {
                throw new NullReferenceException("request is not a http request");
            }
            request.BeginGetResponse(GetAvatarImageCallback, request);




            // Set up the request properties. 
            httpWebRequest.Method = "POST";
            httpWebRequest.ContentType = "text/json";
            httpWebRequest.CookieContainer = new CookieContainer();
            httpWebRequest.ContentLength = formData.Length;
            httpWebRequest.BeginGetRequestStream((result) =>
            {
                try
                {
                    HttpWebRequest request = (HttpWebRequest)result.AsyncState;
                    using (Stream requestStream = request.EndGetRequestStream(result))
                    {
                        requestStream.Write(formData, 0, formData.Length);
                        requestStream.Close();
                    }
                    request.BeginGetResponse(a =>
                    {
                        try
                        {
                            var response = request.EndGetResponse(a);
                            var responseStream = response.GetResponseStream();
                            using (var sr = new StreamReader(responseStream))
                            {
                                using (StreamReader streamReader = new StreamReader(response.GetResponseStream()))
                                {
                                    string responseString = streamReader.ReadToEnd();

                                    if (!string.IsNullOrEmpty(responseString))
                                    {
                                        Dispatcher.BeginInvoke(() =>
                                        {
                                            MessageBox.Show("Your data is successfully submitted!");
                                        });
                                    }
                                    else
                                    {
                                        Dispatcher.BeginInvoke(() => MessageBox.Show("Error in data submission!"));
                                    }

                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Dispatcher.BeginInvoke(() =>
                            {
                                MessageBox.Show("Error in data submission!");
                            });
                        }
                    }, null);
                }
                catch (Exception)
                {

                    MessageBox.Show("Error in data submission!");
                }
            }, httpWebRequest);

            isImageUpload = false;
        }
        */
    }
    }
}

