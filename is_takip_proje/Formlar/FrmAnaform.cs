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
    public partial class FrmAnaform : Form
    {
        public FrmAnaform()
        {
            InitializeComponent();
        }
        DbİsTakipEntities db = new DbİsTakipEntities();
        private void FrmAnaform_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = (from x in db.TblGorevler
                                       select new
                                       {
                                           x.Aciklama,
                                           GorevVeren = x.TblPersonel1.Ad + " " + x.TblPersonel1.Soyad,
                                           GorevAlan = x.TblPersonel.Ad + " " + x.TblPersonel.Soyad,
                                           x.Durum
                                       }).Where(x => x.Durum == true).ToList();
            gridView1.Columns["Durum"].Visible = false;

            //bugün yapılan görevler
            gridControl2.DataSource = (from x in db.TblGorevDetaylar
                                       select new
                                       {
                                           Görev = x.TblGorevler.Aciklama,
                                           GorevVeren = x.TblGorevler.TblPersonel1.Ad + " " + x.TblGorevler.TblPersonel1.Soyad,
                                           GorevAlan = x.TblGorevler.TblPersonel.Ad + " " + x.TblGorevler.TblPersonel.Soyad,
                                           x.Tarih
                                       }).Where(x => x.Tarih == DateTime.Today).ToList();

            //aktif çağrı listesi
            gridControl3.DataSource = (from x in db.TblCagrilar
                                       select new
                                       {
                                           x.TblFirmalar.Ad,
                                           x.Konu,
                                           x.Tarih,
                                           x.Durum
                                       }).Where(x => x.Durum == true).ToList();
            gridView3.Columns["Durum"].Visible = false;



        }
    }
}
