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

            StreamReader sr = new StreamReader("C:\\Users\\Yagmur\\Desktop\\DorduncuProje\\deneme.txt");

            String full = sr.ReadToEnd();

            String[] rows = full.Split('\n');
            int tahtaBoyut = rows[0].Count(f => f == '-');
            char[,] tahta = new char[tahtaBoyut, tahtaBoyut];

            List<char[]> rowList = new List<char[]>();

            foreach (String row in rows)
            {
                rowList.Add(row.Remove('-').ToCharArray());
            }



            for (int i = 0; i < tahtaBoyut; i++)
            {
                for (int j = 0; j < tahtaBoyut; i++)
                {
                    if (rowList.ElementAt(i)[j] == 'X')
                    {
                        tahta[i, j] = 'X';
                    }
                    else if (rowList.ElementAt(i)[j] == 'O')
                    {
                        tahta[i, j] = 'O';
                    }
                    else
                    {
                        tahta[i, j] = ' ';
                    }

                }
            }

            KayitliOyun kayitli = new KayitliOyun();
            kayitli.Show();
            this.Hide();

        }


    }
}
