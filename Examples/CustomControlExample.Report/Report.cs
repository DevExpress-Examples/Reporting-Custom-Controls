using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraReports.CustomControls.SwissQRBill;
using DevExpress.XtraReports.UI;

namespace CustomControlExample {
    public class Report:XtraReport {
        private DevExpress.DataAccess.ObjectBinding.ObjectDataSource objectDataSource1;
        private System.ComponentModel.IContainer components;
        private XRControlStyle Title;
        private XRControlStyle DetailCaption2;
        private XRControlStyle DetailData2;
        private XRControlStyle DetailData3_Odd;
        private XRControlStyle PageInfo;
        private TopMarginBand TopMargin;
        private BottomMarginBand BottomMargin;
        private DetailBand Detail;
        private DetailReportBand DetailReport;
        private GroupHeaderBand GroupHeader1;
        private XRLabel xrLabel2;
        private XRLabel xrLabel1;
        private XRTable table1;
        private XRTableRow tableRow1;
        private XRTableCell tableCell1;
        private XRTableCell tableCell2;
        private XRTableCell tableCell3;
        private XRTableCell tableCell4;
        private DetailBand Detail1;
        private XRTable table2;
        private XRTableRow tableRow2;
        private XRTableCell tableCell5;
        private XRTableCell tableCell6;
        private XRTableCell tableCell7;
        private XRTableCell tableCell8;
        private GroupFooterBand GroupFooter1;
        private DevExpress.XtraReports.CustomControls.SwissQRBill.XRSwissQRBill xrSwissQRBill1;

        public Report() {
            InitializeComponent();
            //xrSwissQRBill1.CreditorIBAN = "CHXXXXXXXXXXXXXXXXXXA";
            //xrSwissQRBill1.Amount = 287.30d;
            //xrSwissQRBill1.Currency = DevExpress.XtraReports.CustomControls.SwissQRBill.Currency.EUR;
            //xrSwissQRBill1.Reference = "RFXXXXXXXXXXXXXX";
            //xrSwissQRBill1.AdditionalInformation = "Rechnungsnr. 10978 / Auftragsrnr. 3987";
            //xrSwissQRBill1.CreditorInformation.CountryCode = "CH";
            //xrSwissQRBill1.CreditorInformation.Name = "Schreinerei Habegger & Sohne";
            //xrSwissQRBill1.CreditorInformation.BuildingNumber = 138;
            //xrSwissQRBill1.CreditorInformation.PostalCode = 8045;
            //xrSwissQRBill1.CreditorInformation.Street = "Uetlibergstrasse";
            //xrSwissQRBill1.CreditorInformation.Town = "Zuric";

            //xrSwissQRBill1.DebtorInformation.CountryCode = "CH";
            //xrSwissQRBill1.DebtorInformation.Name = "Simon Glarner";
            //xrSwissQRBill1.DebtorInformation.BuildingNumber = 55;
            //xrSwissQRBill1.DebtorInformation.PostalCode = 8184;
            //xrSwissQRBill1.DebtorInformation.Street = "Bachliwis";
            //xrSwissQRBill1.DebtorInformation.Town = "Bachenbulach";

            xrSwissQRBill1.StringData = "SPC\r\n0200\r\n1\r\nCHXXXXXXXXXXXXXXXXXXA\r\nS\r\nSchreinerei Habegger & Sohne\r\nUetlibergstrasse\r\n138\r\n8045\r\nZuric\r\nCH\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n287.30\r\nEUR\r\nS\r\nSimon Glarner\r\nBachliwis\r\n55\r\n8184\r\nBachenbulach\r\nCH\r\nSCOR\r\nRFXXXXXXXXXXXXXX\r\nRechnungsnr. 10978 / Auftragsrnr. 3987\r\nEPD\r\n";

        }

        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.Title = new DevExpress.XtraReports.UI.XRControlStyle();
            this.DetailCaption2 = new DevExpress.XtraReports.UI.XRControlStyle();
            this.DetailData2 = new DevExpress.XtraReports.UI.XRControlStyle();
            this.DetailData3_Odd = new DevExpress.XtraReports.UI.XRControlStyle();
            this.PageInfo = new DevExpress.XtraReports.UI.XRControlStyle();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.DetailReport = new DevExpress.XtraReports.UI.DetailReportBand();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.table1 = new DevExpress.XtraReports.UI.XRTable();
            this.tableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
            this.tableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell4 = new DevExpress.XtraReports.UI.XRTableCell();
            this.Detail1 = new DevExpress.XtraReports.UI.DetailBand();
            this.table2 = new DevExpress.XtraReports.UI.XRTable();
            this.tableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
            this.tableCell5 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell6 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell7 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell8 = new DevExpress.XtraReports.UI.XRTableCell();
            this.GroupFooter1 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.xrSwissQRBill1 = new DevExpress.XtraReports.CustomControls.SwissQRBill.XRSwissQRBill();
            this.objectDataSource1 = new DevExpress.DataAccess.ObjectBinding.ObjectDataSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.table1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.table2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.objectDataSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Title
            // 
            this.Title.BackColor = System.Drawing.Color.Transparent;
            this.Title.BorderColor = System.Drawing.Color.Black;
            this.Title.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Title.BorderWidth = 1F;
            this.Title.Font = new System.Drawing.Font("Arial", 14.25F);
            this.Title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(70)))), ((int)(((byte)(80)))));
            this.Title.Name = "Title";
            // 
            // DetailCaption2
            // 
            this.DetailCaption2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(231)))), ((int)(((byte)(177)))));
            this.DetailCaption2.BorderColor = System.Drawing.Color.White;
            this.DetailCaption2.Borders = DevExpress.XtraPrinting.BorderSide.Left;
            this.DetailCaption2.BorderWidth = 2F;
            this.DetailCaption2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.DetailCaption2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(70)))), ((int)(((byte)(80)))));
            this.DetailCaption2.Name = "DetailCaption2";
            this.DetailCaption2.Padding = new DevExpress.XtraPrinting.PaddingInfo(15, 15, 0, 0, 254F);
            this.DetailCaption2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // DetailData2
            // 
            this.DetailData2.BorderColor = System.Drawing.Color.Transparent;
            this.DetailData2.Borders = DevExpress.XtraPrinting.BorderSide.Left;
            this.DetailData2.BorderWidth = 2F;
            this.DetailData2.Font = new System.Drawing.Font("Arial", 8.25F);
            this.DetailData2.ForeColor = System.Drawing.Color.Black;
            this.DetailData2.Name = "DetailData2";
            this.DetailData2.Padding = new DevExpress.XtraPrinting.PaddingInfo(15, 15, 0, 0, 254F);
            this.DetailData2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // DetailData3_Odd
            // 
            this.DetailData3_Odd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(245)))), ((int)(((byte)(248)))));
            this.DetailData3_Odd.BorderColor = System.Drawing.Color.Transparent;
            this.DetailData3_Odd.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.DetailData3_Odd.BorderWidth = 1F;
            this.DetailData3_Odd.Font = new System.Drawing.Font("Arial", 8.25F);
            this.DetailData3_Odd.ForeColor = System.Drawing.Color.Black;
            this.DetailData3_Odd.Name = "DetailData3_Odd";
            this.DetailData3_Odd.Padding = new DevExpress.XtraPrinting.PaddingInfo(15, 15, 0, 0, 254F);
            this.DetailData3_Odd.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // PageInfo
            // 
            this.PageInfo.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.PageInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(70)))), ((int)(((byte)(80)))));
            this.PageInfo.Name = "PageInfo";
            this.PageInfo.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            // 
            // TopMargin
            // 
            this.TopMargin.Dpi = 254F;
            this.TopMargin.HeightF = 132.08F;
            this.TopMargin.Name = "TopMargin";
            // 
            // BottomMargin
            // 
            this.BottomMargin.Dpi = 254F;
            this.BottomMargin.HeightF = 0F;
            this.BottomMargin.Name = "BottomMargin";
            // 
            // Detail
            // 
            this.Detail.Dpi = 254F;
            this.Detail.HeightF = 0F;
            this.Detail.HierarchyPrintOptions.Indent = 50.8F;
            this.Detail.KeepTogether = true;
            this.Detail.Name = "Detail";
            // 
            // DetailReport
            // 
            this.DetailReport.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.GroupHeader1,
            this.Detail1,
            this.GroupFooter1});
            this.DetailReport.DataMember = "InvoiceItems";
            this.DetailReport.DataSource = this.objectDataSource1;
            this.DetailReport.Dpi = 254F;
            this.DetailReport.Level = 0;
            this.DetailReport.Name = "DetailReport";
            this.DetailReport.PageBreak = DevExpress.XtraReports.UI.PageBreak.AfterBand;
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel2,
            this.xrLabel1,
            this.table1});
            this.GroupHeader1.Dpi = 254F;
            this.GroupHeader1.GroupUnion = DevExpress.XtraReports.UI.GroupUnion.WithFirstDetail;
            this.GroupHeader1.HeightF = 200.7659F;
            this.GroupHeader1.Name = "GroupHeader1";
            // 
            // xrLabel2
            // 
            this.xrLabel2.Dpi = 254F;
            this.xrLabel2.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[OrderNumber]")});
            this.xrLabel2.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Bold);
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(485F, 0F);
            this.xrLabel2.Multiline = true;
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(709.0834F, 76.72921F);
            this.xrLabel2.StylePriority.UseFont = false;
            this.xrLabel2.Text = "xrLabel2";
            // 
            // xrLabel1
            // 
            this.xrLabel1.Dpi = 254F;
            this.xrLabel1.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Bold);
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(50F, 0F);
            this.xrLabel1.Multiline = true;
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(433.9166F, 76.72921F);
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.Text = "Invoice Number:";
            // 
            // table1
            // 
            this.table1.Dpi = 254F;
            this.table1.LocationFloat = new DevExpress.Utils.PointFloat(50.00002F, 129.6459F);
            this.table1.Name = "table1";
            this.table1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.tableRow1});
            this.table1.SizeF = new System.Drawing.SizeF(2000.161F, 71.12003F);
            // 
            // tableRow1
            // 
            this.tableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.tableCell1,
            this.tableCell2,
            this.tableCell3,
            this.tableCell4});
            this.tableRow1.Dpi = 254F;
            this.tableRow1.Name = "tableRow1";
            this.tableRow1.Weight = 1D;
            // 
            // tableCell1
            // 
            this.tableCell1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.tableCell1.Dpi = 254F;
            this.tableCell1.Name = "tableCell1";
            this.tableCell1.StyleName = "DetailCaption2";
            this.tableCell1.StylePriority.UseBorders = false;
            this.tableCell1.StylePriority.UseTextAlignment = false;
            this.tableCell1.Text = "Product Code";
            this.tableCell1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.tableCell1.Weight = 0.31244154710036059D;
            // 
            // tableCell2
            // 
            this.tableCell2.Dpi = 254F;
            this.tableCell2.Name = "tableCell2";
            this.tableCell2.StyleName = "DetailCaption2";
            this.tableCell2.StylePriority.UseTextAlignment = false;
            this.tableCell2.Text = "Amount";
            this.tableCell2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.tableCell2.Weight = 0.20091390756460337D;
            // 
            // tableCell3
            // 
            this.tableCell3.Dpi = 254F;
            this.tableCell3.Name = "tableCell3";
            this.tableCell3.StyleName = "DetailCaption2";
            this.tableCell3.StylePriority.UseTextAlignment = false;
            this.tableCell3.Text = "Count";
            this.tableCell3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.tableCell3.Weight = 0.16522741464468149D;
            // 
            // tableCell4
            // 
            this.tableCell4.Dpi = 254F;
            this.tableCell4.Name = "tableCell4";
            this.tableCell4.StyleName = "DetailCaption2";
            this.tableCell4.Text = "Product Name";
            this.tableCell4.Weight = 0.32141716590294472D;
            // 
            // Detail1
            // 
            this.Detail1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.table2});
            this.Detail1.Dpi = 254F;
            this.Detail1.HeightF = 63.5F;
            this.Detail1.HierarchyPrintOptions.Indent = 50.8F;
            this.Detail1.Name = "Detail1";
            // 
            // table2
            // 
            this.table2.Dpi = 254F;
            this.table2.LocationFloat = new DevExpress.Utils.PointFloat(50.00002F, 0F);
            this.table2.Name = "table2";
            this.table2.OddStyleName = "DetailData3_Odd";
            this.table2.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.tableRow2});
            this.table2.SizeF = new System.Drawing.SizeF(2000.161F, 63.5F);
            // 
            // tableRow2
            // 
            this.tableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.tableCell5,
            this.tableCell6,
            this.tableCell7,
            this.tableCell8});
            this.tableRow2.Dpi = 254F;
            this.tableRow2.Name = "tableRow2";
            this.tableRow2.Weight = 11.5D;
            // 
            // tableCell5
            // 
            this.tableCell5.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.tableCell5.Dpi = 254F;
            this.tableCell5.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[ProductCode]")});
            this.tableCell5.Name = "tableCell5";
            this.tableCell5.StyleName = "DetailData2";
            this.tableCell5.StylePriority.UseBorders = false;
            this.tableCell5.StylePriority.UseTextAlignment = false;
            this.tableCell5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.tableCell5.Weight = 0.31244154710036059D;
            // 
            // tableCell6
            // 
            this.tableCell6.Dpi = 254F;
            this.tableCell6.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Amount]")});
            this.tableCell6.Name = "tableCell6";
            this.tableCell6.StyleName = "DetailData2";
            this.tableCell6.StylePriority.UseTextAlignment = false;
            this.tableCell6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.tableCell6.Weight = 0.20091390756460337D;
            // 
            // tableCell7
            // 
            this.tableCell7.Dpi = 254F;
            this.tableCell7.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Count]")});
            this.tableCell7.Name = "tableCell7";
            this.tableCell7.StyleName = "DetailData2";
            this.tableCell7.StylePriority.UseTextAlignment = false;
            this.tableCell7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.tableCell7.Weight = 0.16522741464468149D;
            // 
            // tableCell8
            // 
            this.tableCell8.Dpi = 254F;
            this.tableCell8.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[ProductName]")});
            this.tableCell8.Name = "tableCell8";
            this.tableCell8.StyleName = "DetailData2";
            this.tableCell8.Weight = 0.3090632776028881D;
            // 
            // GroupFooter1
            // 
            this.GroupFooter1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrSwissQRBill1});
            this.GroupFooter1.Dpi = 254F;
            this.GroupFooter1.HeightF = 1100F;
            this.GroupFooter1.Name = "GroupFooter1";
            this.GroupFooter1.PrintAtBottom = true;
            // 
            // xrSwissQRBill1
            // 
            this.xrSwissQRBill1.CreditorIBAN = "CHXXXXXXXXXXXXXXXXXXX";
            this.xrSwissQRBill1.Dpi = 254F;
            //this.xrSwissQRBill1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            //new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "StringData", "[BillItemStringInfo]")});
            this.xrSwissQRBill1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrSwissQRBill1.Name = "xrSwissQRBill1";
            this.xrSwissQRBill1.Reference = "RFXXXXXXXXXXXXXX";
            this.xrSwissQRBill1.SizeF = new System.Drawing.SizeF(2100F, 1100F);
            // 
            // objectDataSource1
            // 
            this.objectDataSource1.DataMember = "GetOrders";
            this.objectDataSource1.DataSource = typeof(CustomControlExample.DataSource);
            this.objectDataSource1.Name = "objectDataSource1";
            // 
            // Report
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.TopMargin,
            this.BottomMargin,
            this.Detail,
            this.DetailReport});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.objectDataSource1});
            this.DataSource = this.objectDataSource1;
            this.Dpi = 254F;
            this.Font = new System.Drawing.Font("Arial", 9.75F);
            this.Margins = new System.Drawing.Printing.Margins(0, 0, 132, 0);
            this.PageHeight = 2970;
            this.PageWidth = 2100;
            this.PaperKind = DevExpress.Drawing.Printing.DXPaperKind.A4;
            this.ReportUnit = DevExpress.XtraReports.UI.ReportUnit.TenthsOfAMillimeter;
            this.ShowPrintMarginsWarning = false;
            this.SnapGridSize = 25F;
            this.StyleSheet.AddRange(new DevExpress.XtraReports.UI.XRControlStyle[] {
            this.Title,
            this.DetailCaption2,
            this.DetailData2,
            this.DetailData3_Odd,
            this.PageInfo});
            this.Version = "20.1";
            ((System.ComponentModel.ISupportInitialize)(this.table1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.table2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.objectDataSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
    }
}
