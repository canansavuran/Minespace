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
using System.Windows.Media;

namespace Minespace
{
    public partial class KayitliOyunPage : PhoneApplicationPage
    {
        public static XElement xmlmiz;
        Fonksiyonlar fonk = new Fonksiyonlar();
        public static List<ListBox> tableList = new List<ListBox>();
        int xmiz, ymiz, boyut;

        int satir, sutun;
        int[,] dizi;
        int[,] durum;
        bool Flag = false;

        public KayitliOyunPage()
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
                    boyut = 60;
                }
                else if (Veri == "Intermediate")
                {

                    xmiz = 16;
                    ymiz = 16;
                    boyut = 60;
                }
                else if (Veri == "Expert")
                {

                    xmiz = 16;
                    ymiz = 30;
                    boyut = 60;
                }


            }

            Buttonlar.Items.Clear();
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

                    butonlar.Add(recto);
                }
                sutun.ItemsSource = butonlar;
                tableList.Add(sutun);

            }
            Buttonlar.ItemsSource = tableList;


            Random rnd = new Random();
            int x, y;

            if (fonk.seviyebul() != null)
            {

                string Veri = fonk.seviyebul();
                if (Veri == "Beginner")
                {

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
                        x = rnd.Next(9);
                        y = rnd.Next(9);
                        dizi[x, y] = -1;
                        satir = 9;
                        sutun = 9;
                    }
                    dizi = fonk.MatrisiDoldur(dizi, Veri);
                }
                else if (Veri == "Intermediate")
                {
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
                        x = rnd.Next(16);
                        y = rnd.Next(16);
                        dizi[x, y] = -1;
                        satir = 16;
                        sutun = 16;
                    }
                    dizi = fonk.MatrisiDoldur(dizi, Veri);
                }
                else if (Veri == "Expert")
                {
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
                        x = rnd.Next(16);
                        y = rnd.Next(30);
                        dizi[x, y] = -1;
                        satir = 16;
                        sutun = 30;
                    }
                    dizi = fonk.MatrisiDoldur(dizi, Veri);
                }


            }
        }

        private void ApplicationBarIconButton_Click_2(object sender, EventArgs e)
        {
            //YeniKaydet(dizi, durum, "da", "dsa");
        }
        private void BTNFlag_Click(object sender, RoutedEventArgs e)
        {
            if (Flag == false)
            {
                Flag = true;
                ((Button)sender).Background = new SolidColorBrush(Colors.Red);
            }
            else
            {
                ((Button)sender).Background = new SolidColorBrush(Colors.Black);
                Flag = false;
            }
        }

        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            base.OnBackKeyPress(e);
        }

    }
}