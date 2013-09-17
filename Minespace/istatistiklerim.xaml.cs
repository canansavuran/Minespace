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
    public partial class istatistiklerim : PhoneApplicationPage
    {
        Fonksiyonlar fonk = new Fonksiyonlar();
        public istatistiklerim()
        {
            InitializeComponent();

            string ParseEdilecek;

            ParseEdilecek = Fonksiyonlar.istatistikXmlOku();


            List<istatistik> istatistikler = new List<istatistik>();
            var xml = XDocument.Parse(ParseEdilecek, LoadOptions.None);

            foreach (XElement bilgilerim in xml.Descendants("istatistik"))
            {

                istatistik istatistik = new istatistik();
                istatistik.KullaniciAdi = bilgilerim.Element("KullaniciAd").Value;
                istatistik.KullaniciSifresi = bilgilerim.Element("KullaniciSifre").Value;

                istatistik.enYuksekSkor = Convert.ToInt32(bilgilerim.Element("enYuksekSkor").Value);
                istatistik.KazanilanGame = Convert.ToInt32(bilgilerim.Element("KazanilanGame").Value);
                istatistik.KaybedilenGame = Convert.ToInt32(bilgilerim.Element("KaybedilenGame").Value);
                istatistik.OynananGame = Convert.ToInt32(bilgilerim.Element("OynananGame").Value);

                istatistikler.Add(istatistik);


            }
            foreach (istatistik istatistigim in istatistikler)
            {
                if (istatistigim.KullaniciAdi == fonk.KullaniciBul())
                {
                    if (istatistigim.KullaniciSifresi == fonk.SifreBul())
                    {
                        oynanan.Text = istatistigim.OynananGame.ToString();
                        kazanilan.Text = istatistigim.KazanilanGame.ToString();
                        kaybedilen.Text = istatistigim.KaybedilenGame.ToString();
                        enyuksek.Text = istatistigim.enYuksekSkor.ToString();
                        
                    }
                }

            }


        }

        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            base.OnBackKeyPress(e);
        }
    }
}