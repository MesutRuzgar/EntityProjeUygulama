using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityProjeUygulama
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //entity data model kullandığımız için bu şekilde bağlandık.
        DbEntityUrunEntities db = new DbEntityUrunEntities();

        private void btnListele_Click(object sender, EventArgs e)
        {
            Listele();

        }

        private void Listele()
        {
            var kategoriler = db.Tbl_Kategori.ToList();
            dataGridView1.DataSource = kategoriler;
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            //entity kullandığımız için sql tarzında değil
            //hafızada kategori newledik ve yeni veri eklemiş olduk
            Tbl_Kategori t = new Tbl_Kategori();
            t.KategoriAd = tbxKategoriAd.Text;
            db.Tbl_Kategori.Add(t);
            //savaChanges-> yaptığımız değişiklikleri kaydet dedil
            db.SaveChanges();
            MessageBox.Show("Kategori Eklendi");
            Listele();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            var ktgr = db.Tbl_Kategori.Find(int.Parse(tbxKategoriId.Text));
            db.Tbl_Kategori.Remove(ktgr);
            db.SaveChanges();
            MessageBox.Show("Kategori Silindi");
            Listele();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tbxKategoriId.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            tbxKategoriAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            var ktgr = db.Tbl_Kategori.Find(int.Parse(tbxKategoriId.Text));
            ktgr.KategoriAd=tbxKategoriAd.Text;
            db.SaveChanges();
            MessageBox.Show("Kategori Güncellendi");
            Listele();

        }
    }
}
