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
    public partial class oyunForm : Form
    {
        public OyunTahtasi tahta;
        public Oyuncu oyuncu1;
        public Oyuncu oyuncu2;
        public Button[,] butonMatris ; 

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
            InitializeComponent();

            oyuncu1 = oyuncu;
            oyuncu2 = oyuncutwo;
            this.tahta = tahta;

            
            butonMatris = new Button[tahta.tahtaBoyutu, tahta.tahtaBoyutu];
            
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
                    butonMatris[i, j] = buton;
                    
                } 
            }

        }

        private void boyutButtonClick(object sender, EventArgs e)
        {
            Boolean oyuncuhamlekontrol;
            Boolean oyuncukazananKontrol;
            Boolean bilkazananKontrol;
            Boolean bilHamlekontrol;
            Boolean oyuncuberaberkontrol;
            Boolean bilberaberKontrol;
            int bilgisayarX;
            int bilgisayarY;
            int koordinantx;
            int koordinanty;
            Button clickedButton = (Button)sender;
            int kazandi = 0;

           
            do{
                //ilk parametre i, ikinci parametre j ; i:satir,j:sutun j=x,i=y
                string[] indis = clickedButton.Name.Split('-');
                koordinantx = Convert.ToInt32(indis[2].ToString());
                koordinanty = Convert.ToInt32(indis[1].ToString());

                //oyuncunun hamle yapmak istediği koordinant boş mu kontrol edip, boşsa tahtayı ve butonun textini dolduruyor. 
                oyuncuhamlekontrol = tahta.hamleyiYaz(koordinantx, koordinanty, oyuncu1.harf);
               
            } while (oyuncuhamlekontrol);
            clickedButton.Text = oyuncu1.harf.ToString();

           
            //oyuncu hamle yaptığında kazanıp kazanmadıgının kontrolünü yapıyor. 
            oyuncukazananKontrol = tahta.kazanan(oyuncu1.harf);
            if (oyuncukazananKontrol == true)
            {
                MessageBox.Show(oyuncu1.id + "Kazandi");
                kazandi = 1;
            }
            else
            {
                //oyunun berabere olup olmadıgını kontrol eder. 
                oyuncuberaberkontrol = tahta.beraberlikKontrol();
                if (oyuncuberaberkontrol == true)
                {
                    MessageBox.Show("beraber");
                    kazandi = -1;
                }
            }

            if (kazandi == 0)
            {
                do
                {
                    //Bilgisayara rastgele koordinant üretimi sağlanıyor. 
                    String[] bilgisayarHamle = oyuncu2.bilgisayarHamlesiUret(tahta.tahtaBoyutu);
                    bilgisayarX = Convert.ToInt32(bilgisayarHamle[0].ToString());
                    bilgisayarY = Convert.ToInt32(bilgisayarHamle[1].ToString());


                    //rastgele oluşan koordinantın boş olup olmadığı kontrolü yapılıyor.
                    bilHamlekontrol = tahta.hamleyiYaz(bilgisayarX, bilgisayarY, oyuncu2.harf);

                } while (bilHamlekontrol);

                butonMatris[bilgisayarX, bilgisayarY].Text = oyuncu2.harf.ToString();

                
               

                //bilgisayar hamle yaptıgında kazanıp kazanmadığını kontrol ediyor.
                bilkazananKontrol = tahta.kazanan(oyuncu2.harf);
                if (bilkazananKontrol == true)
                {
                    MessageBox.Show(oyuncu1.id + "kaybettiniz");
                    kazandi = -2;
                }
                else
                {
                    //oyunun berabere olup olmadıgını kontrol eder. 
                    bilberaberKontrol = tahta.beraberlikKontrol();
                    if (bilberaberKontrol == true)
                    {
                        MessageBox.Show("beraber");
                        kazandi = -1;
                    }
                }
            }




/*
            do
            {
                //ilk parametre i, ikinci parametre j ; i:satir,j:sutun j=x,i=y
                string[] indis = clickedButton.Name.Split('-');
                int koordinantx = Convert.ToInt32(indis[2].ToString());
                int koordinanty = Convert.ToInt32(indis[1].ToString());

                //oyuncunun hamle yapmak istediği koordinant boş mu kontrol edip, boşsa tahtayı ve butonun textini dolduruyor. 
                oyuncuhamlekontrol = tahta.hamleyiYaz(koordinantx, koordinanty, oyuncu1.harf);
                if (oyuncuhamlekontrol == true)
                    clickedButton.Text = oyuncu1.harf.ToString();

                //oyuncu hamle yaptığında kazanıp kazanmadıgının kontrolünü yapıyor. 
                oyuncukazananKontrol = tahta.kazanan(oyuncu1.harf);
                if (oyuncukazananKontrol == true)
                {
                    MessageBox.Show(oyuncu1.id + "Kazandi");
                    kazandi = 1;
                    break;
                }
                else
                {
                    //oyunun berabere olup olmadıgını kontrol eder. 
                    oyuncuberaberkontrol = tahta.beraberlikKontrol();
                    if (oyuncuberaberkontrol == true)
                    {
                        MessageBox.Show("beraber");
                        break;
                    }
                    else
                    {
                        //Bilgisayara rastgele koordinant üretimi sağlanıyor. 
                        String[] bilgisayarHamle = oyuncu2.bilgisayarHamlesiUret(tahta.tahtaBoyutu);
                        bilgisayarX = Convert.ToInt32(bilgisayarHamle[0].ToString());
                        bilgisayarY = Convert.ToInt32(bilgisayarHamle[1].ToString());

                        
                        //rastgele oluşan koordinantın boş olup olmadığı kontrolü yapılıyor.
                        bilHamlekontrol = tahta.hamleyiYaz(bilgisayarX, bilgisayarY, oyuncu2.harf);
                        if (bilHamlekontrol == true)
                            butonMatris[bilgisayarX, bilgisayarY].Text = oyuncu2.harf.ToString();
                        else
                            bilHamlekontrol = tahta.hamleyiYaz(bilgisayarX, bilgisayarY, oyuncu2.harf);

                        //bilgisayar hamle yaptıgında kazanıp kazanmadığını kontrol ediyor.
                        bilkazananKontrol = tahta.kazanan(oyuncu2.harf);
                        if (bilkazananKontrol == true)
                        {
                            MessageBox.Show(oyuncu1.id + "kaybettiniz");
                            break;
                        }
                        else
                        {
                            //oyunun berabere olup olmadıgını kontrol eder. 
                            bilberaberKontrol = tahta.beraberlikKontrol();
                            if (bilberaberKontrol == true)
                            {
                                MessageBox.Show("beraber");
                                break;
                            }
                        }
                    }
                       
                }

            } while (kazandi != 1);
            */
                
        }

        private void KaydetVeCik()
        {
            StreamWriter write = new StreamWriter("C:\\Users\\Yagmur\\Desktop\\DorduncuProje\\deneme.txt");
            for (int i = 0; i < tahta.tahtaBoyutu; i++)
            {
                for (int j = 0; j < tahta.tahtaBoyutu; j++)
                {
                    write.Write(tahta.tahta[i,j]+ "-");
                }
                write.WriteLine();
            }
            write.Close();
            this.Close();
        }

        private void oyunForm_Load(object sender, EventArgs e)
        { 
        }

        private void oyunForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult sonuc = MessageBox.Show("Cikmak istiyor musunuz ? ","Çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (sonuc == DialogResult.No)
                {
                    e.Cancel = true;
                    return;

                }
                else
                {
                    KaydetVeCik();
                    //Application.Exit();
                }
            }
        }

    }
}
