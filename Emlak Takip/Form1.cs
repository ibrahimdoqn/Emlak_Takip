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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            doldurTablo();//Form açıldığında Tabloları doldurur
            timer1.Start();//Timer başlatır
        }
        //Access Bağalantısı için
        OleDbConnection con;
        OleDbDataAdapter da;
        OleDbCommand cmd;
        DataSet ds;

        private void doldurTablo() //Datagrid'leri doldurmak için Fonksiyon
        {
            try
            {
                doldurTablo1();
                doldurTablo2();
                doldurTablo3();
                doldurTablo4();
            }
            catch
            {
                MessageBox.Show("Veri Tabanı Okunamadı");
            }
        }
        private void doldurTablo1() //İlk Tabloyu doldurur
        {
                con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=Database1.accdb");
                da = new OleDbDataAdapter("SElect *from Emlak", con);
                ds = new DataSet();
                con.Open();
                da.Fill(ds, "Emlak");
                dataGridView1.DataSource = ds.Tables["Emlak"];
                con.Close();
        }
        private void doldurTablo2()//2. Tabloyu doldurur
        {
            con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=Database1.accdb");
            da = new OleDbDataAdapter("SElect *from Buyed", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "Buyed");
            dataGridView2.DataSource = ds.Tables["Buyed"];
            con.Close();
        }
        private void doldurTablo3() //3. Tabloyu doldurur
        {
            con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=Database1.accdb");
            da = new OleDbDataAdapter("SElect *from Kiralanan", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "Kiralanan");
            dataGridView3.DataSource = ds.Tables["Kiralanan"];
            con.Close();
        }

        private void doldurTablo4()//4. Tabloyu doldurur
        {
            con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=Database1.accdb");
            da = new OleDbDataAdapter("SElect *from Silinen", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "Silinen");
            dataGridView4.DataSource = ds.Tables["Silinen"];
            con.Close();
        }
        private void sil()
        {
            //Kutucukları temizlemek için kullanılan fonksiyon
            mah.Text = "";
            cad.Text = "";
            apt.Text = "";
            kat.Text = "";
            no.Text = "";
            ksBox1.Text = "";
        }
        private void kayitButonu() //1. Tabloya kayıt ekler
        {
            try
            {
                cmd = new OleDbCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "insert into Emlak (Mahalle,Cadde,Apartman,Kat,Numara,KiralikSatilik,TarihSaat) values ('" + mah.Text + "','" + cad.Text + "','" + apt.Text + "','" + kat.Text + "','" + no.Text + "','" + ksBox1.Text + "','" + DateTime.Now.ToString() + "')";
                cmd.ExecuteNonQuery();
                con.Close();
                doldurTablo();
            }

            catch
            {
                MessageBox.Show("Lütfen tüm girişleri doğru yaptığınızdan emin olun.");
            }
        }
        private void kayitButonu2()//2. Tabloya kayıt ekler
        {
            try
            {
                cmd = new OleDbCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "insert into Buyed (Mahalle,Cadde,Apartman,Kat,Numara,KiralikSatilik,TarihSaat) values ('" + mah.Text + "','" + cad.Text + "','" + apt.Text + "','" + kat.Text + "','" + no.Text + "','" + ksBox1.Text + "','" + DateTime.Now.ToString() + "')";
                cmd.ExecuteNonQuery();
                con.Close();
                doldurTablo();
            }

            catch
            {
                MessageBox.Show("Lütfen tüm girişleri doğru yaptığınızdan emin olun.");
            }
        }
        private void kayitButonu3()//3. Tabloya kayıt ekler
        {
            try
            {
                cmd = new OleDbCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "insert into Kiralanan (Mahalle,Cadde,Apartman,Kat,Numara,KiralikSatilik,TarihSaat) values ('" + mah.Text + "','" + cad.Text + "','" + apt.Text + "','" + kat.Text + "','" + no.Text + "','" + ksBox1.Text + "','" + DateTime.Now.ToString() + "')";
                cmd.ExecuteNonQuery();
                con.Close();
                doldurTablo();
            }

            catch
            {
                MessageBox.Show("Lütfen tüm girişleri doğru yaptığınızdan emin olun.");
            }
        }
        private void kayitButonu4()//4. Tabloya kayıt ekler
        {
            try
            {
                cmd = new OleDbCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "insert into Silinen (Mahalle,Cadde,Apartman,Kat,Numara,KiralikSatilik,TarihSaat) values ('" + mah.Text + "','" + cad.Text + "','" + apt.Text + "','" + kat.Text + "','" + no.Text + "','" + ksBox1.Text + "','" + DateTime.Now.ToString() + "')";
                cmd.ExecuteNonQuery();
                con.Close();
                doldurTablo();
            }

            catch
            {
                MessageBox.Show("Lütfen tüm girişleri doğru yaptığınızdan emin olun.");
            }
        }

        private void silmeButonu() //1. Tablodan kayıt siler
        {
            try 
            {
                cmd = new OleDbCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "delete from Emlak where Mahalle='" + mah.Text + "'";
                cmd.ExecuteNonQuery();
                con.Close();
                doldurTablo();
            }

            catch 
            {
                MessageBox.Show("Lütfen tüm girişleri doğru yaptığınızdan emin olun.");
            }
        }
        private void silmeButonu2()//2. Tablodan kayıt siler
        {
            try
            {
                cmd = new OleDbCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "delete from Buyed where Mahalle='" + mah.Text + "'";
                cmd.ExecuteNonQuery();
                con.Close();
                doldurTablo();
            }

            catch
            {
                MessageBox.Show("Lütfen tüm girişleri doğru yaptığınızdan emin olun.");
            }
        }
        private void silmeButonu3()//3. Tablodan kayıt siler
        {
            try
            {
                cmd = new OleDbCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "delete from Kiralanan where Mahalle='" + mah.Text + "'";
                cmd.ExecuteNonQuery();
                con.Close();
                doldurTablo();
            }

            catch
            {
                MessageBox.Show("Lütfen tüm girişleri doğru yaptığınızdan emin olun.");
            }
        }
        private void silmeButonu4()//4. tablodan kayıt siler
        {
            try
            {
                cmd = new OleDbCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "delete from Silinen where Mahalle='" + mah.Text + "'";
                cmd.ExecuteNonQuery();
                con.Close();
                doldurTablo();
            }

            catch
            {
                MessageBox.Show("Lütfen tüm girişleri doğru yaptığınızdan emin olun.");
            }
        }
        private void guncellemeButonu()//1. Tablodaki seçilen veriyi günceller
        {
            try
            {
                cmd = new OleDbCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = ("UPDATE Emlak SET Cadde='" + cad.Text + "',Apartman='" + apt.Text + "',Kat='" + kat.Text + "',Numara='" + no.Text + "',KiralikSatilik='" + ksBox1.Text + "'Where Mahalle='" + mah.Text + "'");
                cmd.ExecuteNonQuery();
                con.Close();
                doldurTablo();
            }
            catch
            {
                MessageBox.Show("Lütfen tüm girişleri doğru yaptığınızdan emin olun.");
            }
        }
        private void gelismisArama()//Textboxa girilen kelimeyi veritabanında arar
        {
            //Arama kutusunda değişiklik yapıldığında çalışır
            //RadioButton Seçimine göre sonuç üretir
            con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=Database1.accdb");
            if (radioButton1.Checked)
            {
                da = new OleDbDataAdapter("SElect *from Emlak where Mahalle like '" + textBox1.Text + "%'", con);
            }
            else if (radioButton2.Checked)
            {
                da = new OleDbDataAdapter("SElect *from Emlak where Cadde like '" + textBox1.Text + "%'", con);
            }
            else if (radioButton3.Checked)
            {
                da = new OleDbDataAdapter("SElect *from Emlak where KiralikSatilik like '" + "Ki" + "%'", con);
            }
            else if (radioButton8.Checked)
            {
                da = new OleDbDataAdapter("SElect *from Emlak where KiralikSatilik like '" + "Sa" + "%'", con);
            }
            else if (radioButton4.Checked)
            {
                da = new OleDbDataAdapter("SElect *from Emlak where Apartman like '" + textBox1.Text + "%'", con);
            }
            else
            {
                MessageBox.Show("Lütfen Aramak istediğiniz kriteri seçiniz.");
            }
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "Emlak");
            dataGridView1.DataSource = ds.Tables["Emlak"];
            con.Close();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            gelismisArama();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            kayitButonu();//1. Forma kayıt eklemek için fonksiyon
            sil();
        }


        private void button3_Click(object sender, EventArgs e)
        {
            guncellemeButonu();//1. Formdaki verileri güncellemek için fonksiyon
            sil();
        }
        private void islemYap()
        {
            //İşlem yap menüsündeki Seçilen RadioButton ile ilgili işlemi gerçekleştirir
            if (radioButton5.Checked == true)//Kiralama işlemi
            {
                kayitButonu3();
                silmeButonu();
                sil();
            }
            else if (radioButton6.Checked == true)//Satış işlemi
            {
                kayitButonu2();
                silmeButonu();
                sil();
            }
            else if (radioButton7.Checked == true)//Silme işlemi
            {
                kayitButonu4();
                silmeButonu();
                sil();
            }
            else MessageBox.Show("Lütfen yapmak istediğiniz işlemi seçiniz");
        }
        private void button4_Click(object sender, EventArgs e)
        {
            islemYap();//Satış Kiralama Silme fonksiyonları gerçekleştirir
            sil();
        }
        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            //İlk tablodaki seçimi kutucuklara aktarır
            mah.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            cad.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            apt.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            kat.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            no.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            ksBox1.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
        }
		
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //2. Tablodaki veriyi kutucuklara aktarır
            mah.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            cad.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            apt.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
            kat.Text = dataGridView2.CurrentRow.Cells[3].Value.ToString();
            no.Text = dataGridView2.CurrentRow.Cells[4].Value.ToString();
            ksBox1.Text = dataGridView2.CurrentRow.Cells[5].Value.ToString();
        }
		
        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //3. Tablodaki veriyi kutucuklara aktarır
            mah.Text = dataGridView3.CurrentRow.Cells[0].Value.ToString();
            cad.Text = dataGridView3.CurrentRow.Cells[1].Value.ToString();
            apt.Text = dataGridView3.CurrentRow.Cells[2].Value.ToString();
            kat.Text = dataGridView3.CurrentRow.Cells[3].Value.ToString();
            no.Text = dataGridView3.CurrentRow.Cells[4].Value.ToString();
            ksBox1.Text = dataGridView3.CurrentRow.Cells[5].Value.ToString();
        }
		
        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //4. Tablodaki seçimi kutucuklara aktarır
            mah.Text = dataGridView4.CurrentRow.Cells[0].Value.ToString();
            cad.Text = dataGridView4.CurrentRow.Cells[1].Value.ToString();
            apt.Text = dataGridView4.CurrentRow.Cells[2].Value.ToString();
            kat.Text = dataGridView4.CurrentRow.Cells[3].Value.ToString();
            no.Text = dataGridView4.CurrentRow.Cells[4].Value.ToString();
            ksBox1.Text = dataGridView4.CurrentRow.Cells[5].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //4. Kutucuktaki veriyi siler
            silmeButonu4();
            sil();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //4. Tablodaki veriyi 1. Tabloya geriye döndürür
            kayitButonu();
            silmeButonu4();
            sil();
        }
        private void button7_Click(object sender, EventArgs e)
        {
            //2. Tablodaki veriyi 1. Tabloya aktarır
            kayitButonu();
            silmeButonu2();
            sil();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //2. Tablodaki veriyi 2. tabloya aktarır
            kayitButonu3();
            silmeButonu2();
            sil();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            //2. Tablodaki seçili veriyi siler
            silmeButonu2();
            sil();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            //3. Tablodaki veriyi 1. Tabloya aktarır
            kayitButonu();
            silmeButonu3();
            sil();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            //3. Tablodaki veriyi 2. tabloya aktarır
            kayitButonu2();
            silmeButonu3();
            sil();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            //3. Tablodaki veriyi siler
            silmeButonu3();
            sil();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            //Anamenüdeki kutucukları temizler
            sil();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //Kayan yazı
            label1.Text = label1.Text.Substring(1) + label1.Text.Substring(0, 1);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            //1. Tabloyu yazdırır
            Form2 frm = new Form2();
            frm.cr = 1;
            frm.ShowDialog();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            //2. Tabloyu yazdırır
            Form2 frm = new Form2();
            frm.cr = 2;
            frm.ShowDialog();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            //3. Tabloyu yazdırır
            Form2 frm = new Form2();
            frm.cr = 3;
            frm.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //4. Tabloyu yazdırır
            Form2 frm = new Form2();
            frm.cr = 4;
            frm.ShowDialog();
        }
        private int cikis = 0;//cikis yap fonksiyonu için
        private void cikisYap() 
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
        private void button17_Click(object sender, EventArgs e)
        {
            cikisYap();//Çıkış yap butonu
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //Klavye kısayolları
            if (e.Control && e.KeyCode == Keys.P)
            {
                //CTRL + P Yazdırma fonksiyonu
                Form2 frm = new Form2();
                frm.cr = 1;
                frm.ShowDialog();
            }
            else if (e.KeyCode == Keys.F2) kayitButonu();//Kayıt ekleme
            else if (e.KeyCode == Keys.F3) guncellemeButonu();//Güncelleme Fonksiyonu
            else if (e.KeyCode == Keys.Escape) cikisYap();//ESC İle programdan çıkış için
            else if (e.KeyCode == Keys.F4) islemYap();// İşlem yap

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            gelismisArama();
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            gelismisArama();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            gelismisArama();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            gelismisArama();
        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {
            gelismisArama();
        }
    }
}
