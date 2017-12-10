using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeOyunu
{
    public class Oyuncu
    {
        public char harf { get; set; }
        public string id { get; set; }
        public Boolean oyuncutip { get; set; } //bilgisayarsa false, insansa true 

        //insan olan oyuncuya X harfini ve insan olma özelliğine true değerini atar.
        public Oyuncu()
        {
            this.oyuncutip = true;
            this.harf = 'X'; 
        }

        public Oyuncu(Boolean insanmiKontrolu)
        { 
            this.oyuncutip = insanmiKontrolu;
            if (oyuncutip == true)
                this.harf = 'X';
            else
                this.harf = 'O';
        }

        public Oyuncu(Boolean insanmiKontrolu, char kr)
        {
            if (kr == 'X')
            {
                this.harf = 'X';
                this.oyuncutip = true;
            }
            else
            {
                this.harf = 'O';
                this.oyuncutip = false;
            }
        }

        public char karakteriAl()
        {
            return harf;
        }

        public Boolean oyuncuTurunuAl()
        {
            return oyuncutip;
        }

        public string oyuncununHamlesiniAl()
        {
            string hamle = "X";
            return hamle;
        }

        //insan olan oyuncuyu hamle yapması için uyaran ve klavyeden kullanıcı tarafından girilen hamleyi alıp, döndüren bir metot
        public string insanOyuncuHamlesiniKotrol()
        {
            Console.WriteLine("hamlenizi yapınız");
            string hamle = "";
            //harf = textbox.Text; // kullanici adini textbox'a giriyor.
            return hamle;
        }
        
        //random olarak bilgisayar için oyun tahtası üzerinde bir hamle koordinatı döndüren bir metot.
        public string bilgisayarHamlesiUret()
        {
            Random rastgele = new Random();
            int sayi = rastgele.Next(0,7);
            string konum = sayi.ToString();
            return konum;
        }
       
    }
}
