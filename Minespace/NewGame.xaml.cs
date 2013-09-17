using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Xml.Linq;
using System.IO.IsolatedStorage;
using System.IO;
using System.Windows.Threading;

namespace Minespace
{

    public partial class NewGame : PhoneApplicationPage
    {

        public static XElement xmlmiz;

        public static DateTime EndTime { get; set; }
        public DispatcherTimer dt = new DispatcherTimer();
        Fonksiyonlar fonk = new Fonksiyonlar();
        public static List<ListBox> tableList = new List<ListBox>();
        int xmiz, ymiz, boyut, kaydedildi=0,mayinyeri=0;

        int satir, sutun;
        int[,] dizi;
        int[,] durum;
        bool Flag = false, Ques = false;
        int Bayraksay = 0;
        private void MainME_MediaOpened(object sender, RoutedEventArgs e)
        {

            MediaE.Play();

        }
        public NewGame()
        {
            InitializeComponent();
            this.Loaded += NewGame_Loaded;
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
                    Bayraksay = 10;
                    mayinyeri = 10;
                    boyut = 60;
                }
                else if (Veri == "Intermediate")
                {

                    xmiz = 16;
                    ymiz = 16;
                    Bayraksay = 40;

                    mayinyeri = 40;
                    boyut = 60;
                }
                else if (Veri == "Expert")
                {

                    xmiz = 16;
                    ymiz = 30;
                    Bayraksay = 99;

                    mayinyeri =99;
                    boyut = 60;
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

                Buttonlar.Items.Clear();
                Buttonlar.ItemsSource = tableList;


                Random rnd = new Random();
                int x, y;

                if (fonk.seviyebul() != null)
                {

                    string Veri = fonk.seviyebul();
                    if (Veri == "Beginner")
                    {

                        satir = 9;
                        sutun = 9;
                        dizi = new int[9, 9];
                        durum = new int[9, 9];
                        for (int i = 0; i < 9; i++)
                        {
                            for (int j = 0; j < 9; j++)
                            {
                                durum[i, j] = 0;
                            }
                        }
                        
                        for (int i = 0; i < 10; i++)
                        {
                        tekrar:
                            x = rnd.Next(9);
                            y = rnd.Next(9);
                            if (dizi[x, y] == -1)
                                goto tekrar;

                            dizi[x, y] = -1;
                            
                            
                        }
                        dizi = fonk.MatrisiDoldur(dizi, Veri);
                      
                        
                    }
                    else if (Veri == "Intermediate")
                    {
                            satir = 16;
                            sutun = 16;
                        dizi = new int[16, 16];
                        durum = new int[16, 16];
                        for (int i = 0; i < 16; i++)
                        {
                            for (int j = 0; j < 16; j++)
                            {
                                durum[i, j] = 0;
                            }
                        }
                        for (int i = 0; i < 40; i++)
                        {
                        tekrar:
                            x = rnd.Next(16);
                            y = rnd.Next(16);

                            if (dizi[x, y] == -1)
                                goto tekrar;

                            dizi[x, y] = -1;
                        }
                        dizi = fonk.MatrisiDoldur(dizi, Veri);
                       
                    }
                    else if (Veri == "Expert")
                    {
                            satir = 16;
                            sutun = 30;
                        dizi = new int[16, 30];
                        durum = new int[16, 30];
                        for (int i = 0; i < 16; i++)
                        {
                            for (int j = 0; j < 30; j++)
                            {
                                durum[i, j] = 0;
                            }
                        }
                        for (int i = 0; i < 99; i++)
                        {
                        tekrar:
                            x = rnd.Next(16);
                            y = rnd.Next(30);

                            if (dizi[x, y] == -1)
                                goto tekrar;
                            dizi[x, y] = -1;
                        }
                        dizi = fonk.MatrisiDoldur(dizi, Veri);
                    }


                }

                minecount.Text = "Mine : " + Bayraksay.ToString();
                ZamanSay(DateTime.Now);
            
        }

        void NewGame_Loaded(object sender, RoutedEventArgs e)
        {

            IsolatedStorageFile isstore = IsolatedStorageFile.GetUserStoreForApplication();
            if (isstore.FileExists("KayitliOyunlar.xml"))
            {
                //MessageBox.Show("Dosya var");
            }
            else
            {
                Fonksiyonlar.KayitXmlOlustur();
            }


            IsolatedStorageFile isstore2 = IsolatedStorageFile.GetUserStoreForApplication();
            if (isstore2.FileExists("istatistik.xml"))
            {
                //MessageBox.Show("Dosya var");
            }
            else
            {
                // MessageBox.Show("Dosya yok");
                Fonksiyonlar.istatistikXmlOlustur();
            }
        }

        void recto_Click(object sender, RoutedEventArgs e)
        {

            minecount.Text = "Mine : " + Bayraksay.ToString();
            string eleman = ((Button)sender).Name.ToString();
            int x = Convert.ToInt32(eleman.Split('_')[1]);
            int y = Convert.ToInt32(eleman.Split('_')[2]);
            int yer = dizi[x, y];
            if (Flag == false && Ques == false)
            {
                if (durum[x, y] != -2 && durum[x, y] != -1)
                {
                    if (yer != 0 && yer != -1)
                    {
                        ((Button)sender).Background = new SolidColorBrush(Colors.Gray);

                        ((Button)sender).Content = yer.ToString();
                        durum[x, y] = 1;
                    }
                    if (yer == 0)
                    {
                        ((Button)sender).IsEnabled = false;
                        Image img = new Image();
                        ((Button)sender).Content = img;

                        durum[x, y] = 1;
                        etrafTara(x, y, dizi);

                    }
                    if (yer == -1)
                    {
                        MessageBox.Show("..Game Over...");
                        MediaE.Source = new Uri("/Sound/patladi.mp3", UriKind.Relative);
                        MediaE.Position = new TimeSpan(0);


                        int skor = 0;
                        istatistik benimist = new istatistik();
                        try
                        {
                            benimist = KisininistatistikBul(fonk.KullaniciBul(), fonk.SifreBul());
                            
                            if (benimist == null)
                            {
                                istatistikKaydet(fonk.KullaniciBul(), fonk.SifreBul(), 1, 0, 1, skor);
                            }
                            else
                            {
                                skor = benimist.enYuksekSkor;
                                istatistikKaydet(fonk.KullaniciBul(), fonk.SifreBul(), (benimist.OynananGame + 1), benimist.KazanilanGame, (benimist.KaybedilenGame + 1), skor);
                            }
                        }
                        catch { }
                        Uri Uri = new Uri(String.Format("/MainPage.xaml"), UriKind.Relative);
                        NavigationService.Navigate(Uri);
                    }
                }
                else if (durum[x, y] == -2)
                {
                    if (fonk.renginibul() != null)
                    {
                        string rengi = fonk.renginibul();
                        if (rengi == "Night")
                            ((Button)sender).Background = new SolidColorBrush(Colors.Brown);
                        else if (rengi == "Flower")
                            ((Button)sender).Background = new SolidColorBrush(Colors.Purple);
                        else if (rengi == "Forrest")
                            ((Button)sender).Background = new SolidColorBrush(Colors.Green);
                        else if (rengi == "Sky")
                            ((Button)sender).Background = new SolidColorBrush(Colors.Cyan);
                    }
                    ((Button)sender).Content = "";
                    durum[x, y] = 0;
                }
                else if (durum[x, y] == -1)
                {
                    Image img = new Image();
                    img.Source = new BitmapImage(new Uri("/Assets/question.png", UriKind.Relative));
                    ((Button)sender).Content = img;
                    ((Button)sender).Background = new SolidColorBrush(Colors.Gray);
                    durum[x, y] = -2;
                    Bayraksay++;
                }
            }
            else if (Flag == true)
            {
                ///////Bayrak olan bi yere tekrar bayrak konmasın die
                if (durum[x, y] != -1)
                {
                    //////////bayrak sayacı
                    if (Bayraksay != 0)
                    {
                        if (durum[x, y] != 1)
                        {
                            Image img = new Image();
                            img.Source = new BitmapImage(new Uri("/Assets/flag.png", UriKind.Relative));
                            ((Button)sender).Content = img;
                            ((Button)sender).Background = new SolidColorBrush(Colors.Gray);
                            Bayraksay--;
                            durum[x, y] = -1;

                            minecount.Text = "Mine : " + Bayraksay.ToString();
                            if (bittiMi() == true)
                            {
                                int Puan = PuanHesapla(buttonZaman.Content.ToString());
                                MessageBox.Show("Congratulations.. You Win.." + Puan.ToString());
                                MediaE.Source = new Uri("kazandi.mp3", UriKind.Relative);
                                MediaE.Position = new TimeSpan(0);
                                //İstatistik burada yazılacak....
                                /////
                                ///
                                ///
                                //


                                int skor = Puan;
                                istatistik benimist = new istatistik();
                                
                                try
                                {
                                    benimist = KisininistatistikBul(fonk.KullaniciBul(), fonk.SifreBul());
                                   
                                    if (benimist == null)
                                    {
                                        istatistikKaydet(fonk.KullaniciBul(), fonk.SifreBul(), 1, 1, 0, skor);
                                    }
                                    else
                                    {
                                        int eny = benimist.enYuksekSkor;
                                        if (skor <= eny)
                                            skor = eny;
                                        istatistikKaydet(fonk.KullaniciBul(), fonk.SifreBul(), (benimist.OynananGame + 1), (benimist.KazanilanGame + 1), benimist.KaybedilenGame, skor);
                                    }
                                }
                                catch { }
                                benimist = KisininistatistikBul(fonk.KullaniciBul(),fonk.SifreBul());
                                



                                Uri Uri = new Uri(String.Format("/MainPage.xaml"), UriKind.Relative);
                                NavigationService.Navigate(Uri);


                            }
                        }
                    }
                    else
                        MessageBox.Show("Flag can't be more than!");
                }
            }
            else if (Ques == true)
            {
                if (durum[x, y] != 1)
                {
                    Image img = new Image();
                    img.Source = new BitmapImage(new Uri("/Assets/question.png", UriKind.Relative));
                    ((Button)sender).Content = img;
                    ((Button)sender).Background = new SolidColorBrush(Colors.Gray);
                    durum[x, y] = -2;
                }
            }


        }

        public void etrafTara(int x, int y, int[,] dizi)
        {

            etrafTara1(x, y, dizi);
            etrafTara2(x, y, dizi);
            etrafTara3(x, y, dizi);
            etrafTara4(x, y, dizi);
            etrafTara5(x, y, dizi);
            etrafTara6(x, y, dizi);
            etrafTara7(x, y, dizi);
            etrafTara8(x, y, dizi);

        }


        public void etrafTara1(int x, int y, int[,] dizi)
        {
            //////////////////////////
            if (x + 1 < satir)
                if (dizi[(x + 1), y] == 0)
                {
                    etrafTara1((x + 1), y, dizi);
                    etrafTara5((x + 1), y, dizi);
                    etrafTara7((x + 1), y, dizi);
                    Button ara = tableList[(x + 1)].Items[(y)] as Button;
                    ara.IsEnabled = false;
                    if (durum[(x + 1), y] == -1)
                    {
                        ara.Content = "";
                        Bayraksay++;
                    }
                    durum[(x + 1), y] = 1;
                }

                else if (x + 1 < satir)
                    if (dizi[(x + 1), y] != 0)
                    {
                        if (durum[(x + 1), y] == -1)
                        {
                            Bayraksay++;
                        }
                        Button ara = tableList[(x + 1)].Items[(y)] as Button;
                        ara.Content = dizi[(x + 1), y].ToString();
                        ara.Background = new SolidColorBrush(Colors.Gray);
                        durum[(x + 1), y] = 1;
                        //((Button)adi).Content = dizi[(x + 1), y].ToString();
                    }

        }
        public void etrafTara2(int x, int y, int[,] dizi)
        {
            ///////////////////////////////////
            if (x - 1 > -1)
                if (dizi[(x - 1), y] == 0)
                {
                    etrafTara2((x - 1), y, dizi);
                    etrafTara6((x - 1), y, dizi);
                    etrafTara8((x - 1), y, dizi);
                    Button ara = tableList[(x - 1)].Items[(y)] as Button;
                    ara.IsEnabled = false;
                    if (durum[(x - 1), y] == -1)
                    {
                        ara.Content = "";
                        Bayraksay++;
                    }
                    durum[(x - 1), y] = 1;


                }

                else if (x - 1 > -1)
                    if (dizi[(x - 1), y] != 0)
                    {
                        if (durum[(x - 1), y] == -1)
                        {
                            Bayraksay++;
                        }
                        Button ara = tableList[(x - 1)].Items[(y)] as Button;
                        ara.Content = dizi[(x - 1), y].ToString();
                        ara.Background = new SolidColorBrush(Colors.Gray);
                        durum[(x - 1), y] = 1;
                    }

        }
        public void etrafTara3(int x, int y, int[,] dizi)
        {

            //////////////////////////////////////

            if (y + 1 < sutun)
                if (dizi[x, (y + 1)] == 0)
                {

                    etrafTara3(x, (y + 1), dizi);
                    etrafTara8(x, (y + 1), dizi);
                    etrafTara5(x, (y + 1), dizi);
                    Button ara = tableList[(x)].Items[(y + 1)] as Button;
                    ara.IsEnabled = false;
                    if (durum[x, (y + 1)] == -1)
                    {
                        ara.Content = "";
                        Bayraksay++;
                    }
                    durum[x, (y + 1)] = 1;

                }
                else if (y + 1 < sutun)
                    if (dizi[x, (y + 1)] != 0)
                    {
                        if (durum[x, (y + 1)] == -1)
                        {
                            Bayraksay++;
                        }
                        Button ara = tableList[(x)].Items[(y + 1)] as Button;
                        ara.Content = dizi[x, (y + 1)].ToString();
                        ara.Background = new SolidColorBrush(Colors.Gray);
                        durum[x, (y + 1)] = 1;
                    }

            ////////////////////

        }
        public void etrafTara4(int x, int y, int[,] dizi)
        {
            if (y - 1 > -1)
                if (dizi[x, (y - 1)] == 0)
                {


                    etrafTara4(x, (y - 1), dizi);
                    etrafTara7(x, (y - 1), dizi);
                    etrafTara6(x, (y - 1), dizi);
                    Button ara = tableList[(x)].Items[(y - 1)] as Button;
                    ara.IsEnabled = false;
                    if (durum[x, (y - 1)] == -1)
                    {
                        ara.Content = "";
                        Bayraksay++;
                    }
                    durum[x, (y - 1)] = 1;
                }

                else if (y - 1 > -1)
                    if (dizi[x, (y - 1)] != 0)
                    {
                        if (durum[x, (y - 1)] == -1)
                        {
                            Bayraksay++;
                        }
                        Button ara = tableList[(x)].Items[(y - 1)] as Button;
                        ara.Content = dizi[x, (y - 1)].ToString();
                        ara.Background = new SolidColorBrush(Colors.Gray);
                        durum[x, (y - 1)] = 1;
                    }
            //////////////////////
        }
        public void etrafTara5(int x, int y, int[,] dizi)
        {

            if (x + 1 < satir && y + 1 < sutun)
                if (dizi[(x + 1), (y + 1)] == 0)
                {

                    etrafTara5((x + 1), (y + 1), dizi);

                    if (x + 1 < satir && y - 1 > -1)
                        if (dizi[(x + 1), (y - 1)] != 0)
                        {
                            etrafTara1((x + 1), (y + 1), dizi);

                            if (x + 2 < satir)
                                if (dizi[(x + 2), (y)] != 0)
                                    etrafTara7((x + 1), (y + 1), dizi);

                        }

                    if (y + 1 < sutun)
                        if (dizi[(x), (y + 1)] != 0)
                        {
                            etrafTara3((x + 1), (y + 1), dizi);

                            if (y + 2 < sutun)
                                if (dizi[(x), (y + 2)] != 0)
                                    etrafTara8((x + 1), (y + 1), dizi);
                        }

                    Button ara = tableList[(x + 1)].Items[(y + 1)] as Button;
                    ara.IsEnabled = false;
                    if (durum[(x + 1), (y + 1)] == -1)
                    {
                        ara.Content = "";
                        Bayraksay++;
                    }
                    durum[(x + 1), (y + 1)] = 1;
                }
                else if (x + 1 < satir && y + 1 < sutun)
                    if (dizi[(x + 1), (y + 1)] != 0)
                    {
                        if (durum[(x + 1), (y + 1)] == -1)
                        {
                            Bayraksay++;
                        }
                        Button ara = tableList[(x + 1)].Items[(y + 1)] as Button;
                        ara.Background = new SolidColorBrush(Colors.Gray);
                        ara.Content = dizi[(x + 1), (y + 1)].ToString();
                        durum[(x + 1), (y + 1)] = 1;
                    }
            ////////////////////////
        }
        public void etrafTara6(int x, int y, int[,] dizi)
        {
            if (x - 1 > -1 && y - 1 > -1)
                if (dizi[(x - 1), (y - 1)] == 0)
                {

                    etrafTara6((x - 1), (y - 1), dizi);

                    if (x - 1 > -1)
                        if (dizi[(x - 1), (y)] != 0)
                        {
                            etrafTara2((x - 1), (y - 1), dizi);


                            if (x - 2 > -1)
                                if (dizi[(x - 2), (y)] != 0)
                                    etrafTara8((x - 1), (y - 1), dizi);
                        }


                    if (y - 1 > -1)
                        if (dizi[(x), (y - 1)] != 0)
                        {
                            etrafTara4((x - 1), (y - 1), dizi);

                            if (y - 2 > -1)
                                if (dizi[(x), (y - 2)] != 0)
                                    etrafTara7((x - 1), (y - 1), dizi);
                        }

                        Button ara = tableList[(x - 1)].Items[(y - 1)] as Button;
                        ara.IsEnabled = false;
                        if (durum[(x - 1), (y - 1)] == -1)
                        {
                            ara.Content = "";
                            Bayraksay++;
                        }
                        durum[(x - 1), (y - 1)] = 1;
                    
                }
                else if (x - 1 > -1 && y - 1 > -1)
                    if (dizi[(x - 1), (y - 1)] != 0)
                    {
                        if (durum[(x - 1), (y - 1)] == -1)
                        {
                            Bayraksay++;
                        }
                        Button ara = tableList[(x - 1)].Items[(y - 1)] as Button;
                        ara.Background = new SolidColorBrush(Colors.Gray);
                        ara.Content = dizi[(x - 1), (y - 1)].ToString();
                        durum[(x - 1), (y - 1)] = 1;
                    }
            //////////////////

        }
        public void etrafTara7(int x, int y, int[,] dizi)
        {

            if (x + 1 < satir && y - 1 > -1)
                if (dizi[(x + 1), (y - 1)] == 0)
                {

                    etrafTara7((x + 1), (y - 1), dizi);

                    if (y - 1 > -1)
                        if (dizi[(x), (y - 1)] != 0)
                        {
                            etrafTara4((x + 1), (y - 1), dizi);

                            if (y - 2 > -1)
                                if (dizi[(x), (y - 2)] != 0)
                                    etrafTara6((x + 1), (y - 1), dizi);
                        }




                    if (x + 1 < satir)
                        if (dizi[(x + 1), (y)] != 0)
                        {
                            etrafTara1((x + 1), (y - 1), dizi);

                            if (x + 2 < satir)
                                if (dizi[(x + 2), (y)] != 0)

                                    etrafTara5((x + 1), (y - 1), dizi);
                        }

                        Button ara = tableList[(x + 1)].Items[(y - 1)] as Button;
                        ara.IsEnabled = false;
                        if (durum[(x + 1), (y - 1)] == -1)
                        {
                            ara.Content = "";
                            Bayraksay++;
                        }
                        durum[(x + 1), (y - 1)] = 1;
                    
                }
                else if (x + 1 < satir && y - 1 > -1)
                    if (dizi[(x + 1), (y - 1)] != 0)
                    {

                        if (durum[(x + 1), (y - 1)] == -1)
                        {
                            Bayraksay++;
                        }
                        Button ara = tableList[(x + 1)].Items[(y - 1)] as Button;
                        ara.Background = new SolidColorBrush(Colors.Gray);
                        ara.Content = dizi[(x + 1), (y - 1)].ToString();
                        durum[(x + 1), (y - 1)] = 1;
                    }
            ///////////////////


        }
        public void etrafTara8(int x, int y, int[,] dizi)
        {
            if (x - 1 > -1 && y + 1 < sutun)
                if (dizi[(x - 1), (y + 1)] == 0)
                {

                    etrafTara8((x - 1), (y + 1), dizi);

                    if (y + 1 < sutun)
                        if (dizi[(x), (y + 1)] != 0)
                        {
                            etrafTara3((x - 1), (y + 1), dizi);

                            if (y + 2 < sutun)
                                if (dizi[(x), (y + 2)] != 0)
                                    etrafTara5((x - 1), (y + 1), dizi);

                        }

                    if (x - 1 > -1)
                        if (dizi[(x - 1), (y)] != 0)
                        {
                            etrafTara2((x - 1), (y + 1), dizi);

                            if (x - 2 > -1)
                                if (dizi[(x - 2), (y)] != 0)
                                    etrafTara6((x - 1), (y + 1), dizi);
                        }
                        Button ara = tableList[(x - 1)].Items[(y + 1)] as Button;
                        ara.IsEnabled = false;
                        if (durum[(x - 1), (y + 1)] == -1)
                        {
                            ara.Content = "";
                            Bayraksay++;
                        }
                        durum[(x - 1), (y + 1)] = 1;
                   
                }
                else if (x - 1 > -1 && y + 1 < sutun)
                    if (dizi[(x - 1), (y + 1)] != 0 )
                    {
                        if (durum[(x - 1), (y + 1)] == -1)
                        {
                            Bayraksay++;
                        }
                        Button ara = tableList[(x - 1)].Items[(y + 1)] as Button;
                        ara.Background = new SolidColorBrush(Colors.Gray);
                        ara.Content = dizi[(x - 1), (y + 1)].ToString();
                        durum[(x - 1), (y + 1)] = 1;
                    }
            ///////////////////////

        }


        private void ContentPanel_Loaded(object sender, RoutedEventArgs e)
        {

        }

        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            if (kaydedildi == 0)
            {
                MessageBoxResult m = MessageBox.Show("Do you want to save game?", "Are you sure?", MessageBoxButton.OKCancel);
                if (m == MessageBoxResult.Cancel)
                {
                    base.OnBackKeyPress(e);
                }
                else if (m == MessageBoxResult.OK)
                {

                    YeniKaydet(dizi, durum, fonk.KullaniciBul(), fonk.SifreBul());
                    MessageBox.Show("Saved Game..");
                    Uri Uri = new Uri(String.Format("/MainPage.xaml"), UriKind.Relative);
                    NavigationService.Navigate(Uri);
                }
            }
            else
                base.OnBackKeyPress(e);
        }


        private void BTNFlag_Click(object sender, RoutedEventArgs e)
        {
            if (Flag == false)
            {
                Flag = true;
                Ques = false;
                ((Button)sender).Background = new SolidColorBrush(Colors.Red);
                BTNQues.Background = new SolidColorBrush(Colors.Black);
            }
            else
            {
                ((Button)sender).Background = new SolidColorBrush(Colors.Black);
                Flag = false;
            }
        }


        private void ApplicationBarIconButton_Click_2(object sender, EventArgs e)
        {
            YeniKaydet(dizi, durum, fonk.KullaniciBul(), fonk.SifreBul());
            MessageBox.Show("Saved Game..");
            Uri Uri = new Uri(String.Format("/MainPage.xaml"), UriKind.Relative);
            NavigationService.Navigate(Uri);
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

        public void YeniKaydet(int[,] Degerler, int[,] Durumlar, string KAd, string KSifre)
        {
            kaydedildi = 1;
            KayitliOyun gidecek = new KayitliOyun();
            string veri = fonk.seviyebul();

            gidecek.DegerDizisi = Degerler;
            gidecek.DurumDizisi = Durumlar;
            gidecek.KullaniciAdi = KAd;
            gidecek.KullaniciSifresi = KSifre;
            gidecek.Seviyesi = veri;
            gidecek.Zaman = buttonZaman.Content.ToString();
            gidecek.OyunAdi = DateTime.Now.ToString();
            gidecek.OyunCesidi = 1;
            Fonksiyonlar.YeniKayitXml(gidecek);
    
        }

        private void BTNQues_Click(object sender, RoutedEventArgs e)
        {
            if (Ques == false)
            {
                Ques = true;
                Flag = false;
                ((Button)sender).Background = new SolidColorBrush(Colors.Red);
                BTNFlag.Background = new SolidColorBrush(Colors.Black);
            }
            else
            {
                ((Button)sender).Background = new SolidColorBrush(Colors.Black);
                Ques = false;
            }
        }
        public int PuanHesapla(string GelenZaman)
        {
            string[] zamanBol = GelenZaman.Split(':');
            int Saniyem = (((Convert.ToInt32(zamanBol[0]) * 60) + Convert.ToInt32(zamanBol[1])) * 60) + Convert.ToInt32(zamanBol[2]);

            string Veri = fonk.seviyebul();
            if (Veri == "Beginner")
            {
                
                return 100000/Saniyem;
            }
            else if (Veri == "Intermediate")
            {
                return 400000 / Saniyem;
            }
            else if (Veri == "Expert")
            {
                return 1200000 / Saniyem;
            }
            return 0;
        }


        public void ZamanSay(DateTime start)
        {

            DispatcherTimer timer = new DispatcherTimer();

            timer.Tick +=
                delegate(object s, EventArgs args)
                {
                    TimeSpan time = (DateTime.Now - start);
                  

                    buttonZaman.Content = string.Format("{0:D2}:{1:D2}:{2:D2}", time.Hours, time.Minutes, time.Seconds);
                };

            timer.Interval = new TimeSpan(0, 0, 1); // one second
            timer.Start();
        }
        int sayici;
        public bool bittiMi()
        {
            sayici = 0;
            for (int i = 0; i < xmiz; i++)
            {
                for (int j = 0; j < ymiz; j++)
                {
                    if (durum[i, j] == -1)
                    {
                        if (dizi[i, j] == -1)
                            sayici++;
                    }


                }
            }
            if (sayici == mayinyeri)
            {
                return true;
            }

            return false;
            
        }

        public void istatistikKaydet(string KAd, string KSifre,int oynananoyun, int kazanilanoyun,int kaybedilenoyun,int enyuksek)
        {
            istatistik ist = new istatistik();
            ist.KullaniciAdi = KAd;
            ist.KullaniciSifresi = KSifre;
            ist.OynananGame = oynananoyun;
            ist.KazanilanGame = kazanilanoyun;
            ist.KaybedilenGame = kaybedilenoyun;
            ist.enYuksekSkor = enyuksek;

            Fonksiyonlar.YeniistatistikXml(KAd, ist);
        }
        public istatistik KisininistatistikBul(String adi, String sifre)
        {
            string ParseEdilecek;

            ParseEdilecek = Fonksiyonlar.istatistikXmlOku();


            List<istatistik> istatistikler = new List<istatistik>();
            var xml = XDocument.Parse(ParseEdilecek, LoadOptions.None);

            foreach (XElement bilgilerim in xml.Descendants("istatistik"))
            {

                istatistik istatistik = new istatistik();
                istatistik.KullaniciAdi = bilgilerim.Element("KullaniciAd").Value;
                istatistik.KullaniciSifresi = bilgilerim.Element("KullaniciSifre").Value;

                istatistik.enYuksekSkor = Convert.ToInt32( bilgilerim.Element("enYuksekSkor").Value);
                istatistik.KazanilanGame = Convert.ToInt32(bilgilerim.Element("KazanilanGame").Value);
                istatistik.KaybedilenGame = Convert.ToInt32(bilgilerim.Element("KaybedilenGame").Value);
                istatistik.OynananGame = Convert.ToInt32(bilgilerim.Element("OynananGame").Value);

                istatistikler.Add(istatistik);

                                   
            }
            foreach (istatistik istatistigim in istatistikler)
            {
                if (istatistigim.KullaniciAdi == adi)
                {
                    if (istatistigim.KullaniciSifresi == sifre)
                    {
                        return istatistigim;
                    }
                }

            }
            return null;


        }
    }
}