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
            KayitliOyun kayitli = new KayitliOyun();
            kayitli.Show();
            this.Hide();
        }


    }
}
