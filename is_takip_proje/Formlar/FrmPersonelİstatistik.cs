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
            //toplam departman sayısını saydırırız
            lblToplamDepartman.Text = db.TblDepartmanlar.Count().ToString();
            //toplam personel sayısını saydırırız
            lblToplamPersonel.Text = db.TblPersonel.Count().ToString();
            //toplam firma sayısını saydırırız
            lblToplamFirma.Text = db.TblFirmalar.Count().ToString();
            //aktif ve pasif görevleri saydırırız durum 1 ise aktif 0 ise pasif
            lblAktifis.Text = db.TblGorevler.Count(x => x.Durum == true).ToString();
            lblPasifis.Text = db.TblGorevler.Count(x => x.Durum == false).ToString();
            //son görevi getirirız orderbydescending ile id ye göre sıralarız ve ilkini alırız
            lblSonGorev.Text = db.TblGorevler.OrderByDescending(x => x.ID).Select(x => x.Aciklama).FirstOrDefault();
            //son görev detayını getirirız orderbydescending ile id ye göre sıralarız ve ilkini alırız
            lblSongorevdetayi.Text = db.TblGorevler.OrderByDescending(x => x.ID).Select(x => x.Tarih).FirstOrDefault().ToString();
            //her bir ili bir kere saydırırız distinct ile
            lblSehirsayisi.Text = (from x in db.TblFirmalar
                                   select x.İl).Distinct().Count().ToString();
            //her bir sektörü bir kere saydırırız distinct ile
            lblSektor.Text = (from x in db.TblFirmalar
                              select x.Sektor).Distinct().Count().ToString();
            //bugün açılan görevleri saydırırız tarih bugün olanları saydırırız
            lblBugunacilangorevler.Text = db.TblGorevler.Count(x => x.Tarih == DateTime.Today).ToString();
            //en fazla görevi olan personeli getirirız groupby ile gorevalan a göre gruplarız ve orderbydescending ile sayısına göre sıralarız ve ilkini alırız
            var d1 = db.TblGorevler.GroupBy(x => x.GorevAlan).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault().ToString();
            //personel tablosundan id si d1 olan personelin adını ve soyadını getiririz
            lblAyinPersoneli.Text = db.TblPersonel.Where(x => x.ID.ToString() == d1).Select(x => x.Ad + " " + x.Soyad).FirstOrDefault();
            //departman tablosundan id si d1 olan departmanın adını getiririz
            lblAyinDepartmani.Text = db.TblDepartmanlar.Where(x => x.ID.ToString() == d1).Select(x => x.Ad).FirstOrDefault();




        }


    }
}
