using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Emlak_Takip
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        //Access bağalntısı
        OleDbConnection con;
        OleDbCommand cmd;
        OleDbDataReader dr;
        private int sayac = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            try 
            {
                string ad = textBox1.Text;
                string sifre = textBox2.Text;
                con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=Database1.accdb");
                cmd = new OleDbCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "SELECT * FROM kullanici where k_ad='" + textBox1.Text + "' AND k_sifre='" + textBox2.Text + "'";
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    Form1 frm = new Form1();
                    frm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Kullanıcı adı ya da şifre yanlış");
                    sayac++;
                    if (sayac == 3) 
                    {
                        MessageBox.Show("Çok sayıda deneme yaptınız, Programdan çıkılıyor.");
                        Application.Exit();
                    }
                }

                con.Close();
            }
            catch 
            {
                MessageBox.Show("Veritabanı okunamadı");
            }
        }
        private int cikis = 0;
        private void button2_Click(object sender, EventArgs e)
        {
            //Programı kapatırken Evet Hayır diye sorar
            DialogResult logout;
            logout = MessageBox.Show("Programı kapatmak istediğinize emin misiniz.", "Programı Kapat", MessageBoxButtons.YesNo);
            if (logout == DialogResult.Yes)
            {
                Application.Exit();
            }
            else cikis++;
            if (cikis == 3) Application.Exit();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            this.Text = "Turkyılmaz Emlak Takip";
        }
    }
}
