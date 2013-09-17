using Microsoft.Phone.Controls;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Xml.Linq;
namespace Minespace
{
    public partial class MainPage : PhoneApplicationPage
    {

        public static XElement xmlmiz;
        public IsolatedStorageSettings appSettings = IsolatedStorageSettings.ApplicationSettings;
        public IsolatedStorageFile SavingFile = IsolatedStorageFile.GetUserStoreForApplication();
        Fonksiyonlar fonk = new Fonksiyonlar();
        public static List<String> gelenler;
        public static List<String> TumOyunlar;
        string seviye;
        string renk;
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            this.Loaded += MainPage_Loaded;

            welcome.Text = "Welcome " + fonk.KullaniciBul() + " :) ";
            // Set the data context of the listbox control to the sample data
            ///////////////////////////////////////////////////////////////
            if (fonk.seviyebul() != null)
            {
                string seviye = fonk.seviyebul();

            }
            else
            {
                fonk.ilkseviyeata();
            }

            

            ///////////////////////////////////////////////////////////////////////////
            if (fonk.renginibul() != null)
            {
                string rengi = fonk.renginibul();
                if (rengi == "Night")
                    asd.Color = Colors.Brown;
                else if (rengi == "Flower")
                    asd.Color = Colors.Purple;
                else if (rengi == "Forrest")
                    asd.Color = Colors.Green;
                else if (rengi == "Sky")
                    asd.Color = Colors.Cyan;

            }
            else
            {
                fonk.ilkrengiata();
            }
            //////////////////////////////////////////////////////////////////////////////////////////////////////////

        }

        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            IsolatedStorageFile isstore = IsolatedStorageFile.GetUserStoreForApplication();
            if (isstore.FileExists("KayitliOyunlar.xml"))
            {
                //MessageBox.Show("Dosya var");
            }
            else
            {
                // MessageBox.Show("Dosya yok");
                Fonksiyonlar.KayitXmlOlustur();
            }


        }


        private void PhoneApplicationPage_BackKeyPress(object sender, System.ComponentModel.CancelEventArgs e)
        {
            while (NavigationService.CanGoBack)
                NavigationService.RemoveBackEntry();
        }


        private void ApplicationBarIconButton_Click_1(object sender, EventArgs e)
        {
            Uri Uri = new Uri(String.Format("/Options.xaml"), UriKind.Relative);
            NavigationService.Navigate(Uri);
        }


        private void ApplicationBarMenuItem_Click_1(object sender, EventArgs e)
        {
            Uri Uri = new Uri(String.Format("/ChangeView.xaml"), UriKind.Relative);
            NavigationService.Navigate(Uri);
        }

        private void ApplicationBarIconButton_Click_3(object sender, EventArgs e)
        {
            // hızlı yeni oyun
            if (fonk.KullaniciBul() == null)
            {
                Uri Uri2 = new Uri(String.Format("/Login.xaml?Ne="+"ilkKayit"), UriKind.Relative);
                NavigationService.Navigate(Uri2);
            }
            int[,] dizi;

            if (fonk.seviyebul() != null)
            {
                string Veri = fonk.seviyebul();
                if (Veri == "Beginner")
                {
                    dizi = new int[9, 9];
                }
                else if (Veri == "Intermediate")
                {
                    dizi = new int[16, 16];
                }
                else if (Veri == "Expert")
                {
                    dizi = new int[16, 30];
                }


            }
            Uri Uri = new Uri(String.Format("/NewGame.xaml"), UriKind.Relative);
            NavigationService.Navigate(Uri);

        }

        //Continue butonu
        private void ApplicationBarIconButton_Click_4(object sender, EventArgs e)
        {
            //string Nerdengeliyo = "Giriş";
            //Uri Uri = new Uri(String.Format("/GirisKayit.xaml?Ne=", Nerdengeliyo), UriKind.Relative);
            //NavigationService.Navigate(Uri);
            gelenler = XMlOkuma();
            if (gelenler.Count == 0)
            {
                MessageBox.Show("No Saved Game..");

            }
            else
            {
                Uri Uri = new Uri(String.Format("/OyunSec.xaml"), UriKind.Relative);
                NavigationService.Navigate(Uri);
            }

        }
        private void ApplicationBarIconButton_Click_2(object sender, EventArgs e)
        {
            Uri Uri = new Uri(String.Format("/NewUser.xaml"), UriKind.Relative);
            NavigationService.Navigate(Uri);
        }

        private void ApplicationBarIconButton_Click_6(object sender, EventArgs e)
        {
            Uri Uri = new Uri(String.Format("/istatistiklerim.xaml"), UriKind.Relative);
            NavigationService.Navigate(Uri);
        }

        public List<String> XMlOkuma()
        {
            int sayac = 0, sayacsutun = 0;
            bool deger = false;
            string ParseEdilecek;

            //using (IsolatedStorageFile myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication())
            //{
            //    IsolatedStorageFileStream isoFileStream = myIsolatedStorage.OpenFile("Kayit.xml", FileMode.Open);
            //    using (StreamReader reader = new StreamReader(isoFileStream))
            //    {
                    ParseEdilecek = Fonksiyonlar.KayitXmlOku();

                //    deger = true;
                //}
            //}

            List<KayitliOyun> oyunlar = new List<KayitliOyun>();
            var xml = XDocument.Parse(ParseEdilecek, LoadOptions.None);

            foreach (XElement bilgilerim in xml.Descendants("Oyun"))
            {

                KayitliOyun oyunum = new KayitliOyun();
                oyunum.Zaman = bilgilerim.Element("Zaman").Value;
                oyunum.OyunCesidi = Convert.ToInt32(bilgilerim.Element("OyunCesidi").Value);
                oyunum.OyunAdi = bilgilerim.Element("OyunAdi").Value;
                oyunum.KullaniciAdi = bilgilerim.Element("KullaniciAd").Value;
                oyunum.KullaniciSifresi = bilgilerim.Element("KullaniciSifre").Value;
                oyunum.Seviyesi = bilgilerim.Element("Seviye").Value;
                if (oyunum.Seviyesi == "Beginner")
                {
                    oyunum.DegerDizisi = new int[9, 9];
                    oyunum.DurumDizisi = new int[9, 9];
                }
                else if (oyunum.Seviyesi == "Intermediate")
                {
                    oyunum.DegerDizisi = new int[16, 16];
                    oyunum.DurumDizisi = new int[16, 16];
                }
                else if (oyunum.Seviyesi == "Expert")
                {
                    oyunum.DegerDizisi = new int[16, 30];
                    oyunum.DurumDizisi = new int[16, 30];
                }

                sayac = 0;
                sayacsutun = 0;
                foreach (XElement bilgilerimDegerim in bilgilerim.Descendants("Degerler").Descendants("Deger"))
                {

                    sayacsutun = 0;
                    foreach (int degeri in bilgilerimDegerim.Descendants("degerim"))
                    {
                        oyunum.DegerDizisi[sayac, sayacsutun] = degeri;
                        sayacsutun++;
                    }
                    sayac++;
                }
                sayac = 0;
                sayacsutun = 0;
                foreach (XElement bilgilerimDegerim in bilgilerim.Descendants("Durumlar").Descendants("Durum"))
                {

                    sayacsutun = 0;
                    foreach (int durumu in bilgilerimDegerim.Descendants("durumum"))
                    {
                        oyunum.DurumDizisi[sayac, sayacsutun] = durumu;
                        sayacsutun++;
                    }
                    sayac++;
                }
                oyunlar.Add(oyunum);
            }

            List<String> adlari = new List<String>();
            foreach (KayitliOyun oyunumm in oyunlar)
            {
                if (oyunumm.KullaniciAdi == fonk.KullaniciBul() && oyunumm.OyunCesidi == 1)
                {
                    adlari.Add(oyunumm.OyunAdi);
                }
            }

            return adlari;

        }

        public List<String> XMldenTumOyunlar()
        {
            int sayac = 0, sayacsutun = 0;
            bool deger = false;
            string ParseEdilecek;

            //using (IsolatedStorageFile myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication())
            //{
            //    IsolatedStorageFileStream isoFileStream = myIsolatedStorage.OpenFile("Kayit.xml", FileMode.Open);
            //    using (StreamReader reader = new StreamReader(isoFileStream))
            //    {
            ParseEdilecek = Fonksiyonlar.KayitXmlOku();

            //    deger = true;
            //}
            //}

            List<KayitliOyun> oyunlar = new List<KayitliOyun>();
            var xml = XDocument.Parse(ParseEdilecek, LoadOptions.None);

            foreach (XElement bilgilerim in xml.Descendants("Oyun"))
            {

                KayitliOyun oyunum = new KayitliOyun();
                oyunum.Zaman = bilgilerim.Element("Zaman").Value;
                oyunum.OyunCesidi = Convert.ToInt32(bilgilerim.Element("OyunCesidi").Value);
                oyunum.OyunAdi = bilgilerim.Element("OyunAdi").Value;
                oyunum.KullaniciAdi = bilgilerim.Element("KullaniciAd").Value;
                oyunum.KullaniciSifresi = bilgilerim.Element("KullaniciSifre").Value;
                oyunum.Seviyesi = bilgilerim.Element("Seviye").Value;
                if (oyunum.Seviyesi == "Beginner")
                {
                    oyunum.DegerDizisi = new int[9, 9];
                    oyunum.DurumDizisi = new int[9, 9];
                }
                else if (oyunum.Seviyesi == "Intermediate")
                {
                    oyunum.DegerDizisi = new int[16, 16];
                    oyunum.DurumDizisi = new int[16, 16];
                }
                else if (oyunum.Seviyesi == "Expert")
                {
                    oyunum.DegerDizisi = new int[16, 30];
                    oyunum.DurumDizisi = new int[16, 30];
                }

                sayac = 0;
                sayacsutun = 0;
                foreach (XElement bilgilerimDegerim in bilgilerim.Descendants("Degerler").Descendants("Deger"))
                {

                    sayacsutun = 0;
                    foreach (int degeri in bilgilerimDegerim.Descendants("degerim"))
                    {
                        oyunum.DegerDizisi[sayac, sayacsutun] = degeri;
                        sayacsutun++;
                    }
                    sayac++;
                }
                sayac = 0;
                sayacsutun = 0;
                foreach (XElement bilgilerimDegerim in bilgilerim.Descendants("Durumlar").Descendants("Durum"))
                {

                    sayacsutun = 0;
                    foreach (int durumu in bilgilerimDegerim.Descendants("durumum"))
                    {
                        oyunum.DurumDizisi[sayac, sayacsutun] = durumu;
                        sayacsutun++;
                    }
                    sayac++;
                }
                oyunlar.Add(oyunum);
            }

            List<String> adlari = new List<String>();
            foreach (KayitliOyun oyunumm in oyunlar)
            {
                if(oyunumm.OyunCesidi ==0)
                adlari.Add(oyunumm.OyunAdi);
            }

            return adlari;

        }

        private void ApplicationBarIconButton_Click_5(object sender, EventArgs e)
        {
            //string Nerdengeliyo = "Giriş";
            TumOyunlar = XMldenTumOyunlar();
            Uri Uri = new Uri(String.Format("/TumOyunlarPage.xaml" ), UriKind.Relative);
            NavigationService.Navigate(Uri);
        }

        private void newGame_Click(object sender, RoutedEventArgs e)
        {
            if (fonk.KullaniciBul() == null)
            {
                Uri Uri2 = new Uri(String.Format("/Login.xaml?Ne=" + "ilkKayit"), UriKind.Relative);
                NavigationService.Navigate(Uri2);
            }
            int[,] dizi;

            if (fonk.seviyebul() != null)
            {
                string Veri = fonk.seviyebul();
                if (Veri == "Beginner")
                {
                    dizi = new int[9, 9];
                }
                else if (Veri == "Intermediate")
                {
                    dizi = new int[16, 16];
                }
                else if (Veri == "Expert")
                {
                    dizi = new int[16, 30];
                }


            }
            Uri Uri = new Uri(String.Format("/NewGame.xaml"), UriKind.Relative);
            NavigationService.Navigate(Uri);
        }

        private void continueGame_Click(object sender, RoutedEventArgs e)
        {
            //string Nerdengeliyo = "Giriş";
            //Uri Uri = new Uri(String.Format("/GirisKayit.xaml?Ne=", Nerdengeliyo), UriKind.Relative);
            //NavigationService.Navigate(Uri);
            gelenler = XMlOkuma();
            if (gelenler.Count == 0)
            {
                MessageBox.Show("No Saved Game..");

            }
            else
            {
                Uri Uri = new Uri(String.Format("/OyunSec.xaml"), UriKind.Relative);
                NavigationService.Navigate(Uri);
            }
        }

        private void createGame_Click(object sender, RoutedEventArgs e)
        {
            //string Nerdengeliyo = "Giriş";
            TumOyunlar = XMldenTumOyunlar();
            Uri Uri = new Uri(String.Format("/TumOyunlarPage.xaml"), UriKind.Relative);
            NavigationService.Navigate(Uri);
        }

    }
}