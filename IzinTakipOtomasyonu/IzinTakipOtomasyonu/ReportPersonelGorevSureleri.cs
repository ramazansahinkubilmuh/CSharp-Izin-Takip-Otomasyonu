using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace IzinTakipOtomasyonu
{
    public partial class ReportPersonelGorevSureleri : Form
    {
        public ReportPersonelGorevSureleri()
        {
            InitializeComponent();
        }

        private void ReportPersonelGorevSureleri_Load(object sender, EventArgs e)
        {
            ReportDataSource rds = new ReportDataSource("DataSet1", gorevtanimla.ds.Tables["gorevler"]);

            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(rds);
            this.reportViewer1.LocalReport.Refresh();
            this.reportViewer1.RefreshReport();
        }
    }
}
