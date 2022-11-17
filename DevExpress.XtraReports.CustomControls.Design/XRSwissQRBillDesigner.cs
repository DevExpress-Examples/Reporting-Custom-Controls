using System.ComponentModel.Design;
using DevExpress.XtraReports.Design;
using System.Windows.Forms.Design;

namespace DevExpress.XtraReports.CustomControls.Design.SwissQRBill {
    public class XRSwissQRBillDesigner : XRControlDesigner {
        protected override SelectionRules GetSelectionRulesCore() {
            return SelectionRules.Moveable;
        }
        protected override void RegisterActionLists(DesignerActionListCollection list) {
            list.Add(new XRSwissQRBillDesignerActionList(this));
        }
    }
    public class _XRSwissQRBillDesigner : XRSwissQRBillDesigner {
    }
}
