using is_takip_proje.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace is_takip_proje.Formlar
{
    public partial class FrmGorevDetay : Form
    {
        public FrmGorevDetay()
        {
            InitializeComponent();
        }

        DbİsTakipEntities db = new DbİsTakipEntities();
        private void FrmGorevDetay_Load(object sender, EventArgs e)
        {
            db.TblGorevDetaylar.Load();

            BindingSource bindingSource1 = new BindingSource();
         bindingSource1.DataSource = db.TblGorevDetaylar.Local.ToBindingList();
            gridControl1.DataSource = bindingSource1;
        }
    }
}
