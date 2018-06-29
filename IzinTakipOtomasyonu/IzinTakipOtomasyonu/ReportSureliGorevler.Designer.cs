namespace IzinTakipOtomasyonu
{
    partial class ReportSureliGorevler
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.vtDataSet = new IzinTakipOtomasyonu.vtDataSet();
            this.sureligorevlerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sureligorevlerTableAdapter = new IzinTakipOtomasyonu.vtDataSetTableAdapters.sureligorevlerTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.vtDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sureligorevlerBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.sureligorevlerBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "IzinTakipOtomasyonu.ReportSureliGorevler.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 54);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(718, 351);
            this.reportViewer1.TabIndex = 0;
            // 
            // vtDataSet
            // 
            this.vtDataSet.DataSetName = "vtDataSet";
            this.vtDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sureligorevlerBindingSource
            // 
            this.sureligorevlerBindingSource.DataMember = "sureligorevler";
            this.sureligorevlerBindingSource.DataSource = this.vtDataSet;
            // 
            // sureligorevlerTableAdapter
            // 
            this.sureligorevlerTableAdapter.ClearBeforeFill = true;
            // 
            // ReportSureliGorevler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 417);
            this.Controls.Add(this.reportViewer1);
            this.Name = "ReportSureliGorevler";
            this.Text = "ReportSureliGorevler";
            this.Load += new System.EventHandler(this.ReportSureliGorevler_Load);
            ((System.ComponentModel.ISupportInitialize)(this.vtDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sureligorevlerBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource sureligorevlerBindingSource;
        private vtDataSet vtDataSet;
        private vtDataSetTableAdapters.sureligorevlerTableAdapter sureligorevlerTableAdapter;
    }
}