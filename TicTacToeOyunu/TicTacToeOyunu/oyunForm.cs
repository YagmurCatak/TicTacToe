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

        public oyunForm(Oyuncu oyuncu, Oyuncu oyuncutwo,OyunTahtasi tahta)
        {
           
            oyuncu1 = oyuncu;
            oyuncu2 = oyuncutwo;
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
            Boolean kazananKontrol;
            Boolean bilkontrol;
            Boolean beraber;
            Boolean bilberaber;
            Button clickedButton = (Button)sender;
            int kazandi = 0;
            int bilkazandi = 0;

            do
            {
                //ilk parametre i, ikinci parametre j ; i:satir,j:sutun j=x,i=y
                string[] indis = clickedButton.Name.Split('-');
                int koordinantx = Convert.ToInt32(indis[2].ToString());
                int koordinanty = Convert.ToInt32(indis[1].ToString());

                //oyuncunun hamle yapmak istediği koordinant boş mu kontrol edip, boşsa tahtayı ve butonun textini dolduruyor. 
                kontrol = tahta.hamleyiYaz(koordinantx, koordinanty, oyuncu1.harf);
                if (kontrol == true)
                    clickedButton.Text = oyuncu1.harf.ToString();

                //oyuncu hamle yaptığında kazanıp kazanmadıgının kontrolünü yapıyor. 
                kazananKontrol = tahta.kazanan(oyuncu1.harf);
                if (kazananKontrol == true)
                {
                    MessageBox.Show(oyuncu1.id + "Kazandi");
                    kazandi = 1;
                }
                else
                {
                    //oyunun berabere olup olmadıgını kontrol eder. 
                    beraber = tahta.beraberlikKontrol();
                    if (beraber == true)
                        MessageBox.Show("beraber");
                    else
                        break;
                }
            } while (kazandi != 1);

            do
            {
                //Bilgisayara rastgele koordinant üretimi sağlanıyor 
                String[] bilgisayarHamle = oyuncu2.bilgisayarHamlesiUret(tahta.tahtaBoyutu);
                int bilgisayarX = Convert.ToInt32(bilgisayarHamle[0].ToString());
                int bilgisayarY = Convert.ToInt32(bilgisayarHamle[1].ToString());

                //rastgele oluşan koordinantın boş olup olmadığı kontrolü yapılıyor.
                bilkontrol = tahta.hamleyiYaz(bilgisayarX, bilgisayarY, oyuncu2.harf);
                if (bilkontrol == true)
                    clickedButton.Text = oyuncu2.harf.ToString();

                //bilgisayar hamle yaptıgında kazanıp kazanmadığını kontrol ediyor.
                kazananKontrol = tahta.kazanan(oyuncu2.harf);
                if (kazananKontrol == true)
                {
                    MessageBox.Show(oyuncu1.id + "kaybettiniz");
                    bilkazandi = 1;
                }
                else
                {
                    //oyunun berabere olup olmadıgını kontrol eder. 
                    bilberaber = tahta.beraberlikKontrol();
                    if (bilberaber == true)
                        MessageBox.Show("beraber");
                    else
                        break;
                }
            } while (bilkazandi != 1 );
      
        }
    }
}
