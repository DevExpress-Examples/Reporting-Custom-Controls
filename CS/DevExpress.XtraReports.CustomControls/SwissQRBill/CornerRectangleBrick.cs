using DevExpress.XtraPrinting;
using DevExpress.XtraPrinting.BrickExporters;
using System.Drawing;

namespace DevExpress.XtraReports.CustomControls.SwissQRBill {
    [BrickExporter(typeof(CornerRectangleBrickExporter))]
    public class CornerRectangleBrick : VisualBrick {
        public override string BrickType => nameof(CornerRectangleBrick); 
    }

    public class CornerRectangleBrickExporter : VisualBrickExporter {
        public override void Draw(IGraphics gr, RectangleF rect, RectangleF parentRect) {
            DrawCornedRectangle(gr, rect);
        }

        public void DrawCornedRectangle(IGraphics gr, RectangleF rect) {
            float markSize = GraphicsUnitConverter.Convert(Constants.CornerMarkSize, GraphicsDpi.Millimeter, GraphicsDpi.UnitToDpi(gr.PageUnit));
            float markThickness = GraphicsUnitConverter.Convert(Constants.CornerMarkThickness, GraphicsDpi.Point, GraphicsDpi.UnitToDpi(gr.PageUnit));
            SolidBrush brush = BrickPaint.GetBrush(Color.Black);

            //Top Left
            RectangleF vertLine = new RectangleF(rect.Location, new SizeF(markThickness, markSize));
            RectangleF horzLine = new RectangleF(rect.Location, new SizeF(markSize, markThickness));
            gr.FillRectangle(brush, vertLine);
            gr.FillRectangle(brush, horzLine);

            //Bottom Left
            vertLine.Offset(0, rect.Height - markSize);
            horzLine.Offset(0, rect.Height - markThickness);
            gr.FillRectangle(brush, vertLine);
            gr.FillRectangle(brush, horzLine);

            //Bottom Right
            vertLine.Offset(rect.Width - markThickness, 0);
            horzLine.Offset(rect.Width - markSize, 0);
            gr.FillRectangle(brush, vertLine);
            gr.FillRectangle(brush, horzLine);

            //Top Right
            vertLine.Offset(0, markSize - rect.Height);
            horzLine.Offset(0, markThickness - rect.Height);
            gr.FillRectangle(brush, vertLine);
            gr.FillRectangle(brush, horzLine);
        }
    }
}
