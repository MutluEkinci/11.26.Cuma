using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _26._11.Cuma
{

    public interface IKirilabilen
    {
        bool KirikMi { get; set; }
    }
    public interface IBozulabilen
    {
        DateTime UretimTarihi { get; set; }
        DateTime SKT { get; set; }
    }
    class Market<T> where T : Urun
    {
        List<T> _urunler = new List<T>();
        public void Ekle(T t)
        {
            _urunler.Add(t);
        }
        public List<T> TumUrunler()
        {
            return _urunler;
        }
        public List<T> KırıkUrunler()
        {
            List<T> liste = new List<T>();
            foreach (var urun in _urunler)
            {
                IKirilabilen kirikUrun = urun as IKirilabilen;
                if (kirikUrun != null && kirikUrun.KirikMi)
                    liste.Add(urun);
            }
            return liste;
        }
        public List<T> BozukUrunler()
        {
            List<T> liste = new List<T>();
            foreach (var urun in _urunler)
            {
                IBozulabilen bozukUrun = urun as IBozulabilen;
                if (bozukUrun != null && DateTime.Now >= bozukUrun.SKT)
                    liste.Add(urun);
            }
            return liste;
        }
        public List<T> BozulmayaYaklasanUrunler()
        {
            List<T> liste = new List<T>();
            foreach (var urun in _urunler)
            {
                int fark = -1;
                IBozulabilen bozukUrun = urun as IBozulabilen;
                if (bozukUrun != null)
                {
                    fark = (bozukUrun.SKT - DateTime.Now).Days;
                    if (fark > 0 && fark <= 3)
                        liste.Add(urun);
                }
            }
            return liste;
        }
        public List<T> YakındaBozulacakUrunler
        {
            get
            {
                List<T> liste = new List<T>();
                foreach (var urun in _urunler)
                {
                    int fark = -1;
                    IBozulabilen bozukUrun = urun as IBozulabilen;
                    if (bozukUrun != null)
                    {
                        fark = (bozukUrun.SKT - DateTime.Now).Days;
                        if (fark > 0 && fark <= 3)
                            liste.Add(urun);
                    }
                }
                return liste;
            }
        }
    }
    abstract class Urun
    {
        public int ID { get; set; }
        public string Adi { get; set; }
        public decimal Fiyat { get; set; }
        public virtual string Yaz()
        {
            return String.Format("{0} {1} {2}", ID, Adi, Fiyat);
        }
    }
    class Sut : Urun, IBozulabilen
    {
        public DateTime SKT { get; set; }
        public DateTime UretimTarihi { get; set; }
        public override string Yaz()
        {
            return String.Format("{0} {1} {2} {3} {4}", ID, Adi, Fiyat, UretimTarihi, SKT);
        }

    }
    class Peynir : Urun, IBozulabilen
    {
        public DateTime UretimTarihi { get; set; }
        public DateTime SKT { get; set; }
        public override string Yaz()
        {
            return String.Format("{0} {1} {2} {3} {4}", ID, Adi, Fiyat, UretimTarihi, SKT);
        }
    }
    class Bardak : Urun, IKirilabilen
    {
        public bool KirikMi { get; set; }
        public override string Yaz()
        {
            return String.Format("{0} {1} {2} {3}", ID, Adi, Fiyat, KirikMi);
        }
    }
    class Yumurta : Urun, IKirilabilen, IBozulabilen
    {
        public bool KirikMi { get; set; }
        public DateTime UretimTarihi { get; set; }
        public DateTime SKT { get; set; }
        public override string Yaz()
        {
            return String.Format("{0} {1} {2} {3} {4} {5}", ID, Adi, Fiyat, KirikMi, UretimTarihi, SKT);
        }
    }
    class Pecete : Urun
    {
    }
    class Sunger : Urun
    {
    }
    class Program
    {
        static void Listele(List<Urun> liste)
        {
            Console.WriteLine();
            foreach (var urun in liste)
            {
                Console.WriteLine(urun.Yaz());
            }
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            //Soru 1:Bir market içinde bozulabilen(sut,peynir)urunlar,kırılabilen urunler (bardak,yumurta) , bir de normal urunler(pecete,sunger) satılmaktadır. Bu urunleri tutan bir yazılımı gelistiriniz.Urun ekleme olmali,Rapor olarakta tum urunleri listelemeli,bozulan(tarihi geçmiş) urunleri ,bozulması yaklasan urunleri ,bir de kirik urunleri listeleyen raporlari hazirlayiniz.

            Market<Urun> market = new Market<Urun>();
            market.Ekle(new Yumurta { ID = 11, Adi = "Yumurta S Boy", Fiyat = 32, KirikMi = true, UretimTarihi = DateTime.Parse("10/10/2021"), SKT = DateTime.Parse("11/11/2021") });
            market.Ekle(new Yumurta { ID = 21, Adi = "Yumurta M Boy", Fiyat = 35, KirikMi = false, UretimTarihi = DateTime.Parse("10/10/2021"), SKT = DateTime.Parse("28/11/2021") });
            market.Ekle(new Pecete { ID = 32, Adi = "Pecete", Fiyat = 6 });
            market.Ekle(new Sunger { ID = 62, Adi = "Sunger 5'li", Fiyat = 10.95M });
            market.Ekle(new Bardak { ID = 99, Adi = "Cay Bardağı", Fiyat = 48, KirikMi = false });
            market.Ekle(new Sut { ID = 81, Adi = "Keçi Sütü", Fiyat = 15, UretimTarihi = DateTime.Parse("11/12/2021"), SKT = DateTime.Parse("28/12/2021") });

            int secim=-1;
            do
            {
                Console.WriteLine("1-Tüm Ürünler");
                Console.WriteLine("2-Bozuk Ürünler");
                Console.WriteLine("3-Bozulmaya Yaklaşan Ürünler");
                Console.WriteLine("4-Kırık Ürünler");
                Console.WriteLine("0-Çıkış");
                Console.WriteLine("Seçiminiz..:");
                secim = int.Parse(Console.ReadLine());
                switch (secim)
                {
                    case 1:
                        Listele(market.TumUrunler());
                    break;
                    case 2:
                        Listele(market.BozukUrunler());
                    break;
                    case 3:
                        Listele(market.BozulmayaYaklasanUrunler());
                    break;
                    case 4:
                        Listele(market.KırıkUrunler());
                    break;
                }
            } while (secim!=0);
        }
    }
}
