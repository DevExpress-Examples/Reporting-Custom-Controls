namespace DevExpress.XtraReports.CustomControls.SwissQRBill {
    public abstract class QRCodeDataElement {
        public abstract string ConvertToQRCodeDataString();
        public abstract void ConvertFromQRCodeDataString(string[] rawString);
        public abstract string ConvertToPresentationString();
        public abstract void Reset();
    }
}
