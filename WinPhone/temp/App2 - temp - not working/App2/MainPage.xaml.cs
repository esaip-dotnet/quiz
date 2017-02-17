using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows;
using System.Text;
using System.Threading.Tasks;
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


// Pour en savoir plus sur le modèle d'élément Page vierge, consultez la page http://go.microsoft.com/fwlink/?LinkId=391641

namespace App2
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        /// <summary>
        /// Invoqué lorsque cette page est sur le point d'être affichée dans un frame.
        /// </summary>
        /// <param name="e">Données d’événement décrivant la manière dont l’utilisateur a accédé à cette page.
        /// Ce paramètre est généralement utilisé pour configurer la page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO: préparer la page pour affichage ici.

            // TODO: si votre application comporte plusieurs pages, assurez-vous que vous
            // gérez le bouton Retour physique en vous inscrivant à l’événement
            // Windows.Phone.UI.Input.HardwareButtons.BackPressed.
            // Si vous utilisez le NavigationHelper fourni par certains modèles,
            // cet événement est géré automatiquement.
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SubmitData();


        }

        private async void SubmitData()
        {
            try{
                //String answer = reponse1.Name.ToString(); //checkbox pas du text
                //string putData = "answer" + answer;
                System.IO.Stream src = Application.GetResourceStream(new Uri("Participation.json", UriKind.Relative)).Stream;
                using (StreamReader json = new StreamReader(src))
                {
                    String putData=json.ReadToEnd();

                    //HTTP web request
                    WebRequest request = WebRequest.Create("http://coreosjpg.cloudapp.net/quiz/1234/participation/1234567");
                    request.Method = "PUT";
                    request.ContentType = "text/json";
                    //request.ContentLength = data.Length;

                    //traitement de la requete
                    using (var stream = await request.GetRequestStreamAsync())
                    {
                        var datas = Encoding.UTF8.GetBytes(putData);
                        await stream.WriteAsync(datas, 0, datas.Length);
                        

                    }
                }
              
                //String json = StreamReader.(@"C:\Users\alexandre\Desktop\App2\App2\Participation.json");

            } 
            catch(Exception ex) { }

        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {

        }

    }
}
