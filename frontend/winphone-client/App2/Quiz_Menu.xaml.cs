using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

namespace ESAIP_Quiz
{
    // Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    public sealed partial class Quiz_Menu : Page
    {
        public Quiz_Menu()
        {
            //this.InitializeComponent();
        }

        // Invoqué lorsque cette page est sur le point d'être affichée dans un frame.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }
    }
}
