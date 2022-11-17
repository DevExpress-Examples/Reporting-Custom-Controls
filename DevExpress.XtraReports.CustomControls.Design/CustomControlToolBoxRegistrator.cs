using System.Drawing.Design;
using DevExpress.XtraReports.CustomControls.RoundBordersControls;
using DevExpress.XtraReports.CustomControls.SwissQRBill;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.UserDesigner;

namespace DevExpress.XtraReports.CustomControls {
    public static class CustomControlToolBoxRegistrator {
        public static void EnsureSwissQRControl(XRDesignMdiController designMdiController) {
            SwissQRBillCustomControl.EnsureCustomBrick();
            AddSwissQRControlToToolBox(designMdiController);
        }

        public static void EnsureRoundControls(XRDesignMdiController designMdiController) {
            RoundedCustomControl.EnsureCustomBrick();
            AddRoundedLabelToToolBox(designMdiController);
            AddRoundedPanelToToolBox(designMdiController);
        }

        public static void AddRoundedLabelToToolBox(XRDesignMdiController designMdiController) {
            AddControlToToolBox<XRRoundLabel>(designMdiController, "Rounded Label");
        }

        public static void AddRoundedPanelToToolBox(XRDesignMdiController designMdiController) {
            AddControlToToolBox<XRRoundPanel>(designMdiController, "Rounded Panel");
        }

        public static void AddSwissQRControlToToolBox(XRDesignMdiController designMdiController) {
            AddControlToToolBox<XRSwissQRBill>(designMdiController, "Swiss QR Bill");
        }

        static void AddControlToToolBox<TControl>(XRDesignMdiController designMdiController, string displayName) where TControl : XRControl {
            designMdiController.DesignPanelLoaded += (s, e) => {
                IToolboxService toolboxService = (IToolboxService)e.DesignerHost.GetService(typeof(IToolboxService));
                var toolboxItem = new ToolboxItem(typeof(TControl)) { DisplayName = displayName };
                toolboxService.AddToolboxItem(toolboxItem);
            };
        }
    }
}
