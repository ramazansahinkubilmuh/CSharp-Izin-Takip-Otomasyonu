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
    public partial class bolumler : Form
    {
        DataSet ds = new DataSet();
        BindingSource bs = new BindingSource();//datasetteki kayıtları forma aktarmak için kullanılır
        OleDbConnection baglan = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + "\\vt.mdb");
        bool yenikayitmi = false;

        public bolumler()
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
            string seckomutu = "select * from bolumler";
            OleDbDataAdapter da = new OleDbDataAdapter(seckomutu, baglan);//verileri çeker ve datasete doldurma işlemi yapar
            ds.Clear();
            da.Fill(ds, "bolumler");//da.fill komutu dataset içindeki verileri bolumler sanal tablosuna aktarıyor ve verilere ulaşmamızı sağlıyor
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnkaydet.Enabled = btniptal.Enabled = false;
            if (baglan.State == ConnectionState.Closed)//baglantı açık mı değil değil mi kontrol ettiriyoruz
                baglan.Open();
            kayitlari_cek();
            bs.DataSource = ds.Tables["bolumler"];//form içindeki nesnelere aktarma işlemi yapıyor
            tbbkodu.DataBindings.Add("Text", bs, "bkodu");
            tbbadi.DataBindings.Add("Text", bs, "badi");
            dataGridView1.DataSource = bs;
        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {

            if (tbbadi.Text.Trim() =="")
            {
                MessageBox.Show("Bölüm Adı Boş Geçilemez...");
            }
            else
            {
                
                OleDbCommand cmd = new OleDbCommand();//Sql komutlarını bu nesne vasıtasıyla yapıyoruz
                cmd.Connection = baglan;
                if (yenikayitmi)
                {
                    cmd.CommandText = "insert into bolumler (badi) values (@badi)";
                    cmd.Parameters.Add("@badi", tbbadi.Text);
                }
                else
                {
                    cmd.CommandText = "update bolumler set badi=@badi where bkodu=@bkodu";
                    cmd.Parameters.Add("@badi", tbbadi.Text);
                    cmd.Parameters.Add("@bkodu", tbbkodu.Text);
                }
                cmd.ExecuteNonQuery();//Sorguyu çalıştırma işlemi yapıyor
                MessageBox.Show("Kayıt Gerçekleştirildi");
                tbbadi.ReadOnly = true;
                btnkaydet.Enabled = btniptal.Enabled = false;
                btnyenikayit.Enabled = btnduzelt.Enabled = btnsil.Enabled = true;
                kayitlari_cek();
            }
            
        }

        private void btnyenikayit_Click(object sender, EventArgs e)
        {
            btnkaydet.Enabled = btniptal.Enabled = true;
            btnyenikayit.Enabled = btnduzelt.Enabled=btnsil.Enabled = false;
            yenikayitmi = true;
            tbbadi.ReadOnly = false;
            tbbadi.Clear();
            tbbkodu.Clear();
            btnkaydet.Visible = btniptal.Visible = true;
        }

        private void btnduzelt_Click(object sender, EventArgs e)
        {
            yenikayitmi = false;
            tbbadi.ReadOnly = false;
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
                    cmd.CommandText = "delete from bolumler where bkodu=@bkodu";
                    cmd.Parameters.Add("@bkodu", tbbkodu.Text);
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

        private void tbaranan_TextChanged(object sender, EventArgs e)
        {
            string seckomutu = "select * from bolumler where badi like '%" + tbaranan.Text + "%'";
            OleDbDataAdapter da = new OleDbDataAdapter(seckomutu, baglan);
            ds.Clear();
            da.Fill(ds, "bolumler");
        }

        private void btniptal_Click(object sender, EventArgs e)
        {
            btnkaydet.Enabled = false;
            btnyenikayit.Enabled = btnduzelt.Enabled = btnsil.Enabled = true;
            btniptal.Enabled = false;
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                kayitlari_cek();
            else
            {
                tbaranan_TextChanged(sender,e);
            }
        }

        private void hakkındaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form7 f7 = new Form7();
            f7.ShowDialog();
            this.Hide();
        }

    }
}
