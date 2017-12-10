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
    public partial class oyunForm : Form
    {
        public OyunTahtasi tahta;
        public Oyuncu oyuncu1;
        public Oyuncu oyuncu2;

        public oyunForm()
        {
            InitializeComponent();
        }

        public oyunForm(string id,string boyut, string harf)
        {
            InitializeComponent();
            label1.Text = id.ToString();
            label2.Text = boyut.ToString();
            label3.Text = harf;
        }

        public oyunForm(Oyuncu oyuncu, OyunTahtasi tahta)
        {
           
            oyuncu1 = oyuncu;
            this.tahta = tahta;

            InitializeComponent();

            for (int i = 0; i < tahta.tahtaBoyutu; i++)
            {
                for (int j = 0; j < tahta.tahtaBoyutu; j++)
                {
                    Button buton = new Button();
                    buton.Height = 50;
                    buton.Width = 50;
                    buton.Location = new System.Drawing.Point(50 + i * buton.Height + 5, 50 + j* buton.Width + 5);
                    buton.Name = "btn-" + i + "-" +j.ToString();

                    buton.Click += new System.EventHandler(this.boyutButtonClick);
                    
               
                    this.Controls.Add(buton);
                } 
            }

        }

        private void oyunForm_load(object sender, EventArgs e)
        {
            
        }

        private void boyutButtonClick(object sender, EventArgs e)
        {

            Boolean kontrol;
            Button clickedButton = (Button)sender;

            //ilk parametre i, ikinci parametre j ; i:satir,j:sutun j=x,i=y
            string[] indis = clickedButton.Name.Split('-');
            int koordinantx = Convert.ToInt32(indis[2].ToString());
            int koordinanty = Convert.ToInt32(indis[1].ToString());

            
            kontrol = tahta.hamleyiYaz(koordinantx, koordinanty, oyuncu1.harf);
            if (kontrol == true)
                clickedButton.Text = oyuncu1.harf.ToString();
           
        }
        
    }
}
