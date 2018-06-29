namespace IzinTakipOtomasyonu
{
    partial class ReportIzinler
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
            this.izinlerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.vtDataSet2 = new IzinTakipOtomasyonu.vtDataSet2();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.izinlerTableAdapter = new IzinTakipOtomasyonu.vtDataSet2TableAdapters.izinlerTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.izinlerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vtDataSet2)).BeginInit();
            this.SuspendLayout();
            // 
            // izinlerBindingSource
            // 
            this.izinlerBindingSource.DataMember = "izinler";
            this.izinlerBindingSource.DataSource = this.vtDataSet2;
            // 
            // vtDataSet2
            // 
            this.vtDataSet2.DataSetName = "vtDataSet2";
            this.vtDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.izinlerBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "IzinTakipOtomasyonu.ReportIzinler.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 12);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(867, 419);
            this.reportViewer1.TabIndex = 0;
            // 
            // izinlerTableAdapter
            // 
            this.izinlerTableAdapter.ClearBeforeFill = true;
            // 
            // ReportIzinler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(891, 443);
            this.Controls.Add(this.reportViewer1);
            this.Name = "ReportIzinler";
            this.Text = "ReportIzinler";
            this.Load += new System.EventHandler(this.ReportIzinler_Load);
            ((System.ComponentModel.ISupportInitialize)(this.izinlerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vtDataSet2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource izinlerBindingSource;
        private vtDataSet2 vtDataSet2;
        private vtDataSet2TableAdapters.izinlerTableAdapter izinlerTableAdapter;
    }
}