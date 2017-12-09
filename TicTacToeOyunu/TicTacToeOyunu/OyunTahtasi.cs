using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeOyunu
{
    public class OyunTahtasi
    {
        public char[,] tahta1 = new char[3, 3];
        public char oyunOp;

        public OyunTahtasi()
        {
            
        }
        public OyunTahtasi(char[][] oynTahtasi) 
        { 
        }
        /*char[][] oyunTahtasiniAl()
        {
         
            return ;
        }*/
        void oyunTahtasiniYazdir()
        { 
           
        }
        Boolean hamleyiYaz(string koordinat, char oyuncu)
        {
            //Oyuncu tarafından hamle yapılacak alanın boş olup olmadığını kontrol eden boş ise true döndürüp boş olan alana ekleme işlevini gerçekleştiren,
            //dolu ise false döndüren bir metot.
            if (koordinat == string.Empty)
            {
                return true;
            }
            else
                return false;
          
        }
        Boolean kazanan(char oyuncu)
        {
            return true;
        }
        Boolean beraberlikKontrol()
        {
            return true;
        }
        static public void main()
        {
            string[,] tahta = new string[3, 3];
            tahta[0, 0] = "X";
            tahta[0, 1] = "X";
            tahta[0, 2] = "X";
            tahta[1, 0] = "X";
            tahta[1, 1] = "X";
            tahta[1, 2] = "X";
            tahta[2, 0] = "X";
            tahta[2, 1] = "X";
            tahta[2, 2] = "X";
            OyunTahtasi oyuntahtasi = new OyunTahtasi();
        }

    }
}
