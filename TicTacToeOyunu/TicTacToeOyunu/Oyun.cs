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
        public static Boolean harf;

        private void Oyun_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            

            boyut = txtboyut.Text.ToString();
            id = txtid.Text.ToString();

            if (radioButton1.Checked == true)
                harf = radioButton1.Checked;//true dönerse, x seçilmiş demektir.
            else
                harf = radioButton2.Checked;

            oyunForm oyunForm = new oyunForm();
            oyunForm.ShowDialog();
        }

    }
}
