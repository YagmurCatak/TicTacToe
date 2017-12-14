using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToeOyunu
{
    public partial class Oyun : Form
    {
        
        public Oyun()
        {
            InitializeComponent();
        }

        public static string id;
        public static string boyut;
        public static string harf;

        private void Oyun_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Oyuncu oyuncu1 = new Oyuncu();//oyuncu kullanici 'x'
            Oyuncu oyuncu2 = new Oyuncu();//oyuncu bilgisayar 'O' 

            OyunTahtasi tahta = new OyunTahtasi(Convert.ToInt32(txtboyut.Text.ToString()));

            oyuncu1.id = txtid.Text.ToString();

            if (radioButtonX.Checked == true)
            {
                oyuncu1.harf = 'X';
                oyuncu2.harf = 'O';
            }

            else
            {
                oyuncu1.harf = 'O';
                oyuncu2.harf = 'X';
            }
                
            oyunForm oyunForm = new oyunForm(oyuncu1,oyuncu2,tahta);
            oyunForm.ShowDialog();
        }

    }
}
