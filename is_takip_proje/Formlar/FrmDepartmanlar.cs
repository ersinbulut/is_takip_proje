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
    }
}
