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
    public partial class ReportSureliGorevler : Form
    {
        public ReportSureliGorevler()
        {
            InitializeComponent();
        }

        private void ReportSureliGorevler_Load(object sender, EventArgs e)
        {
            ReportDataSource rds = new ReportDataSource("DataSet1", sureligorevtanimla.ds.Tables["gorevler"]);
            ReportDataSource rds1 = new ReportDataSource("DataSet2", sureligorevtanimla.ds.Tables["gorevler"]);

            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(rds);
            this.reportViewer1.LocalReport.DataSources.Add(rds1);
            this.reportViewer1.LocalReport.Refresh();
            this.reportViewer1.RefreshReport();
        }
    }
}
