namespace DevExpress.XtraReports.CustomControls.SwissQRBill {
    public class PaymentReferenceAccountNumber : AccountNumber {
        const string DefaultNumber = "RFXXXXXXXXXXXXXX";

        public PaymentReferenceAccountNumber() : this(DefaultNumber) { }
        public PaymentReferenceAccountNumber(string ibanStr) : base(ibanStr) { }
        static bool IsCreditorReference(string str) {
            return str.Length == 16 && str.StartsWith("RF");
        }
        static bool IsQR_Reference(string str) {
            return str.Length == 27;
        }
        protected override bool IsValid(string str) {
            return string.IsNullOrEmpty(str) || IsQR_Reference(str) || IsCreditorReference(str);
        }
        protected override void IdentifyFormat() {
            if(IsCreditorReference(Number))
                NumberFormat = AccountNumberFormat.CreditorReference;
            if(IsQR_Reference(Number))
                NumberFormat = AccountNumberFormat.QRReference;
            if(string.IsNullOrEmpty(Number))
                NumberFormat = AccountNumberFormat.None;
        }
        public override void Reset() {
            Number = DefaultNumber;
        }
        public override string ConvertToQRCodeDataString() {
            return NumberFormat == AccountNumberFormat.None ? string.Empty : Number;
        }
    }
}
