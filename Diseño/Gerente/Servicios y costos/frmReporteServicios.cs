﻿using System;
using Logica;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Spa
{
    public partial class frmReporteServicios : Form
    {
        public frmReporteServicios()
        {
            InitializeComponent();
            dpDesde.Value = DateTime.Today;
            dpHasta.Value = DateTime.Today;
        }

        private void LoadBestProductsReport(DateTime startDate, DateTime endDate)
        {
            var salesOrderModel = new SalesReportServicios();
            salesOrderModel.GetBestSellingProductsReport(startDate, endDate);
            SalesReportServiciosBindingSource.DataSource = salesOrderModel;
           ServiciosVentasBindingSource.DataSource = salesOrderModel.VentasServicios;
            this.reportViewer1.RefreshReport();
            reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
            reportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
            
        }

        private void btnHoy_Click(object sender, EventArgs e)
        {
            var fromDate = DateTime.Today;
            var toDate = DateTime.Now;
            LoadBestProductsReport(fromDate, toDate);
        }

        private void frmReporteServicios_Load(object sender, EventArgs e)
        {

        }

        private void btn7dias_Click(object sender, EventArgs e)
        {
            var fromDate = DateTime.Today.AddDays(-7);
            var toDate = DateTime.Now;
            LoadBestProductsReport(fromDate, toDate);
        }

        private void btnMes_Click(object sender, EventArgs e)
        {
            var fromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            var toDate = DateTime.Now;
            LoadBestProductsReport(fromDate, toDate);
        }

        private void btn30dias_Click(object sender, EventArgs e)
        {
            var fromDate = DateTime.Today.AddDays(-30);
            var toDate = DateTime.Now;
            LoadBestProductsReport(fromDate, toDate);
        }

        private void btnAño_Click(object sender, EventArgs e)
        {
            var fromDate = new DateTime(DateTime.Now.Year, 1, 1);
            var toDate = DateTime.Now;
            LoadBestProductsReport(fromDate, toDate);
        }

        private void btnAplicar_Click(object sender, EventArgs e)
        {
            var fromDate = dpDesde.Value;
            var toDate = dpHasta.Value;
            LoadBestProductsReport(fromDate, new DateTime(toDate.Year, toDate.Month, toDate.Day, 23, 59, 59));
        }
    }
}
