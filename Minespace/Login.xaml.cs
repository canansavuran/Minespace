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
using System.Xml.Linq;
using System.IO;

namespace Minespace
{
    public partial class Login : PhoneApplicationPage
    {

        public static XElement klnc;
        public IsolatedStorageSettings appSettings = IsolatedStorageSettings.ApplicationSettings;
        public IsolatedStorageFile SavingFile = IsolatedStorageFile.GetUserStoreForApplication();

        public Login()
        {
            InitializeComponent();
            this.Loaded += Login_Loaded;
        }

        void Login_Loaded(object sender, RoutedEventArgs e)
        {
            IsolatedStorageFile isstore = IsolatedStorageFile.GetUserStoreForApplication();
            if (isstore.FileExists("Kullanici.xml"))
            {
                //MessageBox.Show("Dosya var");
            }
            else
            {
                // MessageBox.Show("Dosya yok");
                Fonksiyonlar.KullaniciXmlOlustur();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string isim, sifre;
            isim = name.Text;
            sifre = pass.Password;
            ////////////////////////////////////////////////////////////////////////////////////////////////////////
            if (NavigationContext.QueryString["Ne"] == "ilkKayit")
            {

                IsolatedStorageFileStream fs = null;
                using (fs = SavingFile.CreateFile("Kullanici"))
                {
                    if (fs != null)
                    {
                        // just overwrite the existing info for this example.
                        byte[] bytes = System.Text.UnicodeEncoding.Unicode.GetBytes(isim);
                        fs.Write(bytes, 0, bytes.Length);
                    }
                }

                IsolatedStorageFileStream fs2 = null;
                using (fs2 = SavingFile.CreateFile("Sifre"))
                {
                    if (fs2 != null)
                    {
                        // just overwrite the existing info for this example.
                        byte[] bytes = System.Text.UnicodeEncoding.Unicode.GetBytes(sifre);
                        fs2.Write(bytes, 0, bytes.Length);
                    }
                }

                KisiKaydet(isim, sifre);
                Uri Uri = new Uri(String.Format("/MainPage.xaml"), UriKind.Relative);
                NavigationService.Navigate(Uri);

            }


            ////////////////////////////////////////////////////////////////////////////////////////////////////////

            else if (NavigationContext.QueryString["Ne"] == "login")
            {
                //kontrol işlemleri yapılmalı..////
                if (KisiBul(isim, sifre) == true)
                {
                    IsolatedStorageFileStream fs = null;
                    using (fs = SavingFile.CreateFile("Kullanici"))
                    {
                        if (fs != null)
                        {
                            // just overwrite the existing info for this example.
                            byte[] bytes = System.Text.UnicodeEncoding.Unicode.GetBytes(isim);
                            fs.Write(bytes, 0, bytes.Length);
                        }
                    }

                    IsolatedStorageFileStream fs2 = null;
                    using (fs2 = SavingFile.CreateFile("Sifre"))
                    {
                        if (fs2 != null)
                        {
                            // just overwrite the existing info for this example.
                            byte[] bytes = System.Text.UnicodeEncoding.Unicode.GetBytes(sifre);
                            fs2.Write(bytes, 0, bytes.Length);
                        }
                    }
                    Uri Uri = new Uri(String.Format("/MainPage.xaml"), UriKind.Relative);
                    NavigationService.Navigate(Uri);
                }
                else
                {
                    MessageBox.Show("User name or password incorrect..");
                }
            }



            ////////////////////////////////////////////////////////////////////////////////////////////////////////

            else if (NavigationContext.QueryString["Ne"] == "create")
            {
                IsolatedStorageFileStream fs = null;
                using (fs = SavingFile.CreateFile("Kullanici"))
                {
                    if (fs != null)
                    {
                        // just overwrite the existing info for this example.
                        byte[] bytes = System.Text.UnicodeEncoding.Unicode.GetBytes(isim);
                        fs.Write(bytes, 0, bytes.Length);
                    }
                }

                IsolatedStorageFileStream fs2 = null;
                using (fs2 = SavingFile.CreateFile("Sifre"))
                {
                    if (fs2 != null)
                    {
                        // just overwrite the existing info for this example.
                        byte[] bytes = System.Text.UnicodeEncoding.Unicode.GetBytes(sifre);
                        fs2.Write(bytes, 0, bytes.Length);
                    }
                }
                KisiKaydet(isim,sifre);
                Uri Uri = new Uri(String.Format("/MainPage.xaml"), UriKind.Relative);
                NavigationService.Navigate(Uri);
            }

            ////////////////////////////////////////////////////////////////////////////////////////////////////////
        }

        public void KisiKaydet(string KAd, string KSifre)
        {

            Kisi kisim = new Kisi();
            kisim.KullaniciAdi = KAd;
            kisim.KullaniciSifresi = KSifre;
            Fonksiyonlar.YeniKullaniciXml(kisim);
        }

        public bool KisiBul(String adi , String sifre )
        {
            bool deger = false;
            string ParseEdilecek;

            ParseEdilecek = Fonksiyonlar.KullaniciXmlOku();


            List<Kisi> oyunlar = new List<Kisi>();
            var xml = XDocument.Parse(ParseEdilecek, LoadOptions.None);

            foreach (XElement bilgilerim in xml.Descendants("Kisi"))
            {

                Kisi oyunum = new Kisi();
                oyunum.KullaniciAdi = bilgilerim.Element("KullaniciAd").Value;
                oyunum.KullaniciSifresi = bilgilerim.Element("KullaniciSifre").Value;
                oyunlar.Add(oyunum);
            }
            foreach (Kisi oyunumm in oyunlar)
            {
                if (oyunumm.KullaniciAdi == adi)
                {
                    if (oyunumm.KullaniciSifresi == sifre)
                    {
                        return true;
                    }
                }
                  
            }
            return false;


        }

        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            base.OnBackKeyPress(e);
        }
    }
}