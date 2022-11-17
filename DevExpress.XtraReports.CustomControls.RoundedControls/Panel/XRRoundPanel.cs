using DevExpress.Utils.Design;
using DevExpress.Utils.Serializing;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.Localization;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.UserDesigner;
using System.ComponentModel;

namespace DevExpress.XtraReports.CustomControls.RoundBordersControls {
    [ToolboxItem(true)]
    [ToolboxSvgImage("DevExpress.XtraReports.CustomControls.RoundedControls.Resources.XRPanel.svg,DevExpress.XtraReports.CustomControls.RoundedControls")]
    [XRToolboxSubcategory(0, 5)]
    public class XRRoundPanel : XRPanel {
        int borderCornerRadius = 20;

        [DefaultValue(20)]
        [XtraSerializableProperty]
        [SRCategory(ReportStringId.CatAppearance)]
        public int BorderCornerRadius {
            get {
                return borderCornerRadius;
            }
            set {
                if(value <= (HeightF / 2 - BorderWidth) || IsDeserializing) {
                    borderCornerRadius = value;
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

        public XRRoundPanel() {
            BorderWidth = 2;
            Borders = BorderSide.All;
        }

        protected override VisualBrick CreateBrick(VisualBrick[] childrenBricks) {
            var panelBrick = new RoundPanelBrick(this);
            foreach(var item in childrenBricks)
                panelBrick.Bricks.Add(item);
            return panelBrick;
        }

        protected override void PutStateToBrick(VisualBrick brick, PrintingSystemBase ps) {
            var roundedBrick = (RoundPanelBrick)brick;
            roundedBrick.BorderCornerRadius = BorderCornerRadius;
            base.PutStateToBrick(brick, ps);
        }        
    }
}
