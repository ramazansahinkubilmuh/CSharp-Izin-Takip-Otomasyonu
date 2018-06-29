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
    public partial class personel : Form
    {
        DataSet ds = new DataSet();
        BindingSource bs = new BindingSource();//datasetteki kayıtları forma aktarmak için kullanılır
        OleDbConnection baglan = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + "\\vt.mdb");
        string tutnumara;
        bool yenikayitmi = false;
        public personel()
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

        bool kayit_varmi()
        {
            string sec = "select * from personel where Sicilno=" + tbsicilno.Text;//numara string oldugu için tek tırnak konur aynı numaralı var mı diye arar bu 5 satır
            OleDbDataAdapter da = new OleDbDataAdapter(sec, baglan);
            if (ds.Tables["ara"] != null)
                ds.Tables["ara"].Clear();
            da.Fill(ds, "ara");

            if (ds.Tables["ara"].Rows.Count > 0)
                return true;
            else
                return false;
        }

        void veriler_cek()
        {
            string seckomutu = "select abd.abdadi, bol.badi, per.* from anabilimdali as abd, bolumler as bol , personel as per where bol.bkodu=per.bkodu and abd.abdkodu=per.abdkodu";//bolumler teblodundakı ile ogrencile tablosundakş bolumkodu eslesenleri getir
            OleDbDataAdapter da = new OleDbDataAdapter(seckomutu, baglan);//
            if (ds.Tables["personel"] != null)//bosluk degilse temizle
                ds.Tables["personel"].Clear();
            da.Fill(ds, "personel");
        }

        private void personel_Load(object sender, EventArgs e)
        {
            baglan.Open();
            string sec = "select * from bolumler";//butun kayıtları sec
            OleDbDataAdapter da = new OleDbDataAdapter(sec, baglan);
            da.Fill(ds, "bolumler");// sanal tabloya doldur
            cbbolumadi.ValueMember = "bkodu";//combo boxın arkasındaki gizlenecek kodu 
            cbbolumadi.DisplayMember = "badi";// burasıda okunan kodu
            cbbolumadi.DataSource = ds.Tables["bolumler"];

            da.Fill(ds, "bolumler1");// sanal tabloya doldur
            cbarabolumadi.ValueMember = "bkodu";//combo boxın arkasındaki gizlenecek kodu 
            cbarabolumadi.DisplayMember = "badi";// burasıda okunan kodu
            cbarabolumadi.DataSource = ds.Tables["bolumler1"];

            btnkaydet.Enabled = btniptal.Enabled = false;
            cbunvani.SelectedIndex = 0;//***********************************************************************
            veriler_cek();
            bs.DataSource = ds.Tables["personel"];// badi.DataSource = ds.Tables["bolumler"]; iki comboboxsı da bırlıkte caliştiriyor
            dataGridView1.DataSource = bs;

            tbsicilno.DataBindings.Add("Text", bs, "Sicilno");
            cbbolumadi.DataBindings.Add("SelectedValue",bs,"bkodu");
            cbanabilimdaliadi.DataBindings.Add("SelectedValue",bs,"abdkodu");
            cbunvani.DataBindings.Add("Text", bs, "Unvani");
            tbadisoyadi.DataBindings.Add("Text",bs,"AdiSoyadi");

            tutnumara = tbsicilno.Text;
        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            if (tbsicilno.Text.Trim() == "" || cbbolumadi.Text.Trim() == "" ||cbunvani.Text.Trim()=="" || cbanabilimdaliadi.Text.Trim() == "" || tbadisoyadi.Text.Trim() == "")
            {
                MessageBox.Show("Boş Alanları Doldurunuz...");
            }
            else
            {
                if (yenikayitmi)
                {
                    if (kayit_varmi())
                        MessageBox.Show(tbsicilno.Text + " Numaralı Kayıt Var.");
                    else
                    {
                        
                        OleDbCommand cmd = new OleDbCommand();
                        cmd.Connection = baglan;
                        cmd.CommandText = "insert into personel(Sicilno,Unvani,bkodu,abdkodu,AdiSoyadi) Values (@Sicilno,@Unvani,@bkodu,@abdkodu,@AdiSoyadi)";//bu alanlara kayıt et @lılıer parametrler
                        cmd.Parameters.AddWithValue("@Sicilno", tbsicilno.Text);
                        cmd.Parameters.AddWithValue("@Unvani", cbunvani.Text);
                        cmd.Parameters.AddWithValue("@bkodu", cbbolumadi.SelectedValue);
                        cmd.Parameters.AddWithValue("@abdkodu", cbanabilimdaliadi.SelectedValue);
                        cmd.Parameters.AddWithValue("@AdiSoyadi", tbadisoyadi.Text);
                        cmd.ExecuteNonQuery();//veritabanına kayıt ekleme işlemi fizikseltabloda var
                        MessageBox.Show("Kayıt İşlemi Yapıldı...");
                        tbsicilno.Enabled = cbbolumadi.Enabled = cbanabilimdaliadi.Enabled = cbunvani.Enabled = tbadisoyadi.Enabled = false;
                        btnkaydet.Enabled = btniptal.Enabled = false;
                        btnyenikayit.Enabled = btnduzelt.Enabled = btnsil.Enabled = true;
                        veriler_cek();
                    }
                }

                else
                {

                    if (tbsicilno.Text != tutnumara & kayit_varmi())
                    {
                        MessageBox.Show(tbsicilno.Text + " Numaralı Kayıt Var.");
                    }
                    else
                    {
                        
                        OleDbCommand cmd = new OleDbCommand();
                        cmd.Connection = baglan;
                        cmd.CommandText = "update personel set Sicilno=@Sicilno,Unvani=@Unvani,bkodu=@bkodu,abdkodu=@abdkodu,AdiSoyadi=@AdiSoyadi where Sicilno=@numara1";
                        cmd.Parameters.AddWithValue("@Sicilno", tbsicilno.Text);
                        cmd.Parameters.AddWithValue("@Unvani", cbunvani.Text);
                        cmd.Parameters.AddWithValue("@bkodu", cbbolumadi.SelectedValue);
                        cmd.Parameters.AddWithValue("@abdkodu", cbanabilimdaliadi.SelectedValue);
                        cmd.Parameters.AddWithValue("@AdiSoyadi", tbadisoyadi.Text);
                        cmd.Parameters.AddWithValue("@numara1", tutnumara);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Düzenleme İşlemi Yapıldı...");
                        tbsicilno.Enabled = cbbolumadi.Enabled = cbanabilimdaliadi.Enabled = cbunvani.Enabled = tbadisoyadi.Enabled = false;
                        btnkaydet.Enabled = btniptal.Enabled = false;
                        btnyenikayit.Enabled = btnduzelt.Enabled = true;
                        veriler_cek();
                    }
                }
            }

            
        }

        private void btnyenikayit_Click(object sender, EventArgs e)
        {
            tbsicilno.Text = cbbolumadi.Text = cbanabilimdaliadi.Text = cbunvani.Text = tbadisoyadi.Text ="";
            btnyenikayit.Enabled = btnduzelt.Enabled = btnsil.Enabled = false;
            tbsicilno.Enabled = cbbolumadi.Enabled = cbanabilimdaliadi.Enabled = cbunvani.Enabled = tbadisoyadi.Enabled= true;
            btnkaydet.Enabled = btniptal.Enabled = true;
            yenikayitmi = true;
        }

        private void btniptal_Click(object sender, EventArgs e)
        {
            tbsicilno.Enabled = cbbolumadi.Enabled = cbanabilimdaliadi.Enabled = cbunvani.Enabled = tbadisoyadi.Enabled = false;
            btnyenikayit.Enabled = btnduzelt.Enabled = btnsil.Enabled = true;
            bs.Position = 0;
            btniptal.Enabled = btnkaydet.Enabled = false;
        }

        private void btnduzelt_Click(object sender, EventArgs e)
        {
            tbsicilno.Enabled = cbbolumadi.Enabled = cbanabilimdaliadi.Enabled = cbunvani.Enabled = tbadisoyadi.Enabled = true;
            btnyenikayit.Enabled = btnduzelt.Enabled = btnsil.Enabled = false;
            yenikayitmi = false;
            tutnumara = tbsicilno.Text;
            btnkaydet.Enabled = btniptal.Enabled = true;
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

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            tutnumara = tbsicilno.Text;
        }

        private void cbarabolumadi_SelectedIndexChanged(object sender, EventArgs e)
        {
            string seckomutu = "select abd.abdadi, bol.badi, per.* from anabilimdali as abd, bolumler as bol , personel as per where bol.bkodu=per.bkodu and abd.abdkodu=per.abdkodu and per.bkodu=" + cbarabolumadi.SelectedValue;//bolumler teblodundakı ile ogrencile tablosundakş bolumkodu eslesenleri getir
            OleDbDataAdapter da = new OleDbDataAdapter(seckomutu, baglan);
            if (ds.Tables["personel"] != null)
                ds.Tables["personel"].Clear();
            da.Fill(ds, "personel");
        }

        void arama(string aranan, string field)
        {
            string seckomutu = "select abd.abdadi, bol.badi, per.* from anabilimdali as abd, bolumler as bol , personel as per where bol.bkodu=per.bkodu and abd.abdkodu=per.abdkodu and " + field + " like '%" + aranan + "%'";//ogr.numara--->field  tbnumaraara.Text--->aranan
            OleDbDataAdapter da = new OleDbDataAdapter(seckomutu, baglan);
            if (ds.Tables["personel"] != null)
                ds.Tables["personel"].Clear();
            da.Fill(ds, "personel");
        }

        private void tbaranumara_TextChanged(object sender, EventArgs e)
        {
            arama(tbaranumara.Text, "per.Sicilno");
        }

        private void tbaraadi_TextChanged(object sender, EventArgs e)
        {
            arama(tbaraadi.Text, "per.AdiSoyadi");
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                veriler_cek();
            else
                cbarabolumadi_SelectedIndexChanged(sender, e);
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            if (bs.Count>0)
            {
                DialogResult cevap = MessageBox.Show("Silmek istediğinize Emin misiniz ? ", "Uyarı", MessageBoxButtons.YesNo);
                if (cevap == DialogResult.Yes)
                {
                    OleDbCommand cmd = new OleDbCommand();
                    cmd.Connection = baglan;
                    cmd.CommandText = "delete from personel where Sicilno=@numara";
                    cmd.Parameters.Add("@numara", tbsicilno.Text);
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

        private void cbaraunvani_SelectedIndexChanged(object sender, EventArgs e)
        {
            string seckomutu = "select abd.abdadi, bol.badi, per.* from anabilimdali as abd, bolumler as bol , personel as per where bol.bkodu=per.bkodu and abd.abdkodu=per.abdkodu and per.Unvani='" + cbaraunvani.Text+"'";//bolumler teblodundakı ile ogrencile tablosundakş bolumkodu eslesenleri getir
            OleDbDataAdapter da = new OleDbDataAdapter(seckomutu, baglan);
            if (ds.Tables["personel"] != null)
                ds.Tables["personel"].Clear();
            da.Fill(ds, "personel");
        }

        private void hakkındaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form7 f7 = new Form7();
            f7.ShowDialog();
            this.Hide();
        }
    }
}
