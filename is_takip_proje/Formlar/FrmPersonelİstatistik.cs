using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using is_takip_proje.Entity;

namespace is_takip_proje.Formlar
{
    public partial class FrmPersonelİstatistik : Form
    {
        DbİsTakipEntities db = new DbİsTakipEntities();
        public FrmPersonelİstatistik()
        {
            InitializeComponent();
        }

        private void FrmPersonelİstatistik_Load(object sender, EventArgs e)
        {
            lblToplamDepartman.Text = db.TblDepartmanlar.Count().ToString();
            lblToplamPersonel.Text = db.TblPersonel.Count().ToString();
            lblToplamFirma.Text = db.TblFirmalar.Count().ToString();

            lblAktifis.Text = db.TblGorevler.Count(x => x.Durum == "1").ToString();
            lblPasifis.Text = db.TblGorevler.Count(x => x.Durum == "0").ToString();

            lblSonGorev.Text = db.TblGorevler.OrderByDescending(x => x.ID).Select(x => x.Aciklama).FirstOrDefault();
        }
    }
}
