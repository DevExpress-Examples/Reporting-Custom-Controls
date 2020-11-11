using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraReports.CustomControls;
using DevExpress.XtraReports.CustomControls.SwissQRBill;
using DevExpress.XtraReports.UI;

namespace SwissQRBillExample {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            ReportDesignTool designTool = new ReportDesignTool(new Report());
            CustomControlToolBoxRegistrator.AddSwissQRControlToToolBox(designTool.DesignRibbonForm.DesignMdiController);
            designTool.ShowRibbonDesignerDialog();
        }
    }
}
