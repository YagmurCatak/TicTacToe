using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeOyunu
{
    public class OyunTahtasi
    {
        public char[,] tahta { get; set; }
        public int tahtaBoyutu { get; set; }

        public OyunTahtasi()
        { 
        }

        public OyunTahtasi(int tahtaBoyutu)
        {
            this.tahtaBoyutu = tahtaBoyutu;
            if (tahtaBoyutu > 7)
                throw new Exception("tahta boyutu 7'den buyuk olamaz");  
            tahta = new char[this.tahtaBoyutu, this.tahtaBoyutu];

        }

        public OyunTahtasi(char[,] oynTahtasi,int tahtaBoyutu) 
        {
            this.tahtaBoyutu = tahtaBoyutu;
            tahta = new char[this.tahtaBoyutu, this.tahtaBoyutu];
            tahta = oynTahtasi;
        }

        public char[,] oyunTahtasiniAl()
        {
            return tahta;
        }

        public void oyunTahtasiniYazdir()
        { 
           
        }

        //Oyuncu tarafından hamle yapılacak alanın boş olup olmadığını kontrol eden boş ise true döndürüp boş olan alana ekleme işlevini gerçekleştiren,
        //dolu ise false döndüren bir metot.
        public Boolean hamleyiYaz(int koordinatX, int koordinatY, char oyuncuHamlesi)
        {
            if (tahta[koordinatX,koordinatY].Equals('\0'))
            {
                tahta[koordinatX, koordinatY] = oyuncuHamlesi;
                return true;
            }
            else
                return false;
        }

        //parametre olarak oyuncunun kullandığı harfi, tahtaboyutunu ve kullanıcı idsini alır.
        //oyuncu oyunu kazandıysa true aksi durumda false değerini döndürecektir.
        public Boolean kazanan(char oyuncuHarf)
        {
            int kontrol = 0;
            for (int i = 0; i < tahtaBoyutu; i++)
            {
                for (int j = 0; j < tahtaBoyutu; j++)
                {
                    if (tahta[i, j] == oyuncuHarf)
                    {
                        if (j+2 < tahtaBoyutu)
                        {
                            if (tahta[i, j + 1] == oyuncuHarf && tahta[i, j + 2] == oyuncuHarf)
                            {
                                //sagininda 2x var mı kontrolü 
                                kontrol = 1;
                                break;
                            }
                        }
                        if (i + 2 < tahtaBoyutu)
                        {
                            if (tahta[i + 1, j] == oyuncuHarf && tahta[i + 2, j] == oyuncuHarf)
                            {
                                //altında 2x var mı kontrolü 
                                kontrol = 1;
                                break;
                            }
                        }
                        if(i+2 <tahtaBoyutu && j+2<tahtaBoyutu)
                        {
                            if (tahta[i + 1, j + 1] == oyuncuHarf && tahta[i + 2, j + 2] == oyuncuHarf)
                            {
                                //kosegen kontrolü 
                                kontrol = 1;
                                break;
                            }
                        }
                    }
                }
            }
            if (kontrol == 1)
                return true;
            else
                return false;

        }

        Boolean beraberlikKontrol()
        {
            return true;
        }
    }
}
