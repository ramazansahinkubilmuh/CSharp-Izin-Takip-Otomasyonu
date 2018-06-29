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
    public partial class anabilimler : Form
    {
        DataSet ds = new DataSet();
        BindingSource bs = new BindingSource();//datasetteki kayıtları forma aktarmak için kullanılır
        OleDbConnection baglan = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + "\\vt.mdb");
        bool yenikayitmi = false;
        bool kontrol = false;
        public anabilimler()
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

        void kayitlari_cek()
        {
            string seckomutu = "select a.*,b.badi from anabilimdali as a, bolumler as b where a.bkodu=b.bkodu";
            OleDbDataAdapter da = new OleDbDataAdapter(seckomutu, baglan);//verileri çeker ve datasete doldurma işlemi yapar
            if (ds.Tables["anabilimdali"] != null)
                ds.Tables["anabilimdali"].Clear();
            da.Fill(ds, "anabilimdali");//da.fill komutu dataset içindeki verileri bolumler sanal tablosuna aktarıyor ve verilere ulaşmamızı sağlıyor
        }

        private void anabilimler_Load(object sender, EventArgs e)
        {
            btnkaydet.Enabled = btniptal.Enabled = false;
            if (baglan.State == ConnectionState.Closed)//baglantı açık mı değil değil mi kontrol ettiriyoruz
                baglan.Open();
            kayitlari_cek();
            bs.DataSource = ds.Tables["anabilimdali"];//form içindeki nesnelere aktarma işlemi yapıyor
            tbabdkodu.DataBindings.Add("Text", bs, "abdkodu");
            tbabdadi.DataBindings.Add("Text", bs, "abdadi");
            cbbolumadi.DataBindings.Add("SelectedValue", bs, "bkodu");
            dataGridView1.DataSource = bs;

            string sec = "select * from bolumler";
            OleDbDataAdapter da = new OleDbDataAdapter(sec, baglan);
            da.Fill(ds, "bolumler");//dataset içindeki sanal bolumler tablosuna doldur
            da.Fill(ds, "bolumler1");
            cbbolumadi.DataSource = ds.Tables["bolumler"];//dataset içindeki bolumler tablosunu combobox'ın datasource özelliği olsun
            cbbolumadi.ValueMember = "bkodu";
            cbbolumadi.DisplayMember = "badi";

            cbbolumadiaranan.DataSource = ds.Tables["bolumler1"];//dataset içindeki bolumler tablosunu combobox'ın datasource özelliği olsun
            cbbolumadiaranan.ValueMember = "bkodu";
            cbbolumadiaranan.DisplayMember = "badi";
            kontrol = true;
        }

        private void btnyenikayit_Click(object sender, EventArgs e)
        {
            btnyenikayit.Enabled = btnduzelt.Enabled = btnsil.Enabled = false;
            cbbolumadi.Enabled = true;
            btnkaydet.Enabled = btniptal.Enabled = true;
            yenikayitmi = true;
            tbabdadi.ReadOnly = false;
            tbabdadi.Clear();
            tbabdkodu.Clear();
            btnkaydet.Visible = btniptal.Visible = true;
        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            if (tbabdadi.Text.Trim() == "")
            {
                MessageBox.Show("Anabilim Dalı Adını Boş Geçemezsiniz...");
            }
            else
            {
                
                OleDbCommand cmd = new OleDbCommand();//Sql komutlarını bu nesne vasıtasıyla yapıyoruz
                cmd.Connection = baglan;
                if (yenikayitmi)
                {
                    cmd.CommandText = "insert into anabilimdali (abdadi,bkodu) values (@abdadi,@bkodu)";
                    cmd.Parameters.Add("@abdadi", tbabdadi.Text);
                    cmd.Parameters.Add("@bkodu", cbbolumadi.SelectedValue);
                }
                else
                {
                    cmd.CommandText = "update anabilimdali set abdadi=@abdadi,bkodu=@bkodu where abdkodu=@abdkodu";
                    cmd.Parameters.Add("@abdadi", tbabdadi.Text);
                    cmd.Parameters.Add("@bkodu", cbbolumadi.SelectedValue);
                    cmd.Parameters.Add("@abdkodu", tbabdkodu.Text);
                }
                cmd.ExecuteNonQuery();//Sorguyu çalıştırma işlemi yapıyor
                MessageBox.Show("Kayıt Gerçekleştirildi");
                tbabdadi.ReadOnly = true;
                tbabdkodu.ReadOnly = true;
                cbbolumadi.Enabled = false;
                btnkaydet.Enabled = btniptal.Enabled = false;
                btnyenikayit.Enabled = btnduzelt.Enabled = btnsil.Enabled = true;
                kayitlari_cek();
            }

            
        }

        private void btnduzelt_Click(object sender, EventArgs e)
        {
            yenikayitmi = false;
            tbabdadi.ReadOnly = false;
            btnkaydet.Enabled = btniptal.Enabled = true;
            btnyenikayit.Enabled = btnduzelt.Enabled = btnsil.Enabled = false;
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
                    cmd.CommandText = "delete from anabilimdali where abdkodu=@abdkodu";
                    cmd.Parameters.Add("@abdkodu", tbabdkodu.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Kaydınız Silindi...");
                    kayitlari_cek();
                }
            }
            else
            {
                MessageBox.Show("Silinecek Kayıt Yoktur...");
            }
        }

        private void abdaranan_TextChanged(object sender, EventArgs e)
        {
            string seckomutu = "select anabilimdali.*,bolumler.badi from anabilimdali,bolumler where anabilimdali.bkodu=bolumler.bkodu and abdadi like '%" + abdaranan.Text + "%'";
            OleDbDataAdapter da = new OleDbDataAdapter(seckomutu, baglan);
            ds.Tables["anabilimdali"].Clear();
            da.Fill(ds, "anabilimdali");
        }

        private void cbbolumadiaranan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (kontrol)
            {
                string seckomutu = "select anabilimdali.*,bolumler.badi from anabilimdali,bolumler where anabilimdali.bkodu=bolumler.bkodu and bolumler.badi like '%" + cbbolumadiaranan.Text + "%'";
                OleDbDataAdapter da = new OleDbDataAdapter(seckomutu, baglan);
                ds.Tables["anabilimdali"].Clear();
                da.Fill(ds, "anabilimdali");
            }
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                kayitlari_cek();
            else
                cbbolumadiaranan_SelectedIndexChanged(sender,e);
        }

        private void btniptal_Click(object sender, EventArgs e)
        {
            btnkaydet.Enabled = btniptal.Enabled = false;
            btnyenikayit.Enabled = btnduzelt.Enabled = btnsil.Enabled = true;
            cbbolumadi.Enabled = false;
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

        private void hakkındaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form7 f7 = new Form7();
            f7.ShowDialog();
            this.Hide();
        }




    }
}
