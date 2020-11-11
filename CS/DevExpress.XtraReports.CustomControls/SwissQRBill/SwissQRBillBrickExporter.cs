using DevExpress.XtraPrinting;
using DevExpress.XtraPrinting.BrickExporters;
using DevExpress.XtraReports.CustomControls.Properties;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace DevExpress.XtraReports.CustomControls.SwissQRBill {
    public class SwissQRBillBrickExporter : PanelBrickExporter {
        static PointF OffsetPoint(PointF point, PointF offset) {
            return new PointF(point.X + offset.X, point.Y + offset.Y);
        }
        static float[] GetDashPattern(DashStyle style) {
            switch(style) {
                case DashStyle.Dash:
                    return new float[] { 3, 3 };
                case DashStyle.Dot:
                    return new float[] { 1, 2 };
            }
            return new float[] { 1 };
        }
        static DashStyle GetPenDashStyle(SeparatorKind separatorKind) {
            if(separatorKind.HasFlag(SeparatorKind.DashedLine))
                return DashStyle.Dash;
            if(separatorKind.HasFlag(SeparatorKind.DottedLine))
                return DashStyle.Dot;
            if(separatorKind.HasFlag(SeparatorKind.SolidLine))
                return DashStyle.Solid;
            return DashStyle.Custom;
        }

        SwissQRBillBrick SwissQRBillBrick { get { return Brick as SwissQRBillBrick; } }

        public override void Draw(IGraphics gr, RectangleF rect, RectangleF parentRect) {
            base.Draw(gr, rect, parentRect);
            if(gr is IPdfGraphics)
                DrawSeparators(gr, rect, SwissQRBillBrick.BillOptions.PdfSeparatorKind);
            else
                DrawSeparators(gr, rect, SwissQRBillBrick.BillOptions.PreviewSeparatorKind);
        }

        void DrawSeparators(IGraphics gr, RectangleF rect, SeparatorKind mode) {
            if(mode == SeparatorKind.None)
                return;

            DrawVerticalSeparator(gr, rect, mode);
            DrawHorizontalSeparator(gr, rect, mode);
        }
        void DrawVerticalSeparator(IGraphics gr, RectangleF rect, SeparatorKind mode) {
            if(SwissQRBillBrick.BillKind == QRBillKind.PaymentAndReceipt) {
                DrawVerticallLine(gr, rect, mode);

                if(mode.HasFlag(SeparatorKind.Scissors))
                    DrawVerticalScissors(gr, rect);
            }
        }
        void DrawHorizontalSeparator(IGraphics gr, RectangleF rect, SeparatorKind mode) {
            if(SwissQRBillBrick.BillOptions.IntegratedMode) {
                DrawHorizontalLine(gr, rect, mode);

                if(mode.HasFlag(SeparatorKind.Scissors))
                    DrawHorizontalScissors(gr, rect);

                if(mode.HasFlag(SeparatorKind.Text))
                    DrawSeparateLineText(gr, rect);
            }
        }
        void DrawSeparateLineText(IGraphics gr, RectangleF rect) {
            var size = BoundsCalculator.GetSeparateLineTextSize(SwissQRBillBrick);
            var text = LocalizationData.Instance[SwissQRBillBrick.BillOptions.Language, SectionId.SeparateBeforePayingIn];
            BrickStringFormat bsf = new BrickStringFormat(StringAlignment.Center, StringAlignment.Center);
            gr.DrawString(text, GetSeparatorLineTextFont(), Brushes.Black, new RectangleF(rect.Location, size), bsf.Value);
        }
        Font GetSeparatorLineTextFont() {
            //there is no font size in specification
            return new Font(SwissQRBillBrick.BillOptions.FontFamily.ToString(), Constants.PaymentHeadingFontSize, FontStyle.Regular);
        }        
        void DrawVerticalScissors(IGraphics gr, RectangleF rect) {
            PointF offset = BoundsCalculator.GetVerticalScissorsOffset(SwissQRBillBrick);
            gr.DrawImage(Resources.VerticalScissors, new RectangleF(OffsetPoint(rect.Location, offset), new SizeF(50, 50)));
        }
        void DrawHorizontalScissors(IGraphics gr, RectangleF rect) {
            PointF offset = BoundsCalculator.GetHorizontalScissorsOffset(SwissQRBillBrick);
            gr.DrawImage(Resources.HorizontalScissors, new RectangleF(OffsetPoint(rect.Location, offset), new SizeF(50, 50)));
        }
        void DrawVerticallLine(IGraphics gr, RectangleF rect, SeparatorKind separationLineDrawMode) {
            Pen pen = BrickPaint.GetPen(Color.Black, GraphicsUnitConverter.DipToDoc(1f));
            pen.DashStyle = GetPenDashStyle(separationLineDrawMode);
            pen.DashPattern = GetDashPattern(pen.DashStyle);

            PointF lineOffsetPoint = BoundsCalculator.GetVerticalLineOffset(SwissQRBillBrick);
            PointF point1 = OffsetPoint(rect.Location, lineOffsetPoint);            
            PointF point2 = new PointF(point1.X, rect.Bottom);
            gr.DrawLine(pen, point1, point2);
        }
        void DrawHorizontalLine(IGraphics gr, RectangleF rect, SeparatorKind separationLineDrawMode) {
            Pen pen = BrickPaint.GetPen(Color.Black, GraphicsUnitConverter.DipToDoc(1f));
            pen.DashStyle = GetPenDashStyle(separationLineDrawMode);
            pen.DashPattern = GetDashPattern(pen.DashStyle);

            PointF lineOffsetPoint = BoundsCalculator.GetHorizontalLineOffset(SwissQRBillBrick);
            PointF point1 = OffsetPoint(rect.Location, lineOffsetPoint);
            PointF point2 = new PointF(rect.Right, point1.Y);
            gr.DrawLine(pen, point1, point2);
        }
    }
}
