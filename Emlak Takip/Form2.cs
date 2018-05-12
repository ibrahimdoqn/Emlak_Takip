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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        OleDbConnection con;
        OleDbDataAdapter da;
        DataTable tablo = new DataTable();
        public int cr = 0;//Rapor seçimi için değer mainForm1'den alınır.
        private void raporOlustur()
        {
            if (cr == 1)//İlk sayfanın raporu için
            {
                con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=Database1.accdb");
                da = new OleDbDataAdapter("SElect *from Emlak", con);
                tablo.Clear();
                da.Fill(tablo);
                CrystalReport1 rapor = new CrystalReport1();
                rapor.SetDataSource(tablo);
                crystalReportViewer1.ReportSource = rapor;
            }
            else if (cr == 2)// İkinci sayfanın raporunu oluşturur
            {
                con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=Database1.accdb");
                da = new OleDbDataAdapter("SElect *from Buyed", con);
                tablo.Clear();
                da.Fill(tablo);
                CrystalReport1 rapor = new CrystalReport1();
                rapor.SetDataSource(tablo);
                crystalReportViewer1.ReportSource = rapor;
            }
            else if (cr == 3)// İkinci sayfanın raporunu oluşturur
            {
                con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=Database1.accdb");
                da = new OleDbDataAdapter("SElect *from Kiralanan", con);
                tablo.Clear();
                da.Fill(tablo);
                CrystalReport1 rapor = new CrystalReport1();
                rapor.SetDataSource(tablo);
                crystalReportViewer1.ReportSource = rapor;
            }
            else if (cr == 4)
            {
                con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=Database1.accdb");
                da = new OleDbDataAdapter("SElect *from Silinen", con);
                tablo.Clear();
                da.Fill(tablo);
                CrystalReport1 rapor = new CrystalReport1();
                rapor.SetDataSource(tablo);
                crystalReportViewer1.ReportSource = rapor;
            }
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            raporOlustur();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
