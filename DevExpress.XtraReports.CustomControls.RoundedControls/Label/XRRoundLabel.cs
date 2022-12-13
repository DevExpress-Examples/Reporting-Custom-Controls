using DevExpress.Utils.Design;
using DevExpress.Utils.Serializing;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.Localization;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.UserDesigner;
using System;
using System.ComponentModel;

namespace DevExpress.XtraReports.CustomControls.RoundBordersControls {
    [ToolboxItem(true)]
    [XRToolboxSubcategory(0, 1)]
    [DefaultBindableProperty(nameof(Text))]
    [ToolboxSvgImage("DevExpress.XtraReports.CustomControls.RoundedControls.Resources.XRLabel.svg,DevExpress.XtraReports.CustomControls.RoundedControls")]
    public class XRRoundLabel : XRLabel {
        int borderCornerRadius = 8;

        [XtraSerializableProperty]
        [DefaultValue(8)]
        [SRCategory(ReportStringId.CatAppearance)]
        public int BorderCornerRadius {
            get {
                return borderCornerRadius;
            }
            set {
                float maxRadius = HeightF / 2 - BorderWidth;
                if(value <= maxRadius || IsDeserializing) {
                    borderCornerRadius = value;
                } else {
                    throw new Exception($"Value should be between 0-{(int)maxRadius}");
                }
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [XtraSerializableProperty(XtraSerializationVisibility.Hidden)]
        public override BorderSide Borders {
            get { return BorderSide.All; }
            set { base.Borders = value; }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [XtraSerializableProperty(XtraSerializationVisibility.Hidden)]
        public override BorderDashStyle BorderDashStyle {
            get { return BorderDashStyle.Solid; }
            set { }
        }

        public XRRoundLabel() {
            BorderWidth = 2;
            TextAlignment = TextAlignment.MiddleCenter;
            Borders = BorderSide.All;
        }

        protected override VisualBrick CreateBrick(VisualBrick[] childrenBricks) {
            return new RoundLabelBrick(this, null);
        }

        protected override void PutStateToBrick(VisualBrick brick, PrintingSystemBase ps) {
            var roundedBrick = (RoundLabelBrick)brick;
            roundedBrick.BorderCornerRadius = BorderCornerRadius;
            base.PutStateToBrick(brick, ps);
        }        
    }
}
