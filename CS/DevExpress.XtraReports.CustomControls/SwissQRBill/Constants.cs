using System.Drawing;

namespace DevExpress.XtraReports.CustomControls.SwissQRBill {
    public static class Constants {
        public static int ReceiptTitleFontSize = 11;
        public static int ReceiptHeadingFontSize = 6;
        public static int ReceiptValueFontSize = 8;
        public static int ReceiptAmountFontSize = 8;
        public static int ReceiptAcceptancePointFontSize = 6;

        public static int PaymentTitleFontSize = 11;
        public static int PaymentHeadingFontSize = 8;
        public static int PaymentValueFontSize = 10;
        public static int PaymentAmountFontSize = 10;
        public static int PaymentFurtherInformationFontSize = 7;

        public static FontStyle HeaderFontStyle = FontStyle.Bold;
        public static FontStyle ContentFontStyle = FontStyle.Regular;

        public static float CornerMarkThickness = 0.75f;
        public static float CornerMarkSize = 3f;

        public static int PaymentPartOffset = 62;
        public static int IntegratedModeOffset = 5;

        public static int ScissorOffset = 48; //px
        public static Size ScissorSize = new Size(16, 16); //px

        public static RectangleF PaymentTitleBounds = new RectangleF(5, 5, 51, 7);
        public static RectangleF PaymentInformationBounds = new RectangleF(56, 5, 87, 85);
        public static RectangleF PaymentAmountBounds = new RectangleF(5, 68, 51, 22);
        public static RectangleF PaymentAcceptancePointBounds = new RectangleF(5, 82, 52, 18);

        public static int PaymentPayableToCurrencyWidth = 15; //experimental value
        public static SizeF PaymentAmountCornerSize = new SizeF(40, 15);
        public static SizeF PaymentPayableToCornerSize = new SizeF(65, 25);

        public static RectangleF ReceiptTitleBounds = new RectangleF(5, 5, 52, 7);
        public static RectangleF ReceiptInformationBounds = new RectangleF(5, 12, 52, 56);
        public static RectangleF ReceiptAmountBounds = new RectangleF(5, 68, 52, 14);

        public static int ReceiptPayableToCurrencyWidth = 12; //experimental value
        public static SizeF ReceiptAmountCornerSize = new SizeF(30, 10);
        public static SizeF ReceiptPayableToCornerSize = new SizeF(52, 20);

        public static RectangleF QRCodeBounds = new RectangleF(5, 17, 46, 46);
        public static RectangleF ReceiptPartFurtherInformationBounds = new RectangleF(5, 90, 138, 10);

        public static RectangleF PaymentBounds = new Rectangle(0, 0, 148, 105);
        public static RectangleF ReceiptBounds = new Rectangle(0, 0, 62, 105);
        public static RectangleF PaymentAndReceiptBounds = new Rectangle(0, 0, 210, 105);
    }
}
