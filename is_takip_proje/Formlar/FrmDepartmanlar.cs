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
    public partial class FrmDepartmanlar : Form
    {
        DbİsTakipEntities db = new DbİsTakipEntities();
        public FrmDepartmanlar()
        {
            InitializeComponent();
        }

        void listele()
        {
            var degerler = from x in db.TblDepartmanlar
                           select new
                           {
                               x.ID,
                               x.Ad
                           };
            gridControl1.DataSource = degerler.ToList();
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void FrmDepartmanlar_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            TblDepartmanlar t = new TblDepartmanlar();
            t.Ad = txtAD.Text;
            db.TblDepartmanlar.Add(t);
            db.SaveChanges();
            XtraMessageBox.Show("Departman başarılı bir şekilde sisteme kaydedildi", "Bilgi",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtID.Text);
            var deger = db.TblDepartmanlar.Find(id);
            db.TblDepartmanlar.Remove(deger);
            db.SaveChanges();
            XtraMessageBox.Show("Departman başarılı bir şekilde sistemden silindi", "Bilgi",
                MessageBoxButtons.OK, MessageBoxIcon.Stop);
            listele();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            txtID.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
            txtAD.Text = gridView1.GetFocusedRowCellValue("Ad").ToString();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtID.Text);
            var deger = db.TblDepartmanlar.Find(id);
            deger.ID = id;
            deger.Ad = txtAD.Text;
            db.SaveChanges();
            XtraMessageBox.Show("Departman başarılı bir şekilde sistemde güncellendi", "Bilgi",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            listele();
        }
    }
}
