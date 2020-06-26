using DevExpress.Utils.Serializing;
using DevExpress.XtraReports.UI;
using System.ComponentModel;

namespace DevExpress.XtraReports.CustomControls.SwissQRBill {
    [Description("Swiss QR Bill Scripts Description"),
    DisplayName("Swiss QR Bill Scripts"),
    TypeConverter(typeof(SwissQRBillScriptsTypeConverter))]
    public class XRSwissQRBillScripts : TruncatedControlScripts {
        [Browsable(false),
        EditorBrowsable(EditorBrowsableState.Never),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),
        XtraSerializableProperty(XtraSerializationVisibility.Hidden)]
        public override string OnSizeChanged { get { return sizeChanged; } set { } }

        public XRSwissQRBillScripts(XRControl control)
            : base(control) {
        }
    }
}
