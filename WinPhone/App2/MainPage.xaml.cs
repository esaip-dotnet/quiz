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
using Windows.Storage;

namespace ESAIP_Quiz
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SubmitData();
        }

        private async void SubmitData()
        {
            //Récupération du dossier local
            StorageFolder local = Windows.Storage.ApplicationData.Current.LocalFolder;
            if (local != null)
            {
                //Récupération du dossier DataFolder
                var dataFolder = await local.GetFolderAsync("DataFolder"); 
            
                try{
                        //Récupération du fichier json
                        var src = await local.OpenStreamForReadAsync("Participation.json");
                        //Lecture des données
                        using (StreamReader json = new StreamReader(src))
                        {
                            String putData=json.ReadToEnd();

                            //HTTP web request
                            WebRequest request = WebRequest.Create("http://coreosjpg.cloudapp.net/quiz/1234/participation/1234567");
                            request.Method = "PUT";
                            request.ContentType = "text/json";

                            //Traitement de la requête 
                            using (var stream = await request.GetRequestStreamAsync())
                            {
                                //Conversion du fichier json 
                                var datas = Encoding.UTF8.GetBytes(putData);
                                //Ecriture 
                                await stream.WriteAsync(datas, 0, datas.Length);    
                            }
                        }
                     }
                catch(Exception e) 
                {
                    return;
                }
            }
        }
    }
}
