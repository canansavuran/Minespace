using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Media;
using System.Xml;
using System.Windows.Documents;
using System.Xml.Linq;
using System.IO;


namespace Minespace
{

    public class Fonksiyonlar
    {

        public IsolatedStorageSettings appSettings = IsolatedStorageSettings.ApplicationSettings;
        public IsolatedStorageFile SavingFile = IsolatedStorageFile.GetUserStoreForApplication();

        public string renginibul()
        {
            SavingFile = IsolatedStorageFile.GetUserStoreForApplication();
            if (SavingFile.FileExists("Renk"))
            {
                using (IsolatedStorageFileStream fs = SavingFile.OpenFile("Renk", System.IO.FileMode.Open))
                {
                    if (fs != null)
                    {
                        // Reload the saved high-score data.
                        byte[] saveBytes = new byte[100];
                        int count = fs.Read(saveBytes, 0, 100);
                        if (count > 0)
                        {
                            string rengi = Encoding.Unicode.GetString(saveBytes, 0, count);
                            return rengi;
                        }
                    }
                }
            }

            return null;
        }

        public string KullaniciBul()
        {
            SavingFile = IsolatedStorageFile.GetUserStoreForApplication();
            if (SavingFile.FileExists("Kullanici"))
            {
                using (IsolatedStorageFileStream fs = SavingFile.OpenFile("Kullanici", System.IO.FileMode.Open))
                {
                    if (fs != null)
                    {
                        // Reload the saved high-score data.
                        byte[] saveBytes = new byte[100];
                        int count = fs.Read(saveBytes, 0, 100);
                        if (count > 0)
                        {
                            string kln = Encoding.Unicode.GetString(saveBytes, 0, count);
                            return kln;
                        }
                    }
                }
            }

            return null;
        }

        public string SifreBul()
        {
            SavingFile = IsolatedStorageFile.GetUserStoreForApplication();
            if (SavingFile.FileExists("Sifre"))
            {
                using (IsolatedStorageFileStream fs = SavingFile.OpenFile("Sifre", System.IO.FileMode.Open))
                {
                    if (fs != null)
                    {
                        // Reload the saved high-score data.
                        byte[] saveBytes = new byte[100];
                        int count = fs.Read(saveBytes, 0, 100);
                        if (count > 0)
                        {
                            string sfr = Encoding.Unicode.GetString(saveBytes, 0, count);
                            return sfr;
                        }
                    }
                }
            }

            return null;
        }

        public string seviyebul()
        {
            var SavingFile = IsolatedStorageFile.GetUserStoreForApplication();
            if (SavingFile.FileExists("Seviye"))
            {
                using (IsolatedStorageFileStream fs = SavingFile.OpenFile("Seviye", System.IO.FileMode.Open))
                {
                    if (fs != null)
                    {
                        // Reload the saved high-score data.
                        byte[] saveBytes = new byte[100];
                        int count = fs.Read(saveBytes, 0, 100);
                        if (count > 0)
                        {
                            string Veri = Encoding.Unicode.GetString(saveBytes, 0, count);
                            return Veri;
                        }
                    }
                }
            }
            return null;
        }
        public void ilkrengiata()
        {
            IsolatedStorageFileStream fs = null;
            using (fs = SavingFile.CreateFile("Renk"))
            {
                if (fs != null)
                {
                    // just overwrite the existing info for this example.
                    byte[] bytes = System.Text.UnicodeEncoding.Unicode.GetBytes("Night");
                    fs.Write(bytes, 0, bytes.Length);
                }
            }
        }

        public void ilkseviyeata()
        {
            IsolatedStorageFileStream fs = null;
            using (fs = SavingFile.CreateFile("Seviye"))
            {
                if (fs != null)
                {
                    // just overwrite the existing info for this example.
                    byte[] bytes = System.Text.UnicodeEncoding.Unicode.GetBytes("Beginner");
                    fs.Write(bytes, 0, bytes.Length);
                }
            }
        }

      

      
        int satir = 0, sutun = 0;
        public int[,] MatrisiDoldur(int[,] dizi, string Seviye)
        {
            if (Seviye == "Beginner")
            {
                satir = 9;
                sutun = 9;
            }
            else if (Seviye == "Intermediate")
            {
                satir = 16;
                sutun = 16;
            }
            else if (Seviye == "Expert")
            {
                satir = 16;
                sutun = 30;
            }

            int saymac = 0;
            /////////hesap yeri///////////////
            for (int i = 0; i < satir; i++)
            {
                for (int j = 0; j < sutun; j++)
                {

                    if (dizi[i, j] != -1)
                    {
                        saymac = 0;
                        if (i != 0 && j != 0)
                        {
                            if (dizi[i - 1, j - 1] == -1)
                                saymac++;
                            if (dizi[i - 1, j] == -1)
                                saymac++;
                            if (dizi[i, j - 1] == -1)
                                saymac++;
                            if (i != satir - 1)
                                if (dizi[i + 1, j - 1] == -1)
                                    saymac++;
                        }
                        else if (i == 0 && j != 0)
                        {
                            if (dizi[i, j - 1] == -1)
                                saymac++;
                            if (dizi[i + 1, j - 1] == -1)
                                saymac++;
                        }
                        else if (i != 0 && j == 0)
                        {
                            if (dizi[i - 1, j] == -1)
                                saymac++;
                        }

                        if (i != satir - 1 && j != sutun - 1)
                        {
                            if (dizi[i + 1, j + 1] == -1)
                                saymac++;
                            if (dizi[i, j + 1] == -1)
                                saymac++;
                            if (dizi[i + 1, j] == -1)
                                saymac++;
                            if (i != 0)
                                if (dizi[i - 1, j + 1] == -1)
                                    saymac++;
                        }
                        else if (i == satir - 1 && j != sutun - 1)
                        {
                            if (dizi[i, j + 1] == -1)
                                saymac++;
                            if (dizi[i - 1, j + 1] == -1)
                                saymac++;
                        }
                        else if (i != satir - 1 && j == sutun - 1)
                        {
                            if (dizi[i + 1, j] == -1)
                                saymac++;
                        }
                        dizi[i, j] = saymac;
                    }

                }
            }
            ////////////hesap bitişi/////////////

            return dizi;
        }

        /////////////Oyun Kayıt işlemleri//////////////


        public static void KayitXmlOlustur()
        {

            IsolatedStorageFile isstore = IsolatedStorageFile.GetUserStoreForApplication();

            try
            {
                isstore.DeleteFile("KayitliOyunlar.xml");
            }
            catch { };

            StreamWriter writeFile = new StreamWriter(new IsolatedStorageFileStream("KayitliOyunlar.xml", FileMode.OpenOrCreate, isstore));
            writeFile.WriteLine(("<?xml version='1.0' encoding='utf-8' ?>").Replace("'", Convert.ToString(Convert.ToChar(34))));
            writeFile.WriteLine("<Oyunlar>");
            writeFile.WriteLine("</Oyunlar>");
            writeFile.Close();
        }


        public static string KayitXmlOku()
        {
            IsolatedStorageFile isstore = IsolatedStorageFile.GetUserStoreForApplication();
            if (isstore.FileExists("KayitliOyunlar.xml"))
            {
                try
                {
                    using (StreamReader reader =
                        new StreamReader(isstore.OpenFile("KayitliOyunlar.xml",
                            FileMode.Open, FileAccess.Read)))
                    {
                        return reader.ReadToEnd().ToString();
                    }
                }
                catch
                {
                    return null;
                }
            }
            return null;

        }

        public static void YeniKayitXml(KayitliOyun degerler)
        {

            Fonksiyonlar fonk = new Fonksiyonlar();
            IsolatedStorageFile isstore = IsolatedStorageFile.GetUserStoreForApplication();
            IsolatedStorageFileStream bookfile = new IsolatedStorageFileStream("KayitliOyunlar.xml", System.IO.FileMode.Open, isstore);

            XDocument xmldetails = XDocument.Load(bookfile);
          
            string veri = fonk.seviyebul();
            int satir = 0, sutun = 0;
            if (veri == "Beginner")
            {
                satir = 9;
                sutun = 9;
            }
            else if (veri == "Intermediate")
            {
                satir = 16;
                sutun = 16;
            }
            else if (veri == "Expert")
            {
                satir = 16;
                sutun = 30;
            }

            int[] degerdizi = new int[sutun];
            //string oyunxml = @"Data/KayitliOyunlar.xml";
            int[] durumdizi = new int[sutun];


            var DegerDizim = new XElement("Degerler");
            for (int i = 0; i < satir; i++)
            {
                for (int j = 0; j < sutun; j++)
                {
                    degerdizi[j] = degerler.DegerDizisi[i, j];
                }
                var DegerDizisi = new XElement("Deger", degerdizi.Select(x => new XElement("degerim", x)));
                DegerDizim.Add(DegerDizisi);
            }

            var DurumlarDizisi = new XElement("Durumlar");
            for (int i = 0; i < satir; i++)
            {
                for (int j = 0; j < sutun; j++)
                {
                    durumdizi[j] = degerler.DurumDizisi[i, j];
                }
                var DurumDizisi = new XElement("Durum", durumdizi.Select(x => new XElement("durumum", x)));
                DurumlarDizisi.Add(DurumDizisi);
            }


            XElement oyun = new XElement("Oyun",
                                    new XElement("KullaniciAd", degerler.KullaniciAdi),
                                    new XElement("KullaniciSifre", degerler.KullaniciSifresi),
                                    new XElement("Seviye", degerler.Seviyesi),
                                    new XElement("Zaman", degerler.Zaman),
                                    new XElement("OyunAdi", degerler.OyunAdi),
                                    new XElement("OyunCesidi", degerler.OyunCesidi),
                                    DegerDizim,
                                    DurumlarDizisi);

            xmldetails.Root.Add(oyun);

                bookfile.Close();
                isstore.DeleteFile("KayitliOyunlar.xml");
                bookfile = new IsolatedStorageFileStream("KayitliOyunlar.xml", System.IO.FileMode.Create, isstore);

            xmldetails.Save(bookfile);
            bookfile.Close();
        }


        public static void deleteKayit(string adi)
        {
            IsolatedStorageFile isstore = IsolatedStorageFile.GetUserStoreForApplication();
            IsolatedStorageFileStream bookfile = new IsolatedStorageFileStream("KayitliOyunlar.xml", System.IO.FileMode.Open, isstore);

            XDocument xmldetails = XDocument.Load(bookfile);

            var details = from detail in xmldetails.Descendants("Oyun")
                          where detail.Element("OyunAdi").Value == Convert.ToString(adi)
                          select detail;

            foreach (XElement detail in details.ToArray())
            {
                detail.Remove();
            }
            bookfile.Close();
            isstore.DeleteFile("KayitliOyunlar.xml");
            bookfile = new IsolatedStorageFileStream("KayitliOyunlar.xml", System.IO.FileMode.Create, isstore);

            xmldetails.Save(bookfile);
            bookfile.Close();
        }


/// <summary>
///  Kullanıcı xml ile ilgili işlemler
/// </summary>
        public static void KullaniciXmlOlustur()
        {

            IsolatedStorageFile isstore = IsolatedStorageFile.GetUserStoreForApplication();

            try
            {
                isstore.DeleteFile("Kullanici.xml");
            }
            catch { };

            StreamWriter writeFile = new StreamWriter(new IsolatedStorageFileStream("Kullanici.xml", FileMode.OpenOrCreate, isstore));
            writeFile.WriteLine(("<?xml version='1.0' encoding='utf-8' ?>").Replace("'", Convert.ToString(Convert.ToChar(34))));
            writeFile.WriteLine("<Kisiler>");
            writeFile.WriteLine("</Kisiler>");
            writeFile.Close();
        }


        public static string KullaniciXmlOku()
        {
            IsolatedStorageFile isstore = IsolatedStorageFile.GetUserStoreForApplication();
            if (isstore.FileExists("Kullanici.xml"))
            {
                try
                {
                    using (StreamReader reader =
                        new StreamReader(isstore.OpenFile("Kullanici.xml",
                            FileMode.Open, FileAccess.Read)))
                    {
                        return reader.ReadToEnd().ToString();
                    }
                }
                catch
                {
                    return null;
                }
            }
            return null;

        }

        public static void YeniKullaniciXml(Kisi degerler)
        {

            Fonksiyonlar fonk = new Fonksiyonlar();
            IsolatedStorageFile isstore = IsolatedStorageFile.GetUserStoreForApplication();
            IsolatedStorageFileStream bookfile = new IsolatedStorageFileStream("Kullanici.xml", System.IO.FileMode.Open, isstore);

            XDocument xmldetails = XDocument.Load(bookfile);

            XElement oyun = new XElement("Kisi",
                                    new XElement("KullaniciAd", degerler.KullaniciAdi),
                                    new XElement("KullaniciSifre", degerler.KullaniciSifresi));

            xmldetails.Root.Add(oyun);

            bookfile.Close();
            isstore.DeleteFile("Kullanici.xml");
            bookfile = new IsolatedStorageFileStream("Kullanici.xml", System.IO.FileMode.Create, isstore);

            xmldetails.Save(bookfile);
            bookfile.Close();
        }

        

      

        ///////////Oyun kayıt işlemleri bitişi //////////////
        

        /// <summary>
        /// İstatistik Xml işlemleri
        /// </summary>
        public static void istatistikXmlOlustur()
        {

            IsolatedStorageFile isstore = IsolatedStorageFile.GetUserStoreForApplication();

            try
            {
                isstore.DeleteFile("istatistik.xml");
            }
            catch { };

            StreamWriter writeFile = new StreamWriter(new IsolatedStorageFileStream("istatistik.xml", FileMode.OpenOrCreate, isstore));
            writeFile.WriteLine(("<?xml version='1.0' encoding='utf-8' ?>").Replace("'", Convert.ToString(Convert.ToChar(34))));
            writeFile.WriteLine("<istatistikler>");
            writeFile.WriteLine("</istatistikler>");
            writeFile.Close();
        }

        public static string istatistikXmlOku()
        {
            IsolatedStorageFile isstore = IsolatedStorageFile.GetUserStoreForApplication();
            if (isstore.FileExists("istatistik.xml"))
            {
                try
                {
                    using (StreamReader reader =
                        new StreamReader(isstore.OpenFile("istatistik.xml",
                            FileMode.Open, FileAccess.Read)))
                    {
                        return reader.ReadToEnd().ToString();
                    }
                }
                catch
                {
                    return null;
                }
            }
            return null;

        }

        public static void YeniistatistikXml(string kullaniciadi,istatistik degerler)
        {
            delete_istatistik(kullaniciadi);
            Fonksiyonlar fonk = new Fonksiyonlar();
            IsolatedStorageFile isstore = IsolatedStorageFile.GetUserStoreForApplication();
            IsolatedStorageFileStream bookfile = new IsolatedStorageFileStream("istatistik.xml", System.IO.FileMode.Open, isstore);

            XDocument xmldetails = XDocument.Load(bookfile);

            XElement oyun = new XElement("istatistik",
                                    new XElement("KullaniciAd", degerler.KullaniciAdi),
                                    new XElement("KullaniciSifre", degerler.KullaniciSifresi),
                                     new XElement("enYuksekSkor", degerler.enYuksekSkor),
                                    new XElement("KazanilanGame", degerler.KazanilanGame),
                                    new XElement("KaybedilenGame",degerler.KaybedilenGame),
                                    new XElement("OynananGame",degerler.OynananGame));


            xmldetails.Root.Add(oyun);

            bookfile.Close();
            isstore.DeleteFile("istatistik.xml");
            bookfile = new IsolatedStorageFileStream("istatistik.xml", System.IO.FileMode.Create, isstore);

            xmldetails.Save(bookfile);
            bookfile.Close();
        }

        public static void delete_istatistik(string kullaniciadi)
        {
            IsolatedStorageFile isstore = IsolatedStorageFile.GetUserStoreForApplication();
            IsolatedStorageFileStream bookfile = new IsolatedStorageFileStream("istatistik.xml", System.IO.FileMode.Open, isstore);

            XDocument xmldetails = XDocument.Load(bookfile);

            var details = from detail in xmldetails.Descendants("istatistik")
                          where detail.Element("KullaniciAd").Value == kullaniciadi
                          select detail;

            foreach (XElement detail in details.ToArray())
            {
                detail.Remove();
            }
            bookfile.Close();
            isstore.DeleteFile("istatistik.xml");
            bookfile = new IsolatedStorageFileStream("istatistik.xml", System.IO.FileMode.Create, isstore);

            xmldetails.Save(bookfile);
            bookfile.Close();
        }



    }


}
