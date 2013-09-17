using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.IO.IsolatedStorage;
using System.Text;

namespace Minespace
{
    public partial class ChangeView : PhoneApplicationPage
    {
        Fonksiyonlar fonk = new Fonksiyonlar();
        public ChangeView()
        {
            InitializeComponent();
           
                        if (fonk.renginibul() != null)
                        {
                            string Veri = fonk.renginibul();
                            if (Veri == "Night")
                                 RB1.IsChecked = true;
                            else if (Veri == "Flower")
                                RB2.IsChecked = true;
                            else if (Veri == "Forrest")
                                RB3.IsChecked = true;
                            else if (Veri == "Sky")
                                RB4.IsChecked = true;

                        }
                    
        }

        public IsolatedStorageSettings appSettings = IsolatedStorageSettings.ApplicationSettings;
        public IsolatedStorageFile SavingFile = IsolatedStorageFile.GetUserStoreForApplication();

        string renk;

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            int adet;
            if (RB1.IsChecked == true)
            {
                renk = RB1.Content.ToString();
            }
            if (RB2.IsChecked == true)
            {
                renk = RB2.Content.ToString();

            }
            if (RB3.IsChecked == true)
            {
                renk = RB3.Content.ToString();

            } 
            if (RB4.IsChecked == true)
            {
                renk = RB4.Content.ToString();

            }





            IsolatedStorageFileStream fs = null;
            using (fs = SavingFile.CreateFile("Renk"))
            {
                if (fs != null)
                {
                    // just overwrite the existing info for this example.
                    byte[] bytes = System.Text.UnicodeEncoding.Unicode.GetBytes(renk);
                    fs.Write(bytes, 0, bytes.Length);
                    adet = bytes.Length;
                }
            }
            Uri Uri = new Uri(String.Format("/MainPage.xaml"), UriKind.Relative);
            NavigationService.Navigate(Uri);
        }

        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            base.OnBackKeyPress(e);
        }
    }
}