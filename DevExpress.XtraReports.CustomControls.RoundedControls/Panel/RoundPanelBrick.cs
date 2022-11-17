using DevExpress.Utils.Serializing;
using DevExpress.XtraPrinting;
using DevExpress.XtraPrinting.BrickExporters;
using System.ComponentModel;

namespace DevExpress.XtraReports.CustomControls.RoundBordersControls {
    [BrickExporter(typeof(RoundPanelBrickExporter))]
    public class RoundPanelBrick : PanelBrick {
        public override string BrickType => nameof(RoundPanelBrick);

        public RoundPanelBrick() { }

        public RoundPanelBrick(IBrickOwner brickOwner) : base(brickOwner) { }

        public RoundPanelBrick(IBrickOwner brickOwner, BrickStyle style) : base(brickOwner, style) { }

        [DefaultValue(20)]
        [XtraSerializableProperty]
        public int BorderCornerRadius { get; set; } = 20;
    }
}
