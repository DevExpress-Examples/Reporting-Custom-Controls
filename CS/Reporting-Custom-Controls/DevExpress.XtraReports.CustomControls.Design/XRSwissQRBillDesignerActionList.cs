using System.ComponentModel;
using System.Drawing.Design;
using System.ComponentModel.Design;
using DevExpress.XtraReports.Design;
using DevExpress.XtraReports.Design.Expressions;
using DevExpress.XtraReports.CustomControls.SwissQRBill;

namespace DevExpress.XtraReports.CustomControls.Design.SwissQRBill {
    public class XRSwissQRBillDesignerActionList : XRControlBaseDesignerActionList {
        public string StringData {
            get { return ((XRSwissQRBill)Component).StringData; }
            set { SetPropertyValue(nameof(XRSwissQRBill.StringData), value); }
        }

        //public DesignBinding ImageSourceBinding {
        //    get { return ControlDesigner.GetDesignBinding(nameof(CustomQRBillControl.StringData)); }
        //    set { ControlDesigner.SetBinding(nameof(CustomQRBillControl.StringData), value); }
        //}
        [Editor(typeof(ExpressionValueEditor), typeof(UITypeEditor))]
        [AdditionalEditor(typeof(PopupExpressionValueEditor))]
        [TypeConverter(typeof(ExpressionPropertyTypeConverter))]
        public string StringDataExpression {
            get { return GetExpression(nameof(XRSwissQRBill.StringData)); }
            set { SetExpression(nameof(XRSwissQRBill.StringData), value); }
        }

        public XRSwissQRBillDesignerActionList(XRControlDesigner designer) : base(designer) {
        }

        protected override void FillActionItemCollection(DesignerActionItemCollection actionItems) {
            AddPropertyItem(actionItems, nameof(StringData), nameof(XRSwissQRBill.StringData));
            DesignerActionPropertyItem item;
            if(TryCreatePropertyItem(nameof(StringDataExpression), string.Empty, out item))
                actionItems.Add(item);
        }
    }
}
