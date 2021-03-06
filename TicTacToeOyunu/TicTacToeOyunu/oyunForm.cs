﻿using System;
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
                    buton.Text = this.tahta.tahta[j,i].ToString();
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

            string[] indis = clickedButton.Name.Split('-');
            koordinantx = Convert.ToInt32(indis[2].ToString());
            koordinanty = Convert.ToInt32(indis[1].ToString());

            //oyuncunun hamle yapmak istediği koordinant boş mu kontrol edip, boşsa tahtayı ve butonun textini dolduruyor. 
            oyuncuhamlekontrol = tahta.hamleyiYaz(koordinantx, koordinanty, oyuncu1.harf);
            if (oyuncuhamlekontrol != true)
            {
                MessageBox.Show( "Farkli bir hamle yapiniz") ;
                return;
            }
            clickedButton.Text = oyuncu1.harf.ToString();

           
            //oyuncu hamle yaptığında kazanıp kazanmadıgının kontrolünü yapıyor. 
            oyuncukazananKontrol = tahta.kazanan(oyuncu1.harf);
            if (oyuncukazananKontrol == true)
            {
                MessageBox.Show(oyuncu1.id + " Kazandi");
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

                } while (!bilHamlekontrol);

                butonMatris[bilgisayarY, bilgisayarX].Text = oyuncu2.harf.ToString();


                //bilgisayar hamle yaptıgında kazanıp kazanmadığını kontrol ediyor.
                bilkazananKontrol = tahta.kazanan(oyuncu2.harf);
                if (bilkazananKontrol == true)
                {
                    MessageBox.Show(oyuncu1.id + " kaybettiniz");
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



        }

        public void KaydetVeCik()
        {
            StreamWriter write = new StreamWriter("C:\\Users\\Yagmur\\Desktop\\DorduncuProje\\tahta.txt");
            for (int i = 0; i < tahta.tahtaBoyutu; i++)
            {
                for (int j = 0; j < tahta.tahtaBoyutu; j++)
                {
                    write.Write(tahta.tahta[j,i]);
                }
                write.WriteLine();
            }

            StreamWriter harfyaz = new StreamWriter("C:\\Users\\Yagmur\\Desktop\\DorduncuProje\\harf.txt");
            harfyaz.Write(oyuncu1.harf.ToString() + "-" + oyuncu2.harf.ToString());

            harfyaz.Close();
            write.Close();
            Application.Exit();
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
                }
            }
        }

    }
}
