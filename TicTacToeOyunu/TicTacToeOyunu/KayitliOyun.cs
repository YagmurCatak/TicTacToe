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
    public partial class KayitliOyun : Form
    {
        public OyunTahtasi tahta;

        public KayitliOyun()
        {
            InitializeComponent();
            tahta = new OyunTahtasi();
        }
        private void KayitliOyun_Load(object sender, EventArgs e)
        {
            
        }
    }
}
