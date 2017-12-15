using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace TicTacToeOyunu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void kapatToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }

        private void yeniOyunToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Oyun yeni = new Oyun();
            yeni.Show();
            this.Hide();
        }

        private void oyunAçToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Oyuncu oyuncu1 = new Oyuncu();
            Oyuncu oyuncu2 = new Oyuncu();

            StreamReader srtahta = new StreamReader("C:\\Users\\Yagmur\\Desktop\\DorduncuProje\\tahta.txt");
            StreamReader srharf = new StreamReader("C:\\Users\\Yagmur\\Desktop\\DorduncuProje\\harf.txt");

            String full = srtahta.ReadToEnd();
            String[] rows = full.Split('\n');
            int tahtaBoyut = rows.Length-1; 

            String fullharf = srharf.ReadToEnd();
            String[] harf = fullharf.Split('-');

            List<char[]> harfList = new List<char[]>();
            foreach (String harfs in harf)
            {
                harfList.Add(harfs.ToCharArray());
            }

            if (harfList.ElementAt(0)[0] == 'X')
            {
                oyuncu1.harf = 'X';
                oyuncu2.harf = 'O';
            }
            else
            {
                oyuncu1.harf = 'O';
                oyuncu2.harf = 'X';
            }

            OyunTahtasi tahta = new OyunTahtasi(tahtaBoyut);

            List<char[]> rowList = new List<char[]>();

            foreach (String row in rows)
            {
                rowList.Add(row.ToCharArray());
            }

            for (int i = 0; i < tahtaBoyut; i++)
            {
                for (int j = 0; j < tahtaBoyut; j++)
                {
                   
                    if (rowList.ElementAt(j)[i] == 'X')
                    {
                        tahta.tahta[j, i] = 'X';
                    }
                    else if (rowList.ElementAt(j)[i] == 'O')
                    {
                        tahta.tahta[j, i] = 'O';
                    }
                    else
                    {
                        tahta.tahta[j, i] = '\0';
                    }

                }

            }

            for(int i=0; i<tahtaBoyut; i++)
            {
                for(int j=0; j<tahtaBoyut; j++)
                {
                    Console.Write(tahta.tahta[i,j].ToString() + ' ');
                }
                Console.WriteLine();
            }

            oyunForm kayitlioyun = new oyunForm(oyuncu1,oyuncu2,tahta);
            kayitlioyun.Show();
            this.Hide();

        }

        

    }
}
