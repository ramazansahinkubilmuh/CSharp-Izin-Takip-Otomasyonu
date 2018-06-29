using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace IzinTakipOtomasyonu
{
    public partial class izinler : Form
    {
        public static DataSet ds = new DataSet();
        BindingSource bs = new BindingSource();//datasetteki kayıtları forma aktarmak için kullanılır
        OleDbConnection baglan = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + "\\vt.mdb");
        string tutnumara;
        bool yenikayitmi = false;
        public izinler()
        {
            InitializeComponent();
        }

        public void Key_PressHarf(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)Keys.Space)
            {
                if (char.IsLetter(e.KeyChar) == false && e.KeyChar != (char)08 && e.KeyChar != (char)44)
                {
                    e.Handled = true;
                    MessageBox.Show("Sadece Harf Girişi Yapabilirsiniz ! ", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        public void Key_PressSayi(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false && e.KeyChar != (char)08 && e.KeyChar != (char)44)
            {
                e.Handled = true;
                MessageBox.Show("Sadece Sayı Girişi Yapabilirsiniz ! ", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        void veriler_cek()
        {
            string seckomutu = "select per.AdiSoyadi,bol.badi,abd.abdadi,izin.* from personel as per,anabilimdali as abd,bolumler as bol,izinler as izin where bol.bkodu=izin.bkodu and abd.abdkodu=izin.abdkodu and izin.Sicilno=per.Sicilno";
            OleDbDataAdapter da = new OleDbDataAdapter(seckomutu, baglan);//
            if (ds.Tables["izinler"] != null)//bosluk degilse temizle
                ds.Tables["izinler"].Clear();
            da.Fill(ds, "izinler");

            
        }

        private void izinler_Load(object sender, EventArgs e)
        {
            btnkaydet.Enabled = btniptal.Enabled = false;
            baglan.Open();

            string sec = "select * from bolumler";//butun kayıtları sec
            OleDbDataAdapter da2 = new OleDbDataAdapter(sec, baglan);
            if (ds.Tables["bolumler"] != null)//bosluk degilse temizle
                ds.Tables["bolumler"].Clear();
            da2.Fill(ds, "bolumler");// sanal tabloya doldur
            cbbolumadi.ValueMember = "bkodu";//combo boxın arkasındaki gizlenecek kodu 
            cbbolumadi.DisplayMember = "badi";// burasıda okunan kodu
            cbbolumadi.DataSource = ds.Tables["bolumler"];

            
            cbizinturu.SelectedIndex = 0;//***********************************************************************
            veriler_cek();
            bs.DataSource = ds.Tables["izinler"];// badi.DataSource = ds.Tables["bolumler"]; iki comboboxsı da bırlıkte caliştiriyor
            dataGridView1.DataSource = bs;

            tbid.DataBindings.Add("Text",bs,"Id");
            cbbolumadi.DataBindings.Add("SelectedValue",bs,"bkodu");
            cbanabilimdaliadi.DataBindings.Add("SelectedValue",bs,"abdkodu");
            cbpersoneladisoyadi.DataBindings.Add("SelectedValue",bs,"Sicilno");
            dtizinbaslangic.DataBindings.Add("Text", bs, "BaslangicTarihi");
            dtizinbitis.DataBindings.Add("Text", bs, "BitisTarihi");
            cbizinturu.DataBindings.Add("Text",bs,"İzinTuru");
            tbizinsuresi.DataBindings.Add("Text",bs,"İzinSuresi");

        }

        private void cbbolumadi_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbbolumadi.Items.Count > 0)
                {
                    if (ds.Tables["anabilimdali"] != null)
                        ds.Tables["anabilimdali"].Clear();
                    string sec = "select * from anabilimdali where bkodu=" + cbbolumadi.SelectedValue;//butun kayıtları sec
                    OleDbDataAdapter da = new OleDbDataAdapter(sec, baglan);
                    da.Fill(ds, "anabilimdali");// sanal tabloya doldur
                    cbanabilimdaliadi.ValueMember = "abdkodu";//combo boxın arkasındaki gizlenecek kodu 
                    cbanabilimdaliadi.DisplayMember = "abdadi";// burasıda okunan kodu
                    cbanabilimdaliadi.DataSource = ds.Tables["anabilimdali"];
                }
            }
            catch
            {

            }
        }

        private void cbanabilimdaliadi_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbanabilimdaliadi.Items.Count > 0)
                {
                    if (ds.Tables["personel"] != null)
                        ds.Tables["personel"].Clear();
                    string sec = "select * from personel where abdkodu=" + cbanabilimdaliadi.SelectedValue;//butun kayıtları sec
                    OleDbDataAdapter da = new OleDbDataAdapter(sec, baglan);
                    da.Fill(ds, "personel");// sanal tabloya doldur
                    cbpersoneladisoyadi.ValueMember = "Sicilno";//combo boxın arkasındaki gizlenecek kodu 
                    cbpersoneladisoyadi.DisplayMember = "AdiSoyadi";// burasıda okunan kodu
                    cbpersoneladisoyadi.DataSource = ds.Tables["personel"];
                }
            }
            catch
            {

            }
        }

        private void btnyenikayit_Click(object sender, EventArgs e)
        {
            cbbolumadi.Text = cbanabilimdaliadi.Text = cbpersoneladisoyadi.Text = dtizinbaslangic.Text = dtizinbitis.Text = cbizinturu.Text = tbizinsuresi.Text = "";
            yenikayitmi = true;
            cbbolumadi.Enabled = cbanabilimdaliadi.Enabled = cbpersoneladisoyadi.Enabled = dtizinbaslangic.Enabled = dtizinbitis.Enabled = cbizinturu.Enabled = tbizinsuresi.Enabled = true;
            btnyenikayit.Enabled = btnduzelt.Enabled = btnsil.Enabled = false;
            btnkaydet.Enabled = btniptal.Enabled = true;
        }

        private void btnduzelt_Click(object sender, EventArgs e)
        {
            yenikayitmi = false;
            tbizinsuresi.Text = "";
            cbbolumadi.Enabled = cbanabilimdaliadi.Enabled = cbpersoneladisoyadi.Enabled = dtizinbaslangic.Enabled = dtizinbitis.Enabled = cbizinturu.Enabled = tbizinsuresi.Enabled = true;
            btnyenikayit.Enabled = btnduzelt.Enabled = false;
            btnyenikayit.Enabled = btnduzelt.Enabled = btnsil.Enabled = false;
        }

        private void btniptal_Click(object sender, EventArgs e)
        {
            cbbolumadi.Enabled = cbanabilimdaliadi.Enabled = cbpersoneladisoyadi.Enabled = dtizinbaslangic.Enabled = dtizinbitis.Enabled = cbizinturu.Enabled = tbizinsuresi.Enabled = false;
            btnkaydet.Enabled = btniptal.Enabled = false;
            btnyenikayit.Enabled = btnduzelt.Enabled = btnsil.Enabled = true;
        }
        private void btnkaydet_Click(object sender, EventArgs e)
        {
            if (cbbolumadi.Text.Trim() == "" || cbanabilimdaliadi.Text.Trim() == "" || cbpersoneladisoyadi.Text.Trim() == "" || cbizinturu.Text.Trim() == "" || tbizinsuresi.Text.Trim() == "")
            {
                MessageBox.Show("Boş Alanları Doldurunuz...");
            }
            else
            {
                
                if (yenikayitmi)
                {
                    OleDbCommand cmd = new OleDbCommand();
                    cmd.Connection = baglan;
                    cmd.CommandText = "insert into izinler(bkodu,abdkodu,Sicilno,İzinTuru,BaslangicTarihi,BitisTarihi,İzinSuresi) Values (@bkodu,@abdkodu,@Sicilno,@İzinTuru,@BaslangicTarihi,@BitisTarihi,@İzinSuresi)";//bu alanlara kayıt et @lılıer parametrler
                    cmd.Parameters.AddWithValue("@bkodu", cbbolumadi.SelectedValue);
                    cmd.Parameters.AddWithValue("@abdkodu", cbanabilimdaliadi.SelectedValue);
                    cmd.Parameters.AddWithValue("@Sicilno", cbpersoneladisoyadi.SelectedValue);
                    cmd.Parameters.AddWithValue("@İzinTuru", cbizinturu.Text);
                    cmd.Parameters.AddWithValue("@BaslangicTarihi", Convert.ToDateTime(dtizinbaslangic.Text));
                    cmd.Parameters.AddWithValue("@BitisTarihi", Convert.ToDateTime(dtizinbitis.Text));
                    cmd.Parameters.AddWithValue("@İzinSuresi", tbizinsuresi.Text);

                    cmd.ExecuteNonQuery();//veritabanına kayıt ekleme işlemi fizikseltabloda var
                    MessageBox.Show("Kayıt İşlemi Yapıldı...");
                    veriler_cek();
                }
                else
                {
                    OleDbCommand cmd = new OleDbCommand();
                    cmd.Connection = baglan;
                    cmd.CommandText = "update izinler set bkodu=@bkodu,abdkodu=@abdkodu,Sicilno=@Sicilno,İzinTuru=@İzinTuru,BaslangicTarihi=@BaslangicTarihi,BitisTarihi=@BitisTarihi,İzinSuresi=@İzinSuresi where Id=@numara1";
                    cmd.Parameters.AddWithValue("@bkodu", cbbolumadi.SelectedValue);
                    cmd.Parameters.AddWithValue("@abdkodu", cbanabilimdaliadi.SelectedValue);
                    cmd.Parameters.AddWithValue("@Sicilno", cbpersoneladisoyadi.SelectedValue);
                    cmd.Parameters.AddWithValue("@İzinTuru", cbizinturu.Text);
                    cmd.Parameters.AddWithValue("@BaslangicTarihi", Convert.ToDateTime(dtizinbaslangic.Text));
                    cmd.Parameters.AddWithValue("@BitisTarihi", Convert.ToDateTime(dtizinbitis.Text));
                    cmd.Parameters.AddWithValue("@İzinSuresi", tbizinsuresi.Text);

                    cmd.Parameters.AddWithValue("@numara1", tbid.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Düzenleme İşlemi Yapıldı...");
                    veriler_cek();
                }
                cbbolumadi.Enabled = cbanabilimdaliadi.Enabled = cbpersoneladisoyadi.Enabled = dtizinbaslangic.Enabled = dtizinbitis.Enabled = cbizinturu.Enabled = tbizinsuresi.Enabled = false;
                btnkaydet.Enabled = btniptal.Enabled = false;
                btnyenikayit.Enabled = btnduzelt.Enabled = btnsil.Enabled = true;
            }
            
            
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            if (bs.Count > 0)
            {
                DialogResult cevap = MessageBox.Show("Silmek istediğinize Emin misiniz ? ", "Uyarı", MessageBoxButtons.YesNo);
                if (cevap == DialogResult.Yes)
                {
                    OleDbCommand cmd = new OleDbCommand();
                    cmd.Connection = baglan;
                    cmd.CommandText = "delete from izinler where Id=@numara";
                    cmd.Parameters.Add("@numara", tbid.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Kaydınız Silindi...");
                    veriler_cek();
                }
            }
            else
            {
                MessageBox.Show("Silinecek Kayıt Yoktur...");
            }
        }

        void arama(string aranan, string field)
        {
            string seckomutu = "select per.AdiSoyadi,bol.badi,abd.abdadi,izin.* from personel as per,anabilimdali as abd,bolumler as bol,izinler as izin where bol.bkodu=izin.bkodu and abd.abdkodu=izin.abdkodu and izin.Sicilno=per.Sicilno and " + field + " like '%" + aranan + "%'";//ogr.numara--->field  tbnumaraara.Text--->aranan
            OleDbDataAdapter da = new OleDbDataAdapter(seckomutu, baglan);
            if (ds.Tables["izinler"] != null)
                ds.Tables["izinler"].Clear();
            da.Fill(ds, "izinler");
        }

        private void tbaranumara_TextChanged(object sender, EventArgs e)
        {
            arama(tbaranumara.Text, "izin.Sicilno");
        }

        private void tbaraadi_TextChanged(object sender, EventArgs e)
        {
            arama(tbaraadi.Text, "per.AdiSoyadi");
        }

        private void tbarabolumadi_TextChanged(object sender, EventArgs e)
        {
            arama(tbarabolumadi.Text,"bol.badi");
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                veriler_cek();
            else
                tbarabolumadi_TextChanged(sender,e);
        }

        private void bölümTanımlaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bolumler f1 = new bolumler();
            f1.Show();
            this.Hide();
        }

        private void anabilimTanımlaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            anabilimler f2 = new anabilimler();
            f2.Show();
            this.Hide();
        }

        private void personelTanımlaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            personel f3 = new personel();
            f3.Show();
            this.Hide();
        }

        private void izinTanımlaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            izinler f4 = new izinler();
            f4.Show();
            this.Hide();
        }

        private void personelGörevSüresiTanımlaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gorevtanimla f5 = new gorevtanimla();
            f5.Show();
            this.Hide();
        }

        private void süreliGörevTanımlaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sureligorevtanimla f6 = new sureligorevtanimla();
            f6.Show();
            this.Hide();
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnraporla_Click(object sender, EventArgs e)
        {
            ReportIzinler raporla = new ReportIzinler();
            raporla.ShowDialog();
        }

        private void btngoster_Click(object sender, EventArgs e)
        {
            string baslangic = dtbaslangic.Value.Month + "/" + dtbaslangic.Value.Day + "/" + dtbaslangic.Value.Year;
            string bitis = dtbitis.Value.Month + "/" + dtbitis.Value.Day + "/" + dtbitis.Value.Year;
            string seckomutu = "select per.AdiSoyadi,bol.badi,abd.abdadi,izin.* from personel as per,anabilimdali as abd,bolumler as bol,izinler as izin where bol.bkodu=izin.bkodu and abd.abdkodu=izin.abdkodu and izin.Sicilno=per.Sicilno and BitisTarihi BETWEEN #" + baslangic + "# and #" + bitis + "#";
            OleDbDataAdapter da = new OleDbDataAdapter(seckomutu, baglan);//
            if (ds.Tables["izinler"] != null)//bosluk degilse temizle
                ds.Tables["izinler"].Clear();
            da.Fill(ds, "izinler");
        }

        private void tbizinsuresi_Click(object sender, EventArgs e)
        {
            tbizinsuresi.Text = "";
            if (dtizinbitis.Value.Date < dtizinbaslangic.Value.Date)
            {
                MessageBox.Show("Başlangıç Tarihi Bitiş Tarihinden Sonra Olamaz");
            }
            else if (dtizinbaslangic.Value.Date == dtizinbitis.Value.Date)
            {
                MessageBox.Show("Başlangıç Tarihi Bitiş Tarihiyle Aynı Olamaz");
            }
            else
            {
                tbizinsuresi.Text = (dtizinbitis.Value.Date - dtizinbaslangic.Value.Date).TotalDays.ToString() + " Gün";
            }
        }

        private void dtizinbitis_ValueChanged(object sender, EventArgs e)
        {
            tbizinsuresi.Text = "";
        }

        private void hakkındaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form7 f7 = new Form7();
            f7.ShowDialog();
            this.Hide();
        }    
   
    }
}
