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
    public partial class gorevtanimla : Form
    {

        public static DataSet ds = new DataSet();
        BindingSource bs = new BindingSource();//datasetteki kayıtları forma aktarmak için kullanılır
        OleDbConnection baglan = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + "\\vt.mdb");
        string tutnumara;
        bool yenikayitmi = false;
        public gorevtanimla()
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
            string seckomutu = "select per.AdiSoyadi,bol.badi,abd.abdadi,gorev.* from personel as per,anabilimdali as abd,bolumler as bol,gorevsureleri as gorev where bol.bkodu=gorev.bkodu and abd.abdkodu=gorev.abdkodu and gorev.Sicilno=per.Sicilno";
            OleDbDataAdapter da = new OleDbDataAdapter(seckomutu, baglan);//
            if (ds.Tables["gorevler"] != null)//bosluk degilse temizle
                ds.Tables["gorevler"].Clear();
            da.Fill(ds, "gorevler");

            
        }

        private void btnyenikayit_Click(object sender, EventArgs e)
        {
            if (cbgorevturu.Text == "Daimi")
                dtizinbitis.Visible = false;
            else
                dtizinbitis.Visible = true;

            tbid.Text=cbbolumadi.Text = cbanabilimdaliadi.Text = cbpersoneladisoyadi.Text = dtizinbaslangic.Text = dtizinbitis.Text = cbgorevturu.Text = cbunvani.Text = "";
            yenikayitmi = true;
            cbbolumadi.Enabled = cbanabilimdaliadi.Enabled = cbpersoneladisoyadi.Enabled = dtizinbaslangic.Enabled = dtizinbitis.Enabled = cbgorevturu.Enabled = cbunvani.Enabled = true;
            btnyenikayit.Enabled = btnduzelt.Enabled = btnsil.Enabled = false;
            btnkaydet.Enabled = btniptal.Enabled = true;
        }

        private void btnduzelt_Click(object sender, EventArgs e)
        {
            if (cbgorevturu.Text == "Daimi")
            {
                label5.Visible = false;
                dtizinbitis.Visible = false;
            }
            else
            {
                label5.Visible = true;
                dtizinbitis.Visible = true;
            }  
            yenikayitmi = false;
            cbbolumadi.Enabled = cbanabilimdaliadi.Enabled = cbpersoneladisoyadi.Enabled = dtizinbaslangic.Enabled = dtizinbitis.Enabled = cbgorevturu.Enabled = cbunvani.Enabled = true;
            btnyenikayit.Enabled = btnduzelt.Enabled = btnsil.Enabled = false;
            btnkaydet.Enabled = btniptal.Enabled = true;
        }

        private void btniptal_Click(object sender, EventArgs e)
        {
            cbbolumadi.Enabled = cbanabilimdaliadi.Enabled = cbpersoneladisoyadi.Enabled = dtizinbaslangic.Enabled = dtizinbitis.Enabled = cbgorevturu.Enabled = cbunvani.Enabled = false;
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
                    cmd.CommandText = "delete from gorevsureleri where Id=@numara";
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
            if(cbbolumadi.Text.Trim()=="" || cbanabilimdaliadi.Text.Trim()==""||cbpersoneladisoyadi.Text.Trim()==""||cbunvani.Text.Trim()==""||cbgorevturu.Text.Trim()=="")
            {
                MessageBox.Show("Boş Alanları Doldurunuz...");
            }
            else if(dtizinbitis.Value.Date < dtizinbaslangic.Value.Date && cbgorevturu.Text=="Sözleşmeli")
            {
                MessageBox.Show("Başlangıç Tarihi Bitiş Tarihinden Sonra Olamaz");
                
            }
            else if (dtizinbaslangic.Value.Date == dtizinbitis.Value.Date && cbgorevturu.Text=="Sözleşmeli")
            {
                MessageBox.Show("Başlangıç Tarihi Bitiş Tarihiyle Aynı Olamaz");
            }
            else
            {

                if (yenikayitmi)
                {
                    if (cbgorevturu.Text == "Sözleşmeli")
                    {
                        OleDbCommand cmd = new OleDbCommand();
                        cmd.Connection = baglan;
                        cmd.CommandText = "insert into gorevsureleri(bkodu,abdkodu,Sicilno,Unvani,GorevTuru,BaslangicTarihi,BitisTarihi) Values (@bkodu,@abdkodu,@Sicilno,@Unvani,@GorevTuru,@BaslangicTarihi,@BitisTarihi)";//bu alanlara kayıt et @lılıer parametrler
                        cmd.Parameters.AddWithValue("@bkodu", cbbolumadi.SelectedValue);
                        cmd.Parameters.AddWithValue("@abdkodu", cbanabilimdaliadi.SelectedValue);
                        cmd.Parameters.AddWithValue("@Sicilno", cbpersoneladisoyadi.SelectedValue);
                        cmd.Parameters.AddWithValue("@Unvani", cbunvani.Text);
                        cmd.Parameters.AddWithValue("@GorevTuru", cbgorevturu.Text);
                        cmd.Parameters.AddWithValue("@BaslangicTarihi", Convert.ToDateTime(dtizinbaslangic.Text));
                        cmd.Parameters.AddWithValue("@BitisTarihi", Convert.ToDateTime(dtizinbitis.Text));
                        cmd.ExecuteNonQuery();//veritabanına kayıt ekleme işlemi fizikseltabloda var
                        MessageBox.Show("Kayıt İşlemi Yapıldı...");
                        veriler_cek();
                    }
                    else
                    {
                        OleDbCommand cmd = new OleDbCommand();
                        cmd.Connection = baglan;
                        cmd.CommandText = "insert into gorevsureleri(bkodu,abdkodu,Sicilno,Unvani,GorevTuru,BaslangicTarihi,BitisTarihi) Values (@bkodu,@abdkodu,@Sicilno,@Unvani,@GorevTuru,@BaslangicTarihi,@BitisTarihi)";//bu alanlara kayıt et @lılıer parametrler
                        cmd.Parameters.AddWithValue("@bkodu", cbbolumadi.SelectedValue);
                        cmd.Parameters.AddWithValue("@abdkodu", cbanabilimdaliadi.SelectedValue);
                        cmd.Parameters.AddWithValue("@Sicilno", cbpersoneladisoyadi.SelectedValue);
                        cmd.Parameters.AddWithValue("@Unvani", cbunvani.Text);
                        cmd.Parameters.AddWithValue("@GorevTuru", cbgorevturu.Text);
                        cmd.Parameters.AddWithValue("@BaslangicTarihi", Convert.ToDateTime(dtizinbaslangic.Text));
                        cmd.Parameters.AddWithValue("@BitisTarihi", Convert.ToDateTime(dtizinbaslangic.Text));

                        cmd.ExecuteNonQuery();//veritabanına kayıt ekleme işlemi fizikseltabloda var
                        MessageBox.Show("Kayıt İşlemi Yapıldı...");
                        veriler_cek();
                    }

                }
                else
                {
                    if (cbgorevturu.Text == "Sözleşmeli")
                    {
                        OleDbCommand cmd = new OleDbCommand();
                        cmd.Connection = baglan;
                        cmd.CommandText = "update gorevsureleri set bkodu=@bkodu,abdkodu=@abdkodu,Sicilno=@Sicilno,Unvani=@Unvani,GorevTuru=@GorevTuru,BaslangicTarihi=@BaslangicTarihi,BitisTarihi=@BitisTarihi where Id=@numara1";
                        cmd.Parameters.AddWithValue("@bkodu", cbbolumadi.SelectedValue);
                        cmd.Parameters.AddWithValue("@abdkodu", cbanabilimdaliadi.SelectedValue);
                        cmd.Parameters.AddWithValue("@Sicilno", cbpersoneladisoyadi.SelectedValue);
                        cmd.Parameters.AddWithValue("@Unvani", cbunvani.Text);
                        cmd.Parameters.AddWithValue("@GorevTuru", cbgorevturu.Text);
                        cmd.Parameters.AddWithValue("@BaslangicTarihi", Convert.ToDateTime(dtizinbaslangic.Text));
                        cmd.Parameters.AddWithValue("@BitisTarihi", Convert.ToDateTime(dtizinbitis.Text));

                        cmd.Parameters.AddWithValue("@numara1", tbid.Text);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Düzenleme İşlemi Yapıldı...");
                        veriler_cek();
                    }
                    else
                    {
                        OleDbCommand cmd = new OleDbCommand();
                        cmd.Connection = baglan;
                        cmd.CommandText = "update gorevsureleri set bkodu=@bkodu,abdkodu=@abdkodu,Sicilno=@Sicilno,Unvani=@Unvani,GorevTuru=@GorevTuru,BaslangicTarihi=@BaslangicTarihi,BitisTarihi=@BitisTarihi where Id=@numara1";
                        cmd.Parameters.AddWithValue("@bkodu", cbbolumadi.SelectedValue);
                        cmd.Parameters.AddWithValue("@abdkodu", cbanabilimdaliadi.SelectedValue);
                        cmd.Parameters.AddWithValue("@Sicilno", cbpersoneladisoyadi.SelectedValue);
                        cmd.Parameters.AddWithValue("@Unvani", cbunvani.Text);
                        cmd.Parameters.AddWithValue("@GorevTuru", cbgorevturu.Text);
                        cmd.Parameters.AddWithValue("@BaslangicTarihi", Convert.ToDateTime(dtizinbaslangic.Text));
                        cmd.Parameters.AddWithValue("@BitisTarihi", Convert.ToDateTime(dtizinbaslangic.Text));
                        cmd.Parameters.AddWithValue("@numara1", tbid.Text);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Düzenleme İşlemi Yapıldı...");
                        veriler_cek();
                    }
                }
                cbbolumadi.Enabled = cbanabilimdaliadi.Enabled = cbpersoneladisoyadi.Enabled = dtizinbaslangic.Enabled = dtizinbitis.Enabled = cbgorevturu.Enabled = cbunvani.Enabled = false;
                btnkaydet.Enabled = btniptal.Enabled = false;
                btnyenikayit.Enabled = btnduzelt.Enabled = btnsil.Enabled = true;
            }
        }

        private void gorevtanimla_Load(object sender, EventArgs e)
        {
            if (cbgorevturu.Text == "Daimi")
            {
                label5.Visible = false;
                dtizinbitis.Visible = false;
            }
            else
            {
                label5.Visible = true;
                dtizinbitis.Visible = true;
            }  
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

            veriler_cek();
            bs.DataSource = ds.Tables["gorevler"];// badi.DataSource = ds.Tables["bolumler"]; iki comboboxsı da bırlıkte caliştiriyor
            dataGridView1.DataSource = bs;

            tbid.DataBindings.Add("Text", bs, "Id");
            cbbolumadi.DataBindings.Add("SelectedValue", bs, "bkodu");
            cbanabilimdaliadi.DataBindings.Add("SelectedValue", bs, "abdkodu");
            cbpersoneladisoyadi.DataBindings.Add("SelectedValue", bs, "Sicilno");
            cbunvani.DataBindings.Add("Text", bs, "Unvani");
            cbgorevturu.DataBindings.Add("Text", bs, "GorevTuru");
            dtizinbaslangic.DataBindings.Add("Text", bs, "BaslangicTarihi");
            dtizinbitis.DataBindings.Add("Text", bs, "BitisTarihi");
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
                    string sec = "select * from personel where bkodu=" + cbbolumadi.SelectedValue+" and abdkodu=" + cbanabilimdaliadi.SelectedValue;//butun kayıtları sec
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

        private void cbpersoneladisoyadi_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbanabilimdaliadi.Items.Count > 0)
                {
                    if (ds.Tables["personel2"] != null)
                        ds.Tables["personel2"].Clear();
                    string sec = "select Unvani from personel where bkodu=" + cbbolumadi.SelectedValue+" and abdkodu=" + cbanabilimdaliadi.SelectedValue+ " and AdiSoyadi='"+cbpersoneladisoyadi.Text+"'";//butun kayıtları sec
                    OleDbDataAdapter da = new OleDbDataAdapter(sec, baglan);
                    da.Fill(ds, "personel2");// sanal tabloya doldur

                    cbunvani.DisplayMember = "Unvani";
                    cbunvani.DataSource = ds.Tables["personel2"];
                }
            }
            catch
            {

            }
        }

        void arama(string aranan, string field)
        {
            string seckomutu = "select per.AdiSoyadi,bol.badi,abd.abdadi,gorev.* from personel as per,anabilimdali as abd,bolumler as bol,gorevsureleri as gorev where bol.bkodu=gorev.bkodu and abd.abdkodu=gorev.abdkodu and gorev.Sicilno=per.Sicilno and " + field + " like '%" + aranan + "%'";//ogr.numara--->field  tbnumaraara.Text--->aranan
            OleDbDataAdapter da = new OleDbDataAdapter(seckomutu, baglan);
            if (ds.Tables["gorevler"] != null)
                ds.Tables["gorevler"].Clear();
            da.Fill(ds, "gorevler");
        }

        private void tbaranumara_TextChanged(object sender, EventArgs e)
        {
            arama(tbaranumara.Text, "gorev.Sicilno");
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string seckomutu = "select per.AdiSoyadi,bol.badi,abd.abdadi,gorev.* from personel as per,anabilimdali as abd,bolumler as bol,gorevsureleri as gorev where bol.bkodu=gorev.bkodu and abd.abdkodu=gorev.abdkodu and gorev.Sicilno=per.Sicilno and gorev.Unvani='" +cbaraunvani.Text+"'" ;
            OleDbDataAdapter da = new OleDbDataAdapter(seckomutu, baglan);
            if (ds.Tables["gorevler"] != null)
                ds.Tables["gorevler"].Clear();
            da.Fill(ds, "gorevler");
        }

        private void cbgorevturu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbgorevturu.Text == "Daimi")
            {
                label5.Visible = false;
                dtizinbitis.Visible = false;
            }
            else
            {
                label5.Visible = true;
                dtizinbitis.Visible = true;
            }    
        }

        private void cbaragorevturu_SelectedIndexChanged(object sender, EventArgs e)
        {
            string seckomutu = "select per.AdiSoyadi,bol.badi,abd.abdadi,gorev.* from personel as per,anabilimdali as abd,bolumler as bol,gorevsureleri as gorev where bol.bkodu=gorev.bkodu and abd.abdkodu=gorev.abdkodu and gorev.Sicilno=per.Sicilno and gorev.GorevTuru='" + cbaragorevturu.Text + "'";
            OleDbDataAdapter da = new OleDbDataAdapter(seckomutu, baglan);
            if (ds.Tables["gorevler"] != null)
                ds.Tables["gorevler"].Clear();
            da.Fill(ds, "gorevler");
        }

        private void btnraporla_Click(object sender, EventArgs e)
        {
            ReportPersonelGorevSureleri raporla = new ReportPersonelGorevSureleri();
            raporla.ShowDialog();
        }

        private void btngoster_Click(object sender, EventArgs e)
        {
            string baslangic = dtbaslangic.Value.Month + "/" + dtbaslangic.Value.Day + "/" + dtbaslangic.Value.Year;
            string bitis = dtbitis.Value.Month + "/" + dtbitis.Value.Day + "/" + dtbitis.Value.Year;
            string seckomutu = "select per.AdiSoyadi,bol.badi,abd.abdadi,gorev.* from personel as per,anabilimdali as abd,bolumler as bol,gorevsureleri as gorev where bol.bkodu=gorev.bkodu and abd.abdkodu=gorev.abdkodu and gorev.Sicilno=per.Sicilno and BitisTarihi BETWEEN #"+baslangic+"# and #"+bitis+"#";
            OleDbDataAdapter da = new OleDbDataAdapter(seckomutu, baglan);//
            if (ds.Tables["gorevler"] != null)//bosluk degilse temizle
                ds.Tables["gorevler"].Clear();
            da.Fill(ds, "gorevler");
        }

        private void hakkındaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form7 f7 = new Form7();
            f7.ShowDialog();
            this.Hide();
        }

     

    }
}
