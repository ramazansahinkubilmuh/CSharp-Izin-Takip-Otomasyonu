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
    public partial class sureligorevtanimla : Form
    {
        public static DataSet ds = new DataSet();
        BindingSource bs = new BindingSource();//datasetteki kayıtları forma aktarmak için kullanılır
        OleDbConnection baglan = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + "\\vt.mdb");
        string tutnumara;
        bool yenikayitmi = false;
        public sureligorevtanimla()
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
            string seckomutu = "select gorev.* from sureligorevler as gorev";
            OleDbDataAdapter da = new OleDbDataAdapter(seckomutu, baglan);//
            if (ds.Tables["gorevler"] != null)//bosluk degilse temizle
                ds.Tables["gorevler"].Clear();
            da.Fill(ds, "gorevler");
        }

        

        private void btnyenikayit_Click(object sender, EventArgs e)
        {
            cbatanmasekli.Text=tbid.Text = dtizinbaslangic.Text = dtizinbitis.Text = tbgorevliadisoyadi.Text = tbgorevunvan.Text = "";
            yenikayitmi = true;
            cbatanmasekli.Enabled=dtizinbaslangic.Enabled = dtizinbitis.Enabled = tbgorevunvan.Enabled = tbgorevliadisoyadi.Enabled = true;
            btnyenikayit.Enabled = btnduzelt.Enabled = btnsil.Enabled = false;
            btnkaydet.Enabled = btniptal.Enabled = true;
        }

        private void btnduzelt_Click(object sender, EventArgs e)
        {
            yenikayitmi = false;
            cbatanmasekli.Enabled=dtizinbaslangic.Enabled = dtizinbitis.Enabled = tbgorevunvan.Enabled = tbgorevliadisoyadi.Enabled = true;
            btnyenikayit.Enabled = btnduzelt.Enabled = btnsil.Enabled = false;
            btnkaydet.Enabled = btniptal.Enabled = true;
        }

        private void btniptal_Click(object sender, EventArgs e)
        {
            cbatanmasekli.Enabled=dtizinbaslangic.Enabled = dtizinbitis.Enabled = tbgorevunvan.Enabled = tbgorevliadisoyadi.Enabled = false;
            btnkaydet.Enabled = btniptal.Enabled = false;
            btnyenikayit.Enabled = btnduzelt.Enabled = btnsil.Enabled = true;
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
                    cmd.CommandText = "delete from sureligorevler where Id=@numara";
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

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            if (tbgorevunvan.Text.Trim() == "" || tbgorevliadisoyadi.Text.Trim() == "" || cbatanmasekli.Text.Trim() == "")
            {
                MessageBox.Show("Boş Alanları Doldurunuz...");
            }
            else if(dtizinbitis.Value.Date < dtizinbaslangic.Value.Date)
            {
                MessageBox.Show("Başlangıç Tarihi Bitiş Tarihinden Sonra Olamaz");
                
            }
            else if (dtizinbaslangic.Value.Date == dtizinbitis.Value.Date)
            {
                MessageBox.Show("Başlangıç Tarihi Bitiş Tarihiyle Aynı Olamaz");
            }
            else
            {
                

                if (yenikayitmi)
                {
                    OleDbCommand cmd = new OleDbCommand();
                    cmd.Connection = baglan;
                    cmd.CommandText = "insert into sureligorevler(GorevAdi,GorevliAdi,BaslangicTarihi,BitisTarihi,AtanmaSekli) Values (@GorevAdi,@GorevliAdi,@BaslangicTarihi,@BitisTarihi,@AtanmaSekli)";//bu alanlara kayıt et @lılıer parametrler
                    cmd.Parameters.AddWithValue("@GorevAdi", tbgorevunvan.Text);
                    cmd.Parameters.AddWithValue("@GorevliAdi", tbgorevliadisoyadi.Text);
                    cmd.Parameters.AddWithValue("@BaslangicTarihi", dtizinbaslangic.Value.Date);
                    cmd.Parameters.AddWithValue("@BitisTarihi", dtizinbitis.Value.Date);
                    cmd.Parameters.AddWithValue("@AtanmaSekli", cbatanmasekli.Text);
                    cmd.ExecuteNonQuery();//veritabanına kayıt ekleme işlemi fizikseltabloda var
                    MessageBox.Show("Kayıt İşlemi Yapıldı...");
                    veriler_cek();
                }
                else
                {
                    OleDbCommand cmd = new OleDbCommand();
                    cmd.Connection = baglan;
                    cmd.CommandText = "update sureligorevler set GorevAdi=@GorevAdi,GorevliAdi=@GorevliAdi,BaslangicTarihi=@BaslangicTarihi,BitisTarihi=@BitisTarihi,AtanmaSekli=@AtanmaSekli where Id=@numara1";
                    cmd.Parameters.AddWithValue("@GorevAdi", tbgorevunvan.Text);
                    cmd.Parameters.AddWithValue("@GorevliAdi", tbgorevliadisoyadi.Text);
                    cmd.Parameters.AddWithValue("@BaslangicTarihi", dtizinbaslangic.Value.Date);
                    cmd.Parameters.AddWithValue("@BitisTarihi", dtizinbitis.Value.Date);
                    cmd.Parameters.AddWithValue("@AtanmaSekli", cbatanmasekli.Text);

                    cmd.Parameters.AddWithValue("@numara1", tbid.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Düzenleme İşlemi Yapıldı...");
                    veriler_cek();
                }
                cbatanmasekli.Enabled = dtizinbaslangic.Enabled = dtizinbitis.Enabled = tbgorevunvan.Enabled = tbgorevliadisoyadi.Enabled = false;
                btnkaydet.Enabled = btniptal.Enabled = false;
                btnyenikayit.Enabled = btnduzelt.Enabled = btnsil.Enabled = true;
            }
            
        }

        private void sureligorevtanimla_Load(object sender, EventArgs e)
        {
            cbatanmasekli.Enabled = dtizinbaslangic.Enabled = dtizinbitis.Enabled = tbgorevunvan.Enabled = tbgorevliadisoyadi.Enabled = false;
            btnkaydet.Enabled = btniptal.Enabled = false;
            baglan.Open();

            veriler_cek();
            bs.DataSource = ds.Tables["gorevler"];// badi.DataSource = ds.Tables["bolumler"]; iki comboboxsı da bırlıkte caliştiriyor
            dataGridView1.DataSource = bs;

            tbid.DataBindings.Add("Text",bs,"Id");
            tbgorevunvan.DataBindings.Add("Text",bs,"GorevAdi");
            tbgorevliadisoyadi.DataBindings.Add("Text",bs,"GorevliAdi");
            dtizinbaslangic.DataBindings.Add("Text", bs, "BaslangicTarihi");
            dtizinbitis.DataBindings.Add("Text", bs, "BitisTarihi");
            cbatanmasekli.DataBindings.Add("Text",bs,"AtanmaSekli");

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
        private void hakkındaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form7 f7 = new Form7();
            f7.ShowDialog();
            this.Hide();
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                veriler_cek();
            else
                cbaraatanmasekli_SelectedIndexChanged(sender,e);
        }

        private void cbaraatanmasekli_SelectedIndexChanged(object sender, EventArgs e)
        {
            string seckomutu = "select gorev.* from sureligorevler as gorev where gorev.AtanmaSekli='" + cbaraatanmasekli.Text + "'";
            OleDbDataAdapter da = new OleDbDataAdapter(seckomutu, baglan);
            if (ds.Tables["gorevler"] != null)
                ds.Tables["gorevler"].Clear();
            da.Fill(ds, "gorevler");
        }

        private void tbaragorevliadisoyadi_TextChanged(object sender, EventArgs e)
        {
            string seckomutu = "select gorev.* from sureligorevler as gorev where gorev.GorevAdi like '%" + tbaragorevliadisoyadi.Text + "%'";//ogr.numara--->field  tbnumaraara.Text--->aranan
            OleDbDataAdapter da = new OleDbDataAdapter(seckomutu, baglan);
            if (ds.Tables["gorevler"] != null)
                ds.Tables["gorevler"].Clear();
            da.Fill(ds, "gorevler");
        }

        private void btnraporla_Click(object sender, EventArgs e)
        {
            
            ReportSureliGorevler raporla = new ReportSureliGorevler();
            raporla.ShowDialog();
        }

        private void btngoster_Click(object sender, EventArgs e)
        {
            string baslangic = dtbaslangic.Value.Month + "/" + dtbaslangic.Value.Day + "/" + dtbaslangic.Value.Year;
            string bitis = dtbitis.Value.Month + "/" + dtbitis.Value.Day + "/" + dtbitis.Value.Year;
            string seckomutu = "select gorev.* from sureligorevler as gorev where BitisTarihi BETWEEN #"+baslangic+"# and #"+bitis+"#";
            OleDbDataAdapter da = new OleDbDataAdapter(seckomutu, baglan);//
            if (ds.Tables["gorevler"] != null)//bosluk degilse temizle
                ds.Tables["gorevler"].Clear();
            da.Fill(ds, "gorevler");
        }

       
    }
}
