using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Xml.Linq;

namespace Minespace
{
    public partial class OyunSec : PhoneApplicationPage
    {
        public static KayitliOyun deneme;
        public OyunSec()
        {
            InitializeComponent();
            List<String> ads = MainPage.gelenler;
            
            List<Button> butonlar = new List<Button>();
            for (int i = 0; i < ads.Count && i < 5; i++)
            {
                Button yeni = new Button();
                yeni.Content = ads[i];
                yeni.Height = 70;
                yeni.Width = 700;
                yeni.Click += yeni_Click;
                butonlar.Add(yeni);
            }
            OyunAdlari.ItemsSource = butonlar;

        }

        void yeni_Click(object sender, RoutedEventArgs e)
        {
            int sayac = 0, sayacsutun = 0;
            

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

            foreach (KayitliOyun oyunumm in oyunlar)
            {
                if (oyunumm.OyunAdi == ((Button)sender).Content.ToString())
                {
                    deneme = oyunumm;
                    Fonksiyonlar.deleteKayit(oyunumm.OyunAdi);
                    Uri Uri = new Uri(String.Format("/OyunDevam.xaml"), UriKind.Relative);
                    NavigationService.Navigate(Uri);
                }

            }

        }

        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            base.OnBackKeyPress(e);
        }
    }
}