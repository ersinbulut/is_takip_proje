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
    public partial class FrmGorev : Form
    {
        public FrmGorev()
        {
            InitializeComponent();
        }
        DbİsTakipEntities db = new DbİsTakipEntities();
        private void FrmGorev_Load(object sender, EventArgs e)
        {
            lpGorevAlan.Properties.DataSource = (from x in db.TblPersonel
                                              select new
                                              {
                                                  x.ID,
                                                  AdSoyad = x.Ad + " " + x.Soyad
                                              }).ToList();
            lpGorevAlan.Properties.DisplayMember = "AdSoyad";
            lpGorevAlan.Properties.ValueMember = "ID";

        }

        private void BtnVazgec_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            TblGorevler t = new TblGorevler();
            t.Aciklama = txtAciklama.Text;
            t.GorevVeren = int.Parse(txtGorevVeren.Text);
            t.GorevAlan = int.Parse(lpGorevAlan.EditValue.ToString());

            t.Tarih = DateTime.Parse(txtTarih.Text);
            db.TblGorevler.Add(t);
            db.SaveChanges();
            XtraMessageBox.Show("Görev Başarıyla Kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
