namespace DevExpress.XtraReports.CustomControls.SwissQRBill {
    public class CreditorAccountNumber : AccountNumber {
        const string DefaultNumber = "CHXXXXXXXXXXXXXXXXXXX";

        public CreditorAccountNumber(string ibanStr) : base(ibanStr) { }
        public CreditorAccountNumber() : this(DefaultNumber) { }
        static bool IsIban(string str) {
            return str.Length == 21 && (str.StartsWith("CH") || str.StartsWith("LI"));
        }
        static bool IsQR_IBAN(string str) {
            return IsIban(str) && str[4] == '3';
        }
        protected override bool IsValid(string str) {
            return IsIban(str) || IsQR_IBAN(str);
        }
        protected override void IdentifyFormat() {
            if(IsIban(Number))
                NumberFormat = AccountNumberFormat.IBAN;
            if(IsQR_IBAN(Number))
                NumberFormat = AccountNumberFormat.QR_IBAN;
        }
        public override void Reset() {
            Number = DefaultNumber;
        }
    }
}
