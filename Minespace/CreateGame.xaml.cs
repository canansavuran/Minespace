using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Xml.Linq;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace Minespace
{
    public partial class CreateGame : PhoneApplicationPage
    {
        public static XElement xmlmiz;
        Fonksiyonlar fonk = new Fonksiyonlar();
        public static List<ListBox> tableList = new List<ListBox>();
        int xmiz, ymiz, boyut;
        int MayinSay;
        int KoyulanMayın;
        int[,] dizi;
        int[,] durum;
        string Seviyem;

        public CreateGame()
        {

            InitializeComponent();

            if (fonk.renginibul() != null)
            {
                string rengi = fonk.renginibul();
                if (rengi == "Night")
                    arka.Color = Colors.Brown;
                else if (rengi == "Flower")
                    arka.Color = Colors.Purple;
                else if (rengi == "Forrest")
                    arka.Color = Colors.Green;
                else if (rengi == "Sky")
                    arka.Color = Colors.Cyan;

            }
            if (fonk.seviyebul() != null)
            {
                string Veri = fonk.seviyebul();
                if (Veri == "Beginner")
                {
                    xmiz = 9;
                    ymiz = 9;
                    dizi = new int[9, 9];
                    boyut = 60;
                    MayinSay = 10;
                    Seviyem = Veri;
                }
                else if (Veri == "Intermediate")
                {

                    xmiz = 16;
                    ymiz = 16;
                    dizi = new int[16, 16];
                    boyut = 60;
                    MayinSay = 40;
                    Seviyem = Veri;

                }
                else if (Veri == "Expert")
                {

                    xmiz = 16;
                    ymiz = 30;
                    dizi = new int[16, 30];
                    boyut = 60;
                    MayinSay = 99;
                    Seviyem = Veri;
                }

            }

            for (int i = 0; i < xmiz; i++)
            {
                ListBox sutun = new ListBox();
                ScrollViewer.SetVerticalScrollBarVisibility(sutun, ScrollBarVisibility.Disabled);
                List<Button> butonlar = new List<Button>();
                for (int j = 0; j < ymiz; j++)
                {
                    Button recto = new Button();
                    Thickness sitil = new Thickness();
                    sitil.Bottom = -11;
                    sitil.Left = -11;
                    sitil.Right = -11;
                    sitil.Top = -11;
                    recto.Margin = sitil;

                    Thickness sitil2 = new Thickness();
                    sitil2.Bottom = 1;
                    sitil2.Left = 1;
                    sitil2.Right = 1;
                    sitil2.Top = 1;
                    recto.BorderThickness = sitil2;
                    if (fonk.renginibul() != null)
                    {
                        string rengi = fonk.renginibul();
                        if (rengi == "Night")
                            recto.Background = new SolidColorBrush(Colors.Brown);
                        else if (rengi == "Flower")
                            recto.Background = new SolidColorBrush(Colors.Purple);
                        else if (rengi == "Forrest")
                            recto.Background = new SolidColorBrush(Colors.Green);
                        else if (rengi == "Sky")
                            recto.Background = new SolidColorBrush(Colors.Cyan);
                    }
                    recto.Content = " ";
                    recto.Name = "_" + (i).ToString() + "_" + (j).ToString();
                    recto.Height = boyut;
                    recto.Width = boyut;

                    recto.Click += recto_Click;
                    butonlar.Add(recto);
                }
                sutun.ItemsSource = butonlar;
                tableList.Add(sutun);

            }
            Buttonlar.ItemsSource = tableList;
            Button ara = tableList[3].Items[5] as Button;

        }


        void recto_Click(object sender, RoutedEventArgs e)
        {
            string eleman = ((Button)sender).Name.ToString();
            int x = Convert.ToInt32(eleman.Split('_')[1]);
            int y = Convert.ToInt32(eleman.Split('_')[2]);
            if (dizi[x, y] != -1)
            {
                if (KoyulanMayın < MayinSay)
                {

                    dizi[x, y] = -1;
                    Image img = new Image();
                    img.Source = new BitmapImage(new Uri("/Assets/flag.png", UriKind.Relative));
                    ((Button)sender).Content = img;
                    ((Button)sender).Background = new SolidColorBrush(Colors.Gray);
                    KoyulanMayın++;

                }
                else
                {
                    MessageBox.Show("Mine can't be more than. Please click Finish.");
                }
            }
            else
            {
                dizi[x, y] = 0;
                ((Button)sender).Content = "";
                if (fonk.renginibul() != null)
                    {
                        string rengi = fonk.renginibul();
                        if (rengi == "Night")
                            ((Button)sender).Background= new SolidColorBrush(Colors.Brown);
                        else if (rengi == "Flower")
                            ((Button)sender).Background= new SolidColorBrush(Colors.Purple);
                        else if (rengi == "Forrest")
                            ((Button)sender).Background= new SolidColorBrush(Colors.Green);
                        else if (rengi == "Sky")
                            ((Button)sender).Background= new SolidColorBrush(Colors.Cyan);
                    }
            }
        }

        private void ApplicationBarIconButton_Click_2(object sender, EventArgs e)
        {
            //YeniKaydet(dizi, durum, "da", "dsa");
        }
        private void BTNTamam_Click(object sender, RoutedEventArgs e)
        {
            dizi = fonk.MatrisiDoldur(dizi, Seviyem);
            durum = new int[xmiz, ymiz];
            YeniKaydet(dizi, durum, fonk.KullaniciBul(), fonk.SifreBul());
            Uri Uri = new Uri(String.Format("/MainPage.xaml"), UriKind.Relative);
            NavigationService.Navigate(Uri);

        }

        public void YeniKaydet(int[,] Degerler, int[,] Durumlar, string KAd, string KSifre)
        {
            KayitliOyun gidecek = new KayitliOyun();
            string veri = fonk.seviyebul();

            gidecek.DegerDizisi = Degerler;
            gidecek.DurumDizisi = Durumlar;
            gidecek.KullaniciAdi = KAd;
            gidecek.KullaniciSifresi = KSifre;
            gidecek.Seviyesi = veri;
            gidecek.Zaman = "0";
            gidecek.OyunAdi = KAd + "-" + DateTime.Now.ToString();
            gidecek.OyunCesidi = 0;
            Fonksiyonlar.YeniKayitXml(gidecek);
        }


        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            base.OnBackKeyPress(e);
        }
    }
}