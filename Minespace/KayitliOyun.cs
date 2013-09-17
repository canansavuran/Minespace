using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Minespace
{
    public class KayitliOyun
    {
        public string KullaniciAdi { get; set; }
        public string KullaniciSifresi { get; set; }
        public string Seviyesi { get; set; }
        public int[,] DegerDizisi { get; set; }
        public int[,] DurumDizisi { get; set; }
        public string Zaman { get; set; }
        public string OyunAdi { get; set; }
        public int OyunCesidi { get; set; }

    }

    public class Kisi
    {
        public string KullaniciAdi { get; set; }
        public string KullaniciSifresi { get; set; }
    }

    public class istatistik
    {
        public string KullaniciAdi { get; set; }
        public string KullaniciSifresi { get; set; }
        public int KazanilanGame { get; set; }
        public int KaybedilenGame { get; set; }
        public int OynananGame { get; set; }
        public int enYuksekSkor { get; set; }
    }
}
