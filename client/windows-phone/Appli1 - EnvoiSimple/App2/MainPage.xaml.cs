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
using Windows.UI.Xaml.Navigation;
using System.Text;
using System.Threading.Tasks;

namespace App2
{
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
        {
            //lorsque l'on appuye sur le bouton "envoyer"...
            SubmitData(); //on lance SubmitData()
        }

        private async void SubmitData()
        {
            try{
                //String answer = reponse1.Name.ToString(); //à utiliser pour renvoyer une réponse
                
                //stockage d'un Json dans la variable putData
                String putData = "{\"_id\" : 1234567,\"idParticipant\" : \"mailto://jp.gouigoux@free.fr\",\"startTimestamp\" : \"2017-01-26T03:26:06+00:00\",\"score\" : 0.5,\"quiz\" : {\"_id\" : 1234,\"summary\" : \"Les drapeaux de Formule 1\",\"description\" : \"Ce quiz testera votre connaissance visuelle des différents drapeaux utilisés sur un circuit de course\",\"title\" : \"Drapeaux F1\",\"questions\" : [{\"title\" : \"Quel est ce drapeau ?\",\"picture\" : \"http://images.esaip.org/quiz-lib/damier.jpg\",\"answers\" : [{\"title\" : \"C'est le drapeau de départ\",\"correct\" : false,\"checkedByPlayer\" : true},{	\"title\" : \"C'est le drapeau d'arrivée\",\"correct\" : true,\"checkedByPlayer\" : false	},{\"title\" : \"C'est le drapeau indiquant un arrêt de course\",\"correct\" : false,\"checkedByPlayer\" : false},{\"title\" : \"C'est le drapeau indiquant un accident proche\",\"correct\" : false,\"checkedByPlayer\" : false}	]},{\"title\" : \"Quel est le drapeau utilisé pour le départ ?\",\"answers\" : [{	\"title\" : \"\",\"picture\" : \"http://images.esaip.org/quiz-lib/damier.jpg\",	\"correct\" : true,\"checkedByPlayer\" : true},{\"title\" : \"\",\"picture\" : \"http://images.esaip.org/quiz-lib/redflag.jpg\",\"correct\" : false,\"checkedByPlayer\" : false},{\"title\" : \"\",\"picture\" : \"http://images.esaip.org/quiz-lib/greenflag.jpg\",\"correct\" : false,\"checkedByPlayer\" : false},{\"title\" : \"\",\"picture\" : \"http://images.esaip.org/quiz-lib/yellowflag.jpg\",\"correct\" : false,\"checkedByPlayer\" : false}]}]}}";
                
                //création d'une HTTP web request
                WebRequest request = WebRequest.Create("http://coreosjpg.cloudapp.net/quiz/1234/participation/1234567");
                request.Method = "PUT";
                request.ContentType = "text/json";

                //traitement de la requete et envoi du putData
                using (var stream = await request.GetRequestStreamAsync())
                {
                    var datas = Encoding.UTF8.GetBytes(putData);
                    await stream.WriteAsync(datas, 0, datas.Length);
                }
            } 

            catch(Exception ex)
            {
                //Cas dans lequel une exception serait à gérer
            }
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            //Pour l'instant inutile, sert à vérifier qu'un bouton est sélectionné
        }
    }
}
