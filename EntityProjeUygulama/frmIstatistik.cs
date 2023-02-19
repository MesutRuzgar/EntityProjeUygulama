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
    public partial class frmIstatistik : Form
    {
        public frmIstatistik()
        {
            InitializeComponent();
        }

        DbEntityUrunEntities db = new DbEntityUrunEntities();

        private void frmIstatistik_Load(object sender, EventArgs e)
        {
            //TOPLAM KATEGORI
            lbl.Text = db.Tbl_Kategori.Count().ToString();
            //TOPLAM URUN
            label3.Text = db.Tbl_Urun.Count().ToString();
            //AKTİF MUSTERI
            label17.Text = db.Tbl_Musteri.Count(x=>x.Durum==true).ToString();
            //PASİF MUSTERI
            label5.Text = db.Tbl_Musteri.Count(x => x.Durum == false).ToString();
            //beyaz esya sayısı
            label7.Text = db.Tbl_Urun.Count(x => x.Kategori==6 ).ToString();
            //toplam stok
            label19.Text = db.Tbl_Urun.Sum(x=>x.Stok).ToString();
            //en yüksek fiyatlı ürün
            label9.Text = (from x in db.Tbl_Urun orderby x.Fiyat descending select x.UrunAdi ).FirstOrDefault();
            //en düşük fiyatlı ürün
            label11.Text = (from x in db.Tbl_Urun orderby x.Fiyat ascending select x.UrunAdi).FirstOrDefault();
            //kasadaki tutar
            label13.Text=db.Tbl_Satis.Sum(c=>c.Fiyat).ToString()+ " TL";
            //sehir sayısı
            //sehri sec bunları tekrarsız getir topla string yaz dedik
            label21.Text = (from x in db.Tbl_Musteri select x.Sehir).Distinct().Count().ToString() ;
            //en fazla ürünlü marka
            label15.Text = db.markagetir().FirstOrDefault();

        }
    }
}
