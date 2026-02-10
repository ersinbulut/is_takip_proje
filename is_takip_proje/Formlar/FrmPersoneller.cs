using DevExpress.XtraEditors;
using is_takip_proje.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace is_takip_proje.Formlar
{
    public partial class FrmPersoneller : Form
    {
        DbİsTakipEntities db = new DbİsTakipEntities();
        public FrmPersoneller()
        {
            InitializeComponent();
        }

        void listele()
        {
            var degerler = from x in db.TblPersonel
                           select new
                           {
                               x.ID,
                               x.Ad,
                               x.Soyad,
                               x.Mail,
                               x.Telefon,
                               x.Gorsel,
                               Departman = x.TblDepartmanlar.Ad,
                               x.Durum
                           };
            gridControl1.DataSource = degerler.Where(x => x.Durum == true).ToList();
        }


        private void FrmPersoneller_Load(object sender, EventArgs e)
        {
            listele();
            lpDEPARTMAN.Properties.ValueMember = "ID";
            lpDEPARTMAN.Properties.DisplayMember = "Ad";
            lpDEPARTMAN.Properties.DataSource = (from x in db.TblDepartmanlar
                                                 select new
                                                 {
                                                     x.ID,
                                                     x.Ad
                                                 }).ToList();
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            TblPersonel t = new TblPersonel();
            t.Ad = txtAD.Text;
            t.Soyad = txtSOYAD.Text;
            t.Mail = txtMAİL.Text;
            t.Telefon = txtTELEFON.Text;
            t.Gorsel = txtGORSEL.Text;
            t.Departman = int.Parse(lpDEPARTMAN.EditValue.ToString());
            db.TblPersonel.Add(t);
            db.SaveChanges();
            XtraMessageBox.Show("Yeni personel kaydı başarılı bir şekilde gerçekleşti",
                "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            TblPersonel t = db.TblPersonel.Find(int.Parse(txtID.Text));
            t.Durum = false;
            db.SaveChanges();
            XtraMessageBox.Show("Personel kaydı pasif hale getirildi",
                "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            txtID.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
            txtAD.Text = gridView1.GetFocusedRowCellValue("Ad").ToString();
            txtSOYAD.Text = gridView1.GetFocusedRowCellValue("Soyad").ToString();
            txtMAİL.Text = gridView1.GetFocusedRowCellValue("Mail").ToString();
            txtTELEFON.Text = gridView1.GetFocusedRowCellValue("Telefon").ToString();
            txtGORSEL.Text = gridView1.GetFocusedRowCellValue("Gorsel").ToString();
            lpDEPARTMAN.EditValue = gridView1.GetFocusedRowCellValue("Departman").ToString();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtID.Text);
            var deger = db.TblPersonel.Find(id);
            deger.Ad = txtAD.Text;
            deger.Soyad = txtSOYAD.Text;
            deger.Mail = txtMAİL.Text;
            deger.Telefon = txtTELEFON.Text;
            deger.Gorsel = txtGORSEL.Text;
            deger.Departman = int.Parse(lpDEPARTMAN.EditValue.ToString());
            db.SaveChanges();
            XtraMessageBox.Show("Personel kaydı başarılı bir şekilde güncellendi",
                "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
        }
    }
}
