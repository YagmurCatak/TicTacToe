using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeOyunu
{
    class Oyuncu
    {
        char harf;
        string id;
        Boolean oyuncutip; //bilgisayarsa false, insansa true 

        public Oyuncu()
        {
            //insan olan oyuncuya X harfini ve insan olma özelliğine true değerini atar.
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

        char karakteriAl()
        {
            return harf;
        }

        Boolean oyuncuTurunuAl()
        {
            return oyuncutip;
        }

        string oyuncununHamlesiniAl()
        {
            string hamle = "X";
            return hamle;
        }

        //insan olan oyuncuyu hamle yapması için uyaran ve klavyeden kullanıcı tarafından girilen hamleyi alıp, döndüren bir metot
        string insanOyuncuHamlesiniKotrol()
        {
            Console.WriteLine("hamlenizi yapınız");
            string hamle = "";
            //harf = textbox.Text; // kullanici adini textbox'a giriyor.
            return hamle;
        }
        
        //random olarak bilgisayar için oyun tahtası üzerinde bir hamle koordinatı döndüren bir metot.
        string bilgisayarHamlesiUret()
        {
            Random rastgele = new Random();
            int sayi = rastgele.Next(0,7);
            string konum = sayi.ToString();
            return konum;
        }

        public void main()
        {
           
        }
       
    }
}
