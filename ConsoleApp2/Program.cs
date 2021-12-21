using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    struct Nokta
    {
        public int X { get; set; }
        public int Y { get; set; }
        //c#10 öncesi varsayılan ctor olamaz.
        public Nokta(int x,int y)
        {
            X = x;
            Y = y;
        }
        public void Yaz()
        {
            Console.WriteLine("P({0},{1})",X,Y);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            /*
            Struct: Value Type
            Oluşturacağın yapının boyutu 16byte'tan küçükse strcut yap,değilse class yap.16dan büyük olup struct yapsan bile hata vermez ama sistem yavaşlar.structları veriyi stact'te tutmak için kullanıyoruz.boyutu belli değilse heap'e atıyoruz.
             */
            int sayi = new int();
            Console.WriteLine(sayi);
            Nokta n1 = new Nokta();
            n1.X = 12;
            n1.Y = 22;
            n1.Yaz();
            Nokta[] noktalar = new Nokta[10];

            noktalar[1].X = 12;
            noktalar[1].Y = 22;
        }
    }
}
