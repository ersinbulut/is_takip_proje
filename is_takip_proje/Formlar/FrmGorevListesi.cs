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
    public partial class FrmGorevListesi : Form
    {
        public FrmGorevListesi()
        {
            InitializeComponent();
        }
        DbİsTakipEntities db = new DbİsTakipEntities();

        void Listele()
        {
            var degerler = from x in db.TblGorevler
                           select new
                           {
                               x.Aciklama
                           };
            gridControl1.DataSource = degerler.ToList();
        }
        private void FrmGorevListesi_Load(object sender, EventArgs e)
        {
            Listele();

            lblAktifGorev.Text = db.TblGorevler.Count(x => x.Durum == true).ToString();
            lblPasifGorev.Text = db.TblGorevler.Count(x => x.Durum == false).ToString();
            lblToplamDepartman.Text = db.TblDepartmanlar.Count().ToString();

            chartControl1.Series["Durum"].Points.AddPoint("Aktif Görevler", int.Parse(lblAktifGorev.Text));
            chartControl1.Series["Durum"].Points.AddPoint("Pasif Görevler", int.Parse(lblPasifGorev.Text));

        }
    }
}
