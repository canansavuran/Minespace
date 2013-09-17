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

    public partial class Options : PhoneApplicationPage
    {
        Fonksiyonlar fonk = new Fonksiyonlar();
        public Options()
        {
            InitializeComponent();
            

            if (fonk.seviyebul() != null)
                        {
                            string Veri = fonk.seviyebul();
                            if (Veri == "Beginner")
                            {
                                RB1.IsChecked = true;
                            }
                            else if (Veri == "Intermediate")
                            {
                                RB2.IsChecked = true;
                            }
                            else if (Veri == "Expert")
                            {
                                RB3.IsChecked = true;
                            }

                   
            }
        }

        public IsolatedStorageSettings appSettings = IsolatedStorageSettings.ApplicationSettings;
        public IsolatedStorageFile SavingFile = IsolatedStorageFile.GetUserStoreForApplication();

        string seviye;
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            int adet;
            if (RB1.IsChecked == true)
            {
                seviye = RB1.Content.ToString();
            }
            if (RB2.IsChecked == true)
            {
                seviye = RB2.Content.ToString();

            }
            if (RB3.IsChecked == true)
            {
                seviye = RB3.Content.ToString();

            }


            
            
            IsolatedStorageFileStream fs = null;
            using (fs = SavingFile.CreateFile("Seviye"))
            {
                if (fs != null)
                {
                    // just overwrite the existing info for this example.
                    byte[] bytes = System.Text.UnicodeEncoding.Unicode.GetBytes(seviye);
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