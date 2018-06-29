namespace IzinTakipOtomasyonu
{
    partial class ReportPersonelGorevSureleri
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.gorevsureleriBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.vtDataSet1 = new IzinTakipOtomasyonu.vtDataSet1();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.gorevsureleriTableAdapter = new IzinTakipOtomasyonu.vtDataSet1TableAdapters.gorevsureleriTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.gorevsureleriBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vtDataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // gorevsureleriBindingSource
            // 
            this.gorevsureleriBindingSource.DataMember = "gorevsureleri";
            this.gorevsureleriBindingSource.DataSource = this.vtDataSet1;
            // 
            // vtDataSet1
            // 
            this.vtDataSet1.DataSetName = "vtDataSet1";
            this.vtDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.gorevsureleriBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "IzinTakipOtomasyonu.ReportPersonelGorevSureleri.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 12);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(779, 399);
            this.reportViewer1.TabIndex = 0;
            // 
            // gorevsureleriTableAdapter
            // 
            this.gorevsureleriTableAdapter.ClearBeforeFill = true;
            // 
            // ReportPersonelGorevSureleri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(803, 423);
            this.Controls.Add(this.reportViewer1);
            this.Name = "ReportPersonelGorevSureleri";
            this.Text = "ReportPersonelGorevSureleri";
            this.Load += new System.EventHandler(this.ReportPersonelGorevSureleri_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gorevsureleriBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vtDataSet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource gorevsureleriBindingSource;
        private vtDataSet1 vtDataSet1;
        private vtDataSet1TableAdapters.gorevsureleriTableAdapter gorevsureleriTableAdapter;
    }
}