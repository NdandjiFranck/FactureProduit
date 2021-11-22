using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FactureProduit.Winforms
{
    public partial class FrmPreview : Form
    {
        private object reportPath { get; set; }
        private object items { get; set; }
        public FrmPreview()
        {
            InitializeComponent();
        }

        public FrmPreview(string reportPath, object items) : this()
        {
            this.reportPath = reportPath;
            this.items = items;
        }
        private void FrmPreview_Load(object sender, EventArgs e)
        {
            this.reportViewer1.LocalReport.ReportPath = "RptProductList.rdlc";
            this.reportViewer1.LocalReport.DataSources.Add
            (
                new Microsoft.Reporting.WinForms.ReportDataSource
                (
                    "DataSet1",
                    items
                )
            );
            List<RptProductList> produits = new List<RptProductList>
            {
                new RptProductList("", "", "", "",null, File.ReadAllBytes("Logo.jpg")),
                new RptProductList("001", "19", "150", "Mambo",File.ReadAllBytes("Mambo.jpeg"), null),
                new RptProductList("002", "19", "1000", "Biscuit", File.ReadAllBytes("Biscuit.jpg"), null) 
            };
            this.reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
            this.reportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.Percent;
            this.reportViewer1.ZoomPercent = 100;
            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
