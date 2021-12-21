using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    //enum:herhangi bir string ifadeyi numerik(tamsayı) değerlerle eşleştirmek için kullanılır.varsayılan tip int'tir.ama istersek değiştirebiliriz.
    //değişmeyecek değerler için kullanılır.yoksa heer seferinde kodu değiştirmek gerekir. 
    public enum Gunler { Pazartesi=5,Salı=8,Çarşamba,Perşembe,Cuma=100,Cumartesi,Pazar}
    public enum Gunler2:byte { Pazartesi = 5, Salı = 8, Çarşamba, Perşembe, Cuma = 100, Cumartesi, Pazar }
    public enum Kategori { Gıda=1,Eğitim=8,Yakıt=18,}
    class Urun
    {
        public int UrunID { get; set; }
        public string UrunAdi { get; set; }
        public Kategori Kategori { get; set; }  
    }
    class Program
    {
        static void Main(string[] args)
        {
            //Console.ForegroundColor = ConsoleColor.Red;
            //Console.WriteLine("Merhaba");
            //for (int i = 0; i < 16; i++)
            //{
            //    Console.ForegroundColor = (ConsoleColor)i;
            //    Console.WriteLine("Merhaba"+(ConsoleColor)i);
            //}
            Console.WriteLine(Gunler.Çarşamba);
            Console.WriteLine((int)Gunler.Çarşamba);//siz numara vermeseniz dahi kendisi otomatik olarak tanımlanır.
            Console.WriteLine((int)Gunler.Cumartesi);
            Console.WriteLine((Gunler)103);
            Urun urun = new Urun { UrunID = 123, UrunAdi = "Defter", Kategori = Kategori.Eğitim };

            Console.WriteLine();

            foreach (var item in Enum.GetNames(typeof(Gunler)))
            {
                Console.WriteLine(item);
            }
            //tamsayı değerleri elde etmek için getvalues+(int)item
            foreach (var item in Enum.GetValues(typeof(Gunler)))
            {
                Console.WriteLine((int)item);
            }
        }
    }
}
