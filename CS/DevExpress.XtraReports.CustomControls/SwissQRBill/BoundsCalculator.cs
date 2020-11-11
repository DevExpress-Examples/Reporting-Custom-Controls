using DevExpress.XtraPrinting;
using System.Drawing;

namespace DevExpress.XtraReports.CustomControls.SwissQRBill {
    public static class BoundsCalculator {
        public static RectangleF GetPaymentBounds(SwissQRBillBrick qrBillBrick) {
            RectangleF bounds = Constants.PaymentBounds;
            bounds.Y = GetIntegratedModeOffset(qrBillBrick);
            if(qrBillBrick.BillKind == QRBillKind.PaymentAndReceipt)
                bounds.X = Constants.PaymentPartOffset;
            return bounds;
        }
        public static RectangleF GetReceiptBounds(SwissQRBillBrick qrBillBrick) {
            RectangleF bounds = Constants.ReceiptBounds;
            bounds.Y = GetIntegratedModeOffset(qrBillBrick);
            return bounds;
        }
        public static PointF GetVerticalLineOffset(SwissQRBillBrick qrBillBrick) {
            var xOffset = MmToDocConverter.Convert(Constants.PaymentPartOffset);
            var yOffset = MmToDocConverter.Convert(GetIntegratedModeOffset(qrBillBrick));
            return new PointF(xOffset, yOffset);
        }
        public static PointF GetHorizontalLineOffset(SwissQRBillBrick qrBillBrick) {
            var yOffset = MmToDocConverter.Convert(GetIntegratedModeOffset(qrBillBrick));
            return new PointF(0, yOffset);
        }
        public static PointF GetVerticalScissorsOffset(SwissQRBillBrick qrBillBrick) {
            PointF resultPoint = GetVerticalLineOffset(qrBillBrick);
            resultPoint.Y += GraphicsUnitConverter.DipToDoc(Constants.ScissorOffset);
            return OffsetPoint(resultPoint, -GraphicsUnitConverter.DipToDoc(Constants.ScissorSize.Width / 2), -GraphicsUnitConverter.DipToDoc(Constants.ScissorSize.Height / 2));
        }
        public static PointF GetHorizontalScissorsOffset(SwissQRBillBrick qrBillBrick) {
            PointF resultPoint = GetHorizontalLineOffset(qrBillBrick);
            resultPoint.X += GraphicsUnitConverter.DipToDoc(Constants.ScissorOffset);
            return OffsetPoint(resultPoint, -GraphicsUnitConverter.DipToDoc(Constants.ScissorSize.Width / 2), -GraphicsUnitConverter.DipToDoc(Constants.ScissorSize.Height / 2));
        }
        static PointF OffsetPoint(PointF point, float offsetX, float offsetY) {
            return new PointF(point.X + offsetX, point.Y + offsetY);
        }
        public static SizeF GetSeparateLineTextSize(SwissQRBillBrick qrBillBrick) {
            float width = qrBillBrick.BillKind == QRBillKind.PaymentOnly ? Constants.PaymentBounds.Width : Constants.PaymentAndReceiptBounds.Width;
            float height = Constants.IntegratedModeOffset;
            return new SizeF(MmToDocConverter.Convert(width), MmToDocConverter.Convert(height));
        }
        static float GetIntegratedModeOffset(SwissQRBillBrick qrBillBrick) {
            return qrBillBrick.BillOptions.IntegratedMode ? Constants.IntegratedModeOffset : 0;
        }
    }
}
