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

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO: préparer la page pour affichage ici.
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {//si on clique sur le bouton "valider"...
            SubmitData(); //on lance la fonction SubmitData()
        }

        private async void SubmitData()
        {
            try{
                //création d'une variable de stockage pour le json
                System.IO.Stream src = Application.GetResourceStream(new Uri("Participation.json", UriKind.Relative)).Stream;
                using (StreamReader json = new StreamReader(src))
                {
                    String putData=json.ReadToEnd(); //Lecture du fichier json, et stockage dans une variable putData

                    //création d'une HTTP web request
                    WebRequest request = WebRequest.Create("http://coreosjpg.cloudapp.net/quiz/1234/participation/1234567");
                    request.Method = "PUT";
                    request.ContentType = "text/json";

                    //traitement de la requete et envoi de putData
                    using (var stream = await request.GetRequestStreamAsync())
                    {
                        var datas = Encoding.UTF8.GetBytes(putData);
                        await stream.WriteAsync(datas, 0, datas.Length);
                    }
                }
            }

            catch(Exception ex) { 
                //Gestion des exceptions
            }
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            //Dans le cas où un des radio button est sélectionné...
        }
    }
}
