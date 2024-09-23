using DevExpress.Drawing;
using DevExpress.XtraPrinting;
using DevExpress.XtraPrinting.Native;
using System;
using System.Drawing;

namespace DevExpress.XtraReports.CustomControls {
    public static class RoundedBorderPaintHelper {
        public static void DrawRoundedBackGround(IGraphics gr, RectangleF rect, BrickStyle Style, BrickPaintBase painter, int radius) {
            var borderWidth = GraphicsUnitConverter.Convert(Style.BorderWidth, GraphicsDpi.DeviceIndependentPixel, GraphicsDpi.UnitToDpi((GraphicsUnit)gr.PageUnit));
            rect = RectangleF.Inflate(rect, -borderWidth / 2, -borderWidth / 2);
            DXGraphicsPath path = BuildPath(gr, rect, radius);
            gr.FillPath(painter.GetBrush(Style.BackColor), path);
        }

        public static void DrawRoundedBorders(IGraphics gr, RectangleF rect, BrickStyle Style, BrickPaintBase painter, int radius) {
            float borderWidth = GraphicsUnitConverter.Convert(Style.BorderWidth, GraphicsDpi.DeviceIndependentPixel, GraphicsDpi.UnitToDpi((GraphicsUnit)gr.PageUnit));
            if(borderWidth == 0)
                return;
            rect = RectHelper.AdjustBorderRect(rect, BorderSide.All, borderWidth, Style.BorderStyle);
            rect.Inflate(-borderWidth / 2, -borderWidth / 2);
            borderWidth = Math.Min(borderWidth, Math.Min(rect.Width, rect.Height));
            DXGraphicsPath path = BuildPath(gr, rect, radius);
            gr.DrawPath(painter.GetPen(Style.BorderColor, borderWidth), path);
        }

        static DXGraphicsPath BuildPath(IGraphics gr, RectangleF rect, int radius)
        {
            var path = new DXGraphicsPath();
            radius = GraphicsUnitConverter.Convert(radius, GraphicsDpi.DeviceIndependentPixel, GraphicsDpi.UnitToDpi((GraphicsUnit)gr.PageUnit));

            // Ensure the radius does not exceed half the height of the rectangle to prevent arc overlap
            radius = Math.Min(radius, (int)Math.Floor(rect.Height / 2));
            radius = Math.Min(radius, (int)Math.Floor(rect.Width / 2)); 

            path.AddLine(rect.Left + radius, rect.Top, rect.Right - radius, rect.Top);
            path.AddArc(rect.Right - 2 * radius, rect.Top, 2 * radius, 2 * radius, 270, 90);

            path.AddLine(rect.Right, rect.Top + radius, rect.Right, rect.Bottom - radius);
            path.AddArc(rect.Right - 2 * radius, rect.Bottom - 2 * radius, 2 * radius, 2 * radius, 0, 90);

            path.AddLine(rect.Right - radius, rect.Bottom, rect.Left + radius, rect.Bottom);
            path.AddArc(rect.Left, rect.Bottom - 2 * radius, 2 * radius, 2 * radius, 90, 90);

            path.AddLine(rect.Left, rect.Bottom - radius, rect.Left, rect.Top + radius);
            path.AddArc(rect.Left, rect.Top, 2 * radius, 2 * radius, 180, 90);

            path.CloseFigure();
            return path;
        }
    }
}
