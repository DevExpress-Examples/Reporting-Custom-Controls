using System;
using DevExpress.XtraReports.CustomControls;
using DevExpress.XtraReports.UI;

namespace CustomControlExample.Win {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            ReportDesignTool designTool = new ReportDesignTool(new Report());
            CustomControlToolBoxRegistrator.EnsureSwissQRControl(designTool.DesignRibbonForm.DesignMdiController);
            CustomControlToolBoxRegistrator.EnsureRoundControls(designTool.DesignRibbonForm.DesignMdiController);
            designTool.ShowRibbonDesignerDialog();
        }
    }
}
