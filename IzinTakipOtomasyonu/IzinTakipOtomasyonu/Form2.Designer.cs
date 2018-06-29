namespace IzinTakipOtomasyonu
{
    partial class anabilimler
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.cbbolumadiaranan = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.badi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bkodu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.abdkodu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.abdadi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label5 = new System.Windows.Forms.Label();
            this.abdaranan = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnsil = new System.Windows.Forms.Button();
            this.btnduzelt = new System.Windows.Forms.Button();
            this.btnyenikayit = new System.Windows.Forms.Button();
            this.btniptal = new System.Windows.Forms.Button();
            this.btnkaydet = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbbolumadi = new System.Windows.Forms.ComboBox();
            this.tbabdadi = new System.Windows.Forms.TextBox();
            this.tbabdkodu = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.bölümTanımlamaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bölümTanımlaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.anabilimTanımlamaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.anabilimTanımlaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.personelTanımlamaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.personelTanımlaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.izinTanımlamaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.izinTanımlaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.personelGörevSüreleriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.personelGörevSüresiTanımlaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.süreliGörevTanımlamalarıToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.süreliGörevTanımlaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hakkındaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.çıkışToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.checkBox1);
            this.groupBox3.Controls.Add(this.cbbolumadiaranan);
            this.groupBox3.Controls.Add(this.dataGridView1);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.abdaranan);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox3.Location = new System.Drawing.Point(247, 282);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(802, 368);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Arama ve Listeleme";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(693, 109);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(74, 21);
            this.checkBox1.TabIndex = 5;
            this.checkBox1.Text = "T.K.G.";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // cbbolumadiaranan
            // 
            this.cbbolumadiaranan.BackColor = System.Drawing.Color.White;
            this.cbbolumadiaranan.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cbbolumadiaranan.FormattingEnabled = true;
            this.cbbolumadiaranan.Location = new System.Drawing.Point(170, 87);
            this.cbbolumadiaranan.Name = "cbbolumadiaranan";
            this.cbbolumadiaranan.Size = new System.Drawing.Size(174, 24);
            this.cbbolumadiaranan.TabIndex = 4;
            this.cbbolumadiaranan.SelectedIndexChanged += new System.EventHandler(this.cbbolumadiaranan_SelectedIndexChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.badi,
            this.bkodu,
            this.abdkodu,
            this.abdadi});
            this.dataGridView1.Location = new System.Drawing.Point(26, 136);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(741, 212);
            this.dataGridView1.TabIndex = 0;
            // 
            // badi
            // 
            this.badi.DataPropertyName = "badi";
            this.badi.HeaderText = "Bölüm Adı";
            this.badi.Name = "badi";
            this.badi.ReadOnly = true;
            // 
            // bkodu
            // 
            this.bkodu.DataPropertyName = "bkodu";
            this.bkodu.HeaderText = "Bölüm Kodu";
            this.bkodu.Name = "bkodu";
            this.bkodu.ReadOnly = true;
            this.bkodu.Visible = false;
            // 
            // abdkodu
            // 
            this.abdkodu.DataPropertyName = "abdkodu";
            this.abdkodu.HeaderText = "Anabilim Dalı Kodu";
            this.abdkodu.Name = "abdkodu";
            this.abdkodu.ReadOnly = true;
            // 
            // abdadi
            // 
            this.abdadi.DataPropertyName = "abdadi";
            this.abdadi.HeaderText = "Anabilim Dalı Adı";
            this.abdadi.Name = "abdadi";
            this.abdadi.ReadOnly = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 85);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 17);
            this.label5.TabIndex = 3;
            this.label5.Text = "Bölüm Adı";
            // 
            // abdaranan
            // 
            this.abdaranan.BackColor = System.Drawing.Color.White;
            this.abdaranan.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.abdaranan.Location = new System.Drawing.Point(170, 56);
            this.abdaranan.Name = "abdaranan";
            this.abdaranan.Size = new System.Drawing.Size(174, 23);
            this.abdaranan.TabIndex = 2;
            this.abdaranan.TextChanged += new System.EventHandler(this.abdaranan_TextChanged);
            this.abdaranan.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Key_PressHarf);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 17);
            this.label4.TabIndex = 1;
            this.label4.Text = "Anabilim Dalı Adı";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnsil);
            this.groupBox2.Controls.Add(this.btnduzelt);
            this.groupBox2.Controls.Add(this.btnyenikayit);
            this.groupBox2.Controls.Add(this.btniptal);
            this.groupBox2.Controls.Add(this.btnkaydet);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox2.Location = new System.Drawing.Point(674, 131);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(375, 145);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "İşlemler";
            // 
            // btnsil
            // 
            this.btnsil.BackColor = System.Drawing.Color.White;
            this.btnsil.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnsil.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnsil.Location = new System.Drawing.Point(251, 37);
            this.btnsil.Name = "btnsil";
            this.btnsil.Size = new System.Drawing.Size(75, 38);
            this.btnsil.TabIndex = 6;
            this.btnsil.Text = "Sil";
            this.btnsil.UseVisualStyleBackColor = false;
            this.btnsil.Click += new System.EventHandler(this.btnsil_Click);
            // 
            // btnduzelt
            // 
            this.btnduzelt.BackColor = System.Drawing.Color.White;
            this.btnduzelt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnduzelt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnduzelt.Location = new System.Drawing.Point(201, 81);
            this.btnduzelt.Name = "btnduzelt";
            this.btnduzelt.Size = new System.Drawing.Size(125, 37);
            this.btnduzelt.TabIndex = 5;
            this.btnduzelt.Text = "Düzelt";
            this.btnduzelt.UseVisualStyleBackColor = false;
            this.btnduzelt.Click += new System.EventHandler(this.btnduzelt_Click);
            // 
            // btnyenikayit
            // 
            this.btnyenikayit.BackColor = System.Drawing.Color.White;
            this.btnyenikayit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnyenikayit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnyenikayit.Location = new System.Drawing.Point(65, 81);
            this.btnyenikayit.Name = "btnyenikayit";
            this.btnyenikayit.Size = new System.Drawing.Size(125, 37);
            this.btnyenikayit.TabIndex = 4;
            this.btnyenikayit.Text = "Yeni Kayıt";
            this.btnyenikayit.UseVisualStyleBackColor = false;
            this.btnyenikayit.Click += new System.EventHandler(this.btnyenikayit_Click);
            // 
            // btniptal
            // 
            this.btniptal.BackColor = System.Drawing.Color.White;
            this.btniptal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btniptal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btniptal.Location = new System.Drawing.Point(157, 37);
            this.btniptal.Name = "btniptal";
            this.btniptal.Size = new System.Drawing.Size(76, 38);
            this.btniptal.TabIndex = 3;
            this.btniptal.Text = "İptal";
            this.btniptal.UseVisualStyleBackColor = false;
            this.btniptal.Click += new System.EventHandler(this.btniptal_Click);
            // 
            // btnkaydet
            // 
            this.btnkaydet.BackColor = System.Drawing.Color.White;
            this.btnkaydet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnkaydet.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnkaydet.Location = new System.Drawing.Point(65, 37);
            this.btnkaydet.Name = "btnkaydet";
            this.btnkaydet.Size = new System.Drawing.Size(75, 38);
            this.btnkaydet.TabIndex = 2;
            this.btnkaydet.Text = "Kaydet";
            this.btnkaydet.UseVisualStyleBackColor = false;
            this.btnkaydet.Click += new System.EventHandler(this.btnkaydet_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbbolumadi);
            this.groupBox1.Controls.Add(this.tbabdadi);
            this.groupBox1.Controls.Add(this.tbabdkodu);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox1.Location = new System.Drawing.Point(247, 131);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(408, 145);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Anabilim Dalı Tanımları";
            // 
            // cbbolumadi
            // 
            this.cbbolumadi.BackColor = System.Drawing.Color.White;
            this.cbbolumadi.Enabled = false;
            this.cbbolumadi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cbbolumadi.FormattingEnabled = true;
            this.cbbolumadi.Location = new System.Drawing.Point(169, 28);
            this.cbbolumadi.Name = "cbbolumadi";
            this.cbbolumadi.Size = new System.Drawing.Size(153, 24);
            this.cbbolumadi.TabIndex = 6;
            // 
            // tbabdadi
            // 
            this.tbabdadi.BackColor = System.Drawing.Color.White;
            this.tbabdadi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tbabdadi.Location = new System.Drawing.Point(169, 81);
            this.tbabdadi.Name = "tbabdadi";
            this.tbabdadi.ReadOnly = true;
            this.tbabdadi.Size = new System.Drawing.Size(153, 23);
            this.tbabdadi.TabIndex = 5;
            this.tbabdadi.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Key_PressHarf);
            // 
            // tbabdkodu
            // 
            this.tbabdkodu.BackColor = System.Drawing.Color.White;
            this.tbabdkodu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tbabdkodu.Location = new System.Drawing.Point(169, 55);
            this.tbabdkodu.Name = "tbabdkodu";
            this.tbabdkodu.ReadOnly = true;
            this.tbabdkodu.Size = new System.Drawing.Size(153, 23);
            this.tbabdkodu.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(135, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Anabilim Dalı Adı ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Anabilim Dalı Kodu";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bölüm Adı";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bölümTanımlamaToolStripMenuItem,
            this.anabilimTanımlamaToolStripMenuItem,
            this.personelTanımlamaToolStripMenuItem,
            this.izinTanımlamaToolStripMenuItem,
            this.personelGörevSüreleriToolStripMenuItem,
            this.süreliGörevTanımlamalarıToolStripMenuItem,
            this.hakkındaToolStripMenuItem,
            this.çıkışToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1303, 29);
            this.menuStrip1.TabIndex = 11;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // bölümTanımlamaToolStripMenuItem
            // 
            this.bölümTanımlamaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bölümTanımlaToolStripMenuItem});
            this.bölümTanımlamaToolStripMenuItem.Name = "bölümTanımlamaToolStripMenuItem";
            this.bölümTanımlamaToolStripMenuItem.Size = new System.Drawing.Size(161, 25);
            this.bölümTanımlamaToolStripMenuItem.Text = "Bölüm Tanımlama";
            // 
            // bölümTanımlaToolStripMenuItem
            // 
            this.bölümTanımlaToolStripMenuItem.Name = "bölümTanımlaToolStripMenuItem";
            this.bölümTanımlaToolStripMenuItem.Size = new System.Drawing.Size(195, 26);
            this.bölümTanımlaToolStripMenuItem.Text = "Bölüm Tanımla";
            this.bölümTanımlaToolStripMenuItem.Click += new System.EventHandler(this.bölümTanımlaToolStripMenuItem_Click);
            // 
            // anabilimTanımlamaToolStripMenuItem
            // 
            this.anabilimTanımlamaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.anabilimTanımlaToolStripMenuItem});
            this.anabilimTanımlamaToolStripMenuItem.Name = "anabilimTanımlamaToolStripMenuItem";
            this.anabilimTanımlamaToolStripMenuItem.Size = new System.Drawing.Size(181, 25);
            this.anabilimTanımlamaToolStripMenuItem.Text = "Anabilim Tanımlama";
            // 
            // anabilimTanımlaToolStripMenuItem
            // 
            this.anabilimTanımlaToolStripMenuItem.Name = "anabilimTanımlaToolStripMenuItem";
            this.anabilimTanımlaToolStripMenuItem.Size = new System.Drawing.Size(215, 26);
            this.anabilimTanımlaToolStripMenuItem.Text = "Anabilim Tanımla";
            this.anabilimTanımlaToolStripMenuItem.Click += new System.EventHandler(this.anabilimTanımlaToolStripMenuItem_Click);
            // 
            // personelTanımlamaToolStripMenuItem
            // 
            this.personelTanımlamaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.personelTanımlaToolStripMenuItem});
            this.personelTanımlamaToolStripMenuItem.Name = "personelTanımlamaToolStripMenuItem";
            this.personelTanımlamaToolStripMenuItem.Size = new System.Drawing.Size(175, 25);
            this.personelTanımlamaToolStripMenuItem.Text = "Personel Tanımlama";
            // 
            // personelTanımlaToolStripMenuItem
            // 
            this.personelTanımlaToolStripMenuItem.Name = "personelTanımlaToolStripMenuItem";
            this.personelTanımlaToolStripMenuItem.Size = new System.Drawing.Size(209, 26);
            this.personelTanımlaToolStripMenuItem.Text = "Personel Tanımla";
            this.personelTanımlaToolStripMenuItem.Click += new System.EventHandler(this.personelTanımlaToolStripMenuItem_Click);
            // 
            // izinTanımlamaToolStripMenuItem
            // 
            this.izinTanımlamaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.izinTanımlaToolStripMenuItem});
            this.izinTanımlamaToolStripMenuItem.Name = "izinTanımlamaToolStripMenuItem";
            this.izinTanımlamaToolStripMenuItem.Size = new System.Drawing.Size(140, 25);
            this.izinTanımlamaToolStripMenuItem.Text = "İzin Tanımlama";
            // 
            // izinTanımlaToolStripMenuItem
            // 
            this.izinTanımlaToolStripMenuItem.Name = "izinTanımlaToolStripMenuItem";
            this.izinTanımlaToolStripMenuItem.Size = new System.Drawing.Size(174, 26);
            this.izinTanımlaToolStripMenuItem.Text = "İzin Tanımla";
            this.izinTanımlaToolStripMenuItem.Click += new System.EventHandler(this.izinTanımlaToolStripMenuItem_Click);
            // 
            // personelGörevSüreleriToolStripMenuItem
            // 
            this.personelGörevSüreleriToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.personelGörevSüresiTanımlaToolStripMenuItem});
            this.personelGörevSüreleriToolStripMenuItem.Name = "personelGörevSüreleriToolStripMenuItem";
            this.personelGörevSüreleriToolStripMenuItem.Size = new System.Drawing.Size(193, 25);
            this.personelGörevSüreleriToolStripMenuItem.Text = "Personel Görev Süreleri";
            // 
            // personelGörevSüresiTanımlaToolStripMenuItem
            // 
            this.personelGörevSüresiTanımlaToolStripMenuItem.Name = "personelGörevSüresiTanımlaToolStripMenuItem";
            this.personelGörevSüresiTanımlaToolStripMenuItem.Size = new System.Drawing.Size(305, 26);
            this.personelGörevSüresiTanımlaToolStripMenuItem.Text = "Personel Görev Süresi Tanımla";
            this.personelGörevSüresiTanımlaToolStripMenuItem.Click += new System.EventHandler(this.personelGörevSüresiTanımlaToolStripMenuItem_Click);
            // 
            // süreliGörevTanımlamalarıToolStripMenuItem
            // 
            this.süreliGörevTanımlamalarıToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.süreliGörevTanımlaToolStripMenuItem});
            this.süreliGörevTanımlamalarıToolStripMenuItem.Name = "süreliGörevTanımlamalarıToolStripMenuItem";
            this.süreliGörevTanımlamalarıToolStripMenuItem.Size = new System.Drawing.Size(227, 25);
            this.süreliGörevTanımlamalarıToolStripMenuItem.Text = "Süreli Görev Tanımlamaları";
            // 
            // süreliGörevTanımlaToolStripMenuItem
            // 
            this.süreliGörevTanımlaToolStripMenuItem.Name = "süreliGörevTanımlaToolStripMenuItem";
            this.süreliGörevTanımlaToolStripMenuItem.Size = new System.Drawing.Size(236, 26);
            this.süreliGörevTanımlaToolStripMenuItem.Text = "Süreli Görev Tanımla";
            this.süreliGörevTanımlaToolStripMenuItem.Click += new System.EventHandler(this.süreliGörevTanımlaToolStripMenuItem_Click);
            // 
            // hakkındaToolStripMenuItem
            // 
            this.hakkındaToolStripMenuItem.Name = "hakkındaToolStripMenuItem";
            this.hakkındaToolStripMenuItem.Size = new System.Drawing.Size(94, 25);
            this.hakkındaToolStripMenuItem.Text = "Hakkında";
            this.hakkındaToolStripMenuItem.Click += new System.EventHandler(this.hakkındaToolStripMenuItem_Click);
            // 
            // çıkışToolStripMenuItem
            // 
            this.çıkışToolStripMenuItem.Name = "çıkışToolStripMenuItem";
            this.çıkışToolStripMenuItem.Size = new System.Drawing.Size(58, 25);
            this.çıkışToolStripMenuItem.Text = "Çıkış";
            this.çıkışToolStripMenuItem.Click += new System.EventHandler(this.çıkışToolStripMenuItem_Click);
            // 
            // anabilimler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DodgerBlue;
            this.ClientSize = new System.Drawing.Size(1303, 735);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Name = "anabilimler";
            this.Text = "Anabilim Dalı Tanımlama";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.anabilimler_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.ComboBox cbbolumadiaranan;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox abdaranan;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn badi;
        private System.Windows.Forms.DataGridViewTextBoxColumn bkodu;
        private System.Windows.Forms.DataGridViewTextBoxColumn abdkodu;
        private System.Windows.Forms.DataGridViewTextBoxColumn abdadi;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnsil;
        private System.Windows.Forms.Button btnduzelt;
        private System.Windows.Forms.Button btnyenikayit;
        private System.Windows.Forms.Button btniptal;
        private System.Windows.Forms.Button btnkaydet;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbbolumadi;
        private System.Windows.Forms.TextBox tbabdadi;
        private System.Windows.Forms.TextBox tbabdkodu;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem bölümTanımlamaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bölümTanımlaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem anabilimTanımlamaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem anabilimTanımlaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem personelTanımlamaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem personelTanımlaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem izinTanımlamaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem izinTanımlaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem personelGörevSüreleriToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem personelGörevSüresiTanımlaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem süreliGörevTanımlamalarıToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem süreliGörevTanımlaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem çıkışToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hakkındaToolStripMenuItem;
    }
}