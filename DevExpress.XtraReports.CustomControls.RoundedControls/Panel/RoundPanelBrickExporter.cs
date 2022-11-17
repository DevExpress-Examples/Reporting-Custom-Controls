using DevExpress.Drawing;
using DevExpress.XtraPrinting;
using DevExpress.XtraPrinting.BrickExporters;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace DevExpress.XtraReports.CustomControls.RoundBordersControls {
    public class RoundPanelBrickExporter : PanelBrickExporter {
        RoundPanelBrick RoundedBrick { get { return Brick as RoundPanelBrick; } }

        protected override void DrawBackground(IGraphics gr, RectangleF rect) {
            if(RoundedBrick.BorderCornerRadius > 0) {
                DXSmoothingMode oldSmoothingMode = gr.SmoothingMode;
                try {
                    gr.SmoothingMode = DXSmoothingMode.AntiAlias;
                    RoundedBorderPaintHelper.DrawRoundedBackGround(gr, rect, Style, BrickPaint, RoundedBrick.BorderCornerRadius);
                    RoundedBorderPaintHelper.DrawRoundedBorders(gr, rect, Style, BrickPaint, RoundedBrick.BorderCornerRadius);
                } finally {
                    gr.SmoothingMode = oldSmoothingMode;
                }
                return;
            }
            base.DrawBackground(gr, rect);
        }
    }
}
