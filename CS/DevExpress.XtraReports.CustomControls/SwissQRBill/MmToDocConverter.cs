using System.Drawing;
using DevExpress.XtraPrinting;

namespace DevExpress.XtraReports.CustomControls.SwissQRBill {
    public static class MmToDocConverter {
        public static float Convert(int value) {
            return GraphicsUnitConverter.Convert(value, GraphicsUnit.Millimeter, GraphicsUnit.Document);
        }
        public static float Convert(float value) {
            return GraphicsUnitConverter.Convert(value, GraphicsUnit.Millimeter, GraphicsUnit.Document);
        }
        public static SizeF Convert(SizeF size) {
            return GraphicsUnitConverter.Convert(size, GraphicsUnit.Millimeter, GraphicsUnit.Document);
        }
        public static RectangleF Convert(RectangleF rect) {
            return GraphicsUnitConverter.Convert(rect, GraphicsUnit.Millimeter, GraphicsUnit.Document);
        }
    }
}
