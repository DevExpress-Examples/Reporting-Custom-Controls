using DevExpress.Utils.Serializing;
using DevExpress.XtraPrinting;
using DevExpress.XtraPrinting.BrickExporters;
using System.ComponentModel;

namespace DevExpress.XtraReports.CustomControls.RoundBordersControls {
    [BrickExporter(typeof(RoundLabelBrickExporter))]
    public class RoundLabelBrick : LabelBrick {
        public override string BrickType => nameof(RoundLabelBrick);

        public RoundLabelBrick() { }

        public RoundLabelBrick(IBrickOwner brickOwner) : base(brickOwner) { }

        public RoundLabelBrick(IBrickOwner brickOwner, BrickStyle style) : base(brickOwner, style) { }

        [DefaultValue(8)]
        [XtraSerializableProperty]
        public int BorderCornerRadius { get; set; } = 8;
    }
}
