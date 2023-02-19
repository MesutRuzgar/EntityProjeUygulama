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
    public partial class frmUrun : Form
    {
        public frmUrun()
        {
            InitializeComponent();
        }
        DbEntityUrunEntities db = new DbEntityUrunEntities();
        private void btnListele_Click(object sender, EventArgs e)
        {
            Listele();
        }

        private void Listele()
        {
            dataGridView1.DataSource = db.Tbl_Urun.ToList();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            Tbl_Urun t = new Tbl_Urun();
            t.UrunAdi = tbxUrunAd.Text;
            t.Marka=tbxMarka.Text;
            t.Stok = int.Parse(tbxStok.Text);
            t.Kategori=int.Parse(cbxKategori.Text);
            t.Fiyat=decimal.Parse(tbxFiyat.Text);
            t.Durum = true;
            db.Tbl_Urun.Add(t);
            db.SaveChanges();
            MessageBox.Show("Ürün başarıyla kaydedildi");
            Listele();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            var id = db.Tbl_Urun.Find(int.Parse(tbxUrunId.Text));

            db.Tbl_Urun.Remove(id);
            db.SaveChanges();
            MessageBox.Show("Ürün başarıyla silindi");
            Listele();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tbxUrunId.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            tbxUrunAd.Text= dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            tbxMarka.Text= dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            tbxStok.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            tbxFiyat.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            tbxDurum.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            cbxKategori.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            var urun = db.Tbl_Urun.Find(int.Parse(tbxUrunId.Text));
            urun.UrunAdi= tbxUrunAd.Text;
            urun.Stok=int.Parse(tbxStok.Text);
            urun.Marka=tbxMarka.Text;
            urun.Fiyat=decimal.Parse(tbxFiyat.Text);
            urun.Durum = bool.Parse(tbxDurum.Text);
            urun.Kategori =int.Parse( cbxKategori.Text);
            
            db.SaveChanges();
            MessageBox.Show("Ürün başarıyla güncellendi");
            Listele();

        }
    }
}
